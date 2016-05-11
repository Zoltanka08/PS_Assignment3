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
    public class MedicineService : IMedicineService
    {
        private IRepository<Medicine> medicineRepository;
 
        public MedicineService(IRepository<Medicine> medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        public Medicine GetById(int id)
        {
            return medicineRepository.Get(m => m.Id == id);
        }
    }
}