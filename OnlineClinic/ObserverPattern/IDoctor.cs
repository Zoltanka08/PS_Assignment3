using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClinic.ObserverPattern
{
    public interface IDoctor
    {
        void Update(PatientAbstractSubject patient);
    }
}
