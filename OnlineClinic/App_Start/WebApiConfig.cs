using ElectroShopMobile;
using ElectroShopMobile.CustomAttributes;
using ElectroShopRepository.GenericRepository;
using ElectroShopRepository.GenericUnitOfWork;
using ElectroShopRepository.Interfaces;
using ElectroShopServices.Interfaces;
using ElectroShopServices.Services;
using Microsoft.Practices.Unity;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace OnlineClinic
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));
            container.RegisterType<IPatientService, PatientService>();
            container.RegisterType<IAppointmentService, AppointmentService>();
            container.RegisterType<ITreatmentService, TreatmentService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IMedicineService, MedicineService>();
            config.DependencyResolver = new UnityResolver(container);

            config.Filters.Add(new UserAuthorizeAttribute());
        }
    }
}
