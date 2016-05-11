using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClinic.ObserverPattern
{
    public class PatientSubject : PatientAbstractSubject
    {
        public PatientSubject(string firstname, string lastname)
            : base(firstname, lastname)
        { 
        }
    }
}