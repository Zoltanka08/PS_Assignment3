using AutoMapper;
using ElectroShopMobile.CustomAttributes;
using ElectroShopServices.Interfaces;
using OnlineClinic.Models;
using Repository.DatabaseContext;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineClinic.Controllers
{
    [UserAuthorize(Role = "Secretary")]
    public class AppointmentController : ApiController
    {
        private IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public IEnumerable<AppointmentModel> GetAppointmentByUserId(int id)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Appointment, AppointmentModel>(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<Appointment> appointments = appointmentService.GetAppointmentByUserId(id);

            return mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentModel>>(appointments);
        }

        public IEnumerable<AppointmentModel> GetAppointmentByPatientId(int id)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Appointment, AppointmentModel>(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<Appointment> appointments = appointmentService.GetAppointmentByPatientId(id);

            return mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentModel>>(appointments);
        }

        [HttpPost]
        public HttpResponseMessage PostAppointment(AppointmentModel model)
        {
            if (IsAvailable(model))
            {
                MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<AppointmentModel, Appointment>(); });
                IMapper mapper = config.CreateMapper();

                Appointment appointment = mapper.Map<AppointmentModel, Appointment>(model);
                appointmentService.Inser(appointment);
                return Request.CreateResponse(HttpStatusCode.Created, "Appointment scheduled!");            
            }

            return Request.CreateResponse(HttpStatusCode.Conflict, "The doctor is busy!");
        }

        [HttpPost]
        public void DeleteAppointment(int appointmentId)
        {
            appointmentService.Delete(appointmentId);
        }

        private bool IsAvailable(AppointmentModel appointment)
        {
            IEnumerable<Appointment> existingAppointments = appointmentService.GetAppointmentByUserId((int)appointment.UserId);

            foreach(Appointment currentAppointment in existingAppointments)
            {
                if (currentAppointment.StartDate >= appointment.StartDate &&
                    currentAppointment.EndDate <= appointment.EndDate)
                    return false;
            }

            return true;
        }
    }
}
