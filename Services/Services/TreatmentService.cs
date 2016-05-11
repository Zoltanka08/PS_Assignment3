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
    public class TreatmentService : ITreatmentService
    {
        private IRepository<Treatment> treatmentRepository;

        public TreatmentService(IRepository<Treatment> treatmentRepository)
        {
            this.treatmentRepository = treatmentRepository;
        }

        public IEnumerable<Treatment> GetTreatmentByPatientId(int id)
        {
            return treatmentRepository.GetAll(t => t.PatientId == id);
        }

        public void Insert(Treatment treatment)
        {
            treatmentRepository.Add(treatment);
            treatmentRepository.SaveChanges();
        }
    }
}
