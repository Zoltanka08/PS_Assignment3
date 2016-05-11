using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAppointmentByUserId(int userId);
        IEnumerable<Appointment> GetAppointmentByPatientId(int patientId);
        void Inser(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(int appointmentId);
    }
}
