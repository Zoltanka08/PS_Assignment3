using OnlineClinic.DisplayMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClinic.ObserverPattern
{
    public class Doctor : IDoctor
    {
        private string firstname;
        private string lastname;
        private PatientSubject patient;
        public string NotificationMessage { get; set;} 

        public Doctor(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public void Update(PatientAbstractSubject patient)
        {
            if (patient.HasArrived)
                this.NotificationMessage = string.Format("Dr. {0} {1} we notify you that your patient {2} {3} has arrived!",
                    this.firstname, this.lastname, patient.Firstname, patient.Lastname);
            else
                this.NotificationMessage = string.Format("Dr. {0} {1} we notify you that your patient {2} {3} has left!",
                    this.firstname, this.lastname, patient.Firstname, patient.Lastname);
        }

        public PatientSubject Patient 
        {
            get { return this.patient; }
            set { this.patient = value; }
        }
    }
}