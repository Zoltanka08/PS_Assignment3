using AutoMapper;
using ElectroShopMobile.CustomAttributes;
using ElectroShopServices.Interfaces;
using OnlineClinic.DisplayMessage;
using OnlineClinic.Models;
using OnlineClinic.ObserverPattern;
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
    public class PatientController : ApiController
    {
        private IPatientService patientService;
        private IUserService userService;
        private IAppointmentService appointmentService;

        public PatientController(IPatientService patientService, IUserService userService, IAppointmentService appointmentService)
        {
            this.patientService = patientService;
            this.userService = userService;
            this.appointmentService = appointmentService;
        }

        [HttpPost]
        public IEnumerable<string> NotifyDoctors(PatientModel model)
        {
            IEnumerable<User> doctors = GetDoctorsByPatientId(model.Id);
            PatientSubject patient = new PatientSubject(model.Firstname, model.Lastname);
            IList<Doctor> observerDoctors = new List<Doctor>();
            IList<string> messages = new List<string>();

            foreach(User doctor in doctors)
            {
                Doctor observerDoctor = new Doctor(doctor.Firstname, doctor.Lastname);
                patient.Attach(observerDoctor);
                observerDoctors.Add(observerDoctor);
            }

            if(model.HasArrived != null)
                patient.HasArrived = (bool)model.HasArrived;

            foreach(Doctor doctor in observerDoctors)
            {
                messages.Add(doctor.NotificationMessage);
            }

            return messages;
        }

        public IEnumerable<PatientModel> GetAll()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Patient, PatientModel>(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<Patient> patients = patientService.GetAll();

            return mapper.Map<IEnumerable<Patient>, IEnumerable<PatientModel>>(patients);
        }

        [HttpPost]
        public void PostPatient(PatientModel model)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<PatientModel, Patient>(); });
            IMapper mapper = config.CreateMapper();
            Patient patient = mapper.Map<PatientModel, Patient>(model);
            patientService.Insert(patient);
        }

        [HttpPost]
        public void UpdatePatient(PatientModel model)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<PatientModel, Patient>(); });
            IMapper mapper = config.CreateMapper();
            Patient patient = mapper.Map<PatientModel, Patient>(model);
            patientService.Update(patient);
        }

        [HttpPost]
        public void DeletePatient(int id)
        {
            patientService.Delete(id);
        }

        private IEnumerable<User> GetDoctorsByPatientId(int patientId)
        {
            IList<User> doctors = new List<User>();
            IEnumerable<Appointment> appointments = appointmentService.GetAppointmentByPatientId(patientId);

            foreach(Appointment appointment in appointments)
            {
                User doctor = userService.GetById((int)appointment.UserId);
                doctors.Add(doctor);
            }

            return doctors;
        }
    }
}
