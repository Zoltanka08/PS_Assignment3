using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITreatmentService
    {
        IEnumerable<Treatment> GetTreatmentByPatientId(int id);
        void Insert(Treatment treatment);
    }
}
