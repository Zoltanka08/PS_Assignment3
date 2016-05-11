using System.Security.Principal;
using ElectroShopServices.Interfaces;

namespace ElectroShopMobile
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; set; }

        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public string Mail { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }

        public bool IsInRole(string role)
        {
            bool isInCorrect = Identity != null && Identity.IsAuthenticated &&
                            !string.IsNullOrWhiteSpace(role);
            bool IsUserInRole = Role.Equals(role);

            return isInCorrect && IsUserInRole;
        }
    }
}