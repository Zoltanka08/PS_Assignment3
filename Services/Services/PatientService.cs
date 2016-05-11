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
    public class PatientService : IPatientService
    {
        private IRepository<Patient> patientRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return patientRepository.Get(p => p.Id == id);
        }

        public void Insert(Patient patient)
        {
            patientRepository.Add(patient);
            patientRepository.SaveChanges();
        }

        public void Update(Patient patient)
        {
            patientRepository.Update(patient);
            patientRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            Patient patient = GetById(id);
            patientRepository.Delete(patient);
            patientRepository.SaveChanges();
        }
    }
}
