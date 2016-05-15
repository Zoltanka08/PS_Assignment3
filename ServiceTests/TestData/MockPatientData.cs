using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests.TestData
{
    internal static class MockPatientData
    {
        internal static IEnumerable<Patient> patients = new List<Patient>()
        {
            new Patient()
            {
                Address = "asds",
                Age = 32,
                Firstname = "asfa",
                Lastname = "wwff",
                Mail = "mail@mail.com"
            },
            new Patient()
            {
                Address = "dgsdg",
                Age = 50,
                Firstname = "sgdsdfhsdf",
                Lastname = "wwff",
                Mail = "mail2@mail.com"
            }
        };
    }
}
