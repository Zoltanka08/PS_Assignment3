using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClinic.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}