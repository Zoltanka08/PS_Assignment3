using ElectroShopRepository.Interfaces;
using Repository.DatabaseContext;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IRepository<Appointment> appointmentRepository;

        public AppointmentService(IRepository<Appointment> appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public IEnumerable<Appointment> GetAppointmentByUserId(int userId)
        {
            return appointmentRepository.GetAll(a => a.UserId == userId);
        }

        public IEnumerable<Appointment> GetAppointmentByPatientId(int patientId)
        {
            return appointmentRepository.GetAll(a => a.PatientId == patientId);
        }

        public void Inser(Appointment appointment)
        {
            appointmentRepository.Add(appointment);
            appointmentRepository.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            appointmentRepository.Update(appointment);
            appointmentRepository.SaveChanges();
        }

        public void Delete(int appointmentId)
        {
            Appointment appointment = appointmentRepository.Get(a => a.Id == appointmentId);
            appointmentRepository.Delete(appointment);
            appointmentRepository.SaveChanges();
        }
    }
}
