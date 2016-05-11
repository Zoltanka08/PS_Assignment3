using OnlineClinic.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Repository.DatabaseContext;

namespace OnlineClinic.Controllers
{
    public class MedicineController : ApiController
    {
        private IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        public MedicineModel GetMedicineById(int id)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Medicine, MedicineModel>(); });
            IMapper mapper = config.CreateMapper();
            Medicine medicine = medicineService.GetById(id);
            return mapper.Map<Medicine, MedicineModel>(medicine);
        }
    }
}
