using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.DatabaseContext;
using ElectroShopRepository.Interfaces;
using Services.Interfaces;
using Moq;

namespace ServiceTests
{
    [TestClass]
    public class PatientServiceTest
    {
        private Mock<IRepository<Patient>> patientRepositoryMock;
        private IPatientService patientService;

        [TestInitialize]
        public void InitializeTest()
        {
            patientRepositoryMock = new Mock<IRepository<Patient>>();
        }

        [TestMethod]
        public void GetAll_PatientListProvided_CorrectCountReturned()
        {

        }

       
    }
}
