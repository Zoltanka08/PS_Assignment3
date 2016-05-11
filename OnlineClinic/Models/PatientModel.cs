using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClinic.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Nullable<int> Age { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public Nullable<bool> HasArrived { get; set; }
    }
}