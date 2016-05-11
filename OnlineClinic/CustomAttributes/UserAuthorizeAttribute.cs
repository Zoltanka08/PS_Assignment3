using System;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using Microsoft.Practices.Unity;
using ElectroShopRepository.GenericUnitOfWork;
using ElectroShopRepository.Interfaces;
using ElectroShopRepository.GenericRepository;
using ElectroShopServices.Services;
using ElectroShopServices.Interfaces;
using Repository.DatabaseContext;

namespace ElectroShopMobile.CustomAttributes
{
    public class UserAuthorizeAttribute : AuthorizationFilterAttribute
    {
        private bool hasRole = true;

        public string Role;

        public bool HasRole { get; set; }


        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var userService = GetUserService();

            if (CheckIfIdentityIsSet())
            {
                var user = userService.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
                if (user.Role.Name.Equals(Role))
                {
                    hasRole = true;
                    return;
                }

                hasRole = false;
            }

            InitializeIdentity();

            var authHeader = actionContext.Request.Headers.Authorization;

            if (hasRole && authHeader != null)
            {
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                    !string.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    var rawCredentials = authHeader.Parameter;
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));

                    var split = credentials.Split(':');
                    var username = split[0];
                    var password = split[1];

                    bool userExists = true;
                    User existingUser = null;

                    try
                    {
                        existingUser = userService.GetByUsername(username);
                    }
                    catch(Exception)
                    {
                        userExists = false;
                    }

                    if (userExists && existingUser.Password.Equals(password))
                    {
                        CustomPrincipal custom = new CustomPrincipal(existingUser.Username);
                        custom.Username = existingUser.Username;
                        custom.Mail = existingUser.Mail;
                        custom.Role = existingUser.Role.Name;

                        var principle = new GenericPrincipal(new GenericIdentity(username), null);
                        Thread.CurrentPrincipal = principle;

                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = custom;
                        }

                        return;
                    }
                }
            }

            HandleUnauthorized(actionContext);
        }

        private bool CheckIfIdentityIsSet()
        {
            return !string.IsNullOrWhiteSpace(Thread.CurrentPrincipal.Identity.Name);
        }

        private void InitializeIdentity()
        {
        }

        private void HandleUnauthorized(HttpActionContext actionContext)
        {
            throw new Exception("Authorization error!");

        }

        private IUserService GetUserService()
        {
            IUnityContainer uContainer = new UnityContainer().RegisterType<IUserService, UserService>();
            uContainer.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            uContainer.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));
            UserService userService = uContainer.Resolve<UserService>();

            return userService;
        }

        private CultureInfo ResolveCulture()
        {
            string[] languages = HttpContext.Current.Request.UserLanguages;

            if (languages == null || languages.Length == 0)
                return null;

            try
            {
                string language  = languages[0].ToLowerInvariant().Trim();
                return CultureInfo.CreateSpecificCulture(language);
            }
            catch (ArgumentException ex)
            {
                return null;
            }
        }

    }
}