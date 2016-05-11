using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClinic.Models
{
    public class TreatmentModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<int> MedicineId { get; set; }
    }
}