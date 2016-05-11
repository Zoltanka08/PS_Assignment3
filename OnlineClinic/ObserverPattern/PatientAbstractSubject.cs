using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClinic.ObserverPattern
{
    public abstract class PatientAbstractSubject
    {
        private IList<IDoctor> doctors = new List<IDoctor>();
        public string firstname;
        public string lastname;
        private bool hasArrived;

        public PatientAbstractSubject(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public void Attach(IDoctor doctor)
        {
            this.doctors.Add(doctor);
        }

        public void Detach(IDoctor doctor)
        {
            this.doctors.Add(doctor);
        }

        public void Notify()
        {
            foreach(IDoctor doctor in doctors)
            {
                doctor.Update(this);
            }
        }

        public bool HasArrived
        {
            get { return this.hasArrived; }
            set 
            { 
                this.hasArrived = value;
                Notify();
            }
        }

        public string Firstname { get { return this.firstname; } }
        public string Lastname { get { return this.lastname; } }
    }
}