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
using ElectroShopMobile.CustomAttributes;

namespace OnlineClinic.Controllers
{
    [UserAuthorize(Role = "Doctor")]
    public class TreatmentController : ApiController
    {
        private ITreatmentService treatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            this.treatmentService = treatmentService;
        }

        public IEnumerable<TreatmentModel> GetTreatmentOfPatient(int id)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Treatment, TreatmentModel>(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<Treatment> treatments = treatmentService.GetTreatmentByPatientId(id);

            return mapper.Map<IEnumerable<Treatment>, IEnumerable<TreatmentModel>>(treatments);
        }

        [HttpPost]
        public void PostTreatment(TreatmentModel model)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<TreatmentModel, Treatment>(); });
            IMapper mapper = config.CreateMapper();
            Treatment treatment = mapper.Map<TreatmentModel, Treatment>(model);
            treatmentService.Insert(treatment);
        }

    }
}
