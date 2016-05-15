using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ElectroShopRepository.Interfaces;
using Repository.DatabaseContext;
using ElectroShopServices.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Expressions;
using ElectroShopServices.Services;
using ServiceTests.TestData;

namespace ServiceTests
{
    [TestClass]
    public class UserServiceTest
    {
        private Mock<IRepository<User>> userRepositoryMock;
        private IUserService userService;

        [TestInitialize]
        public void InitializeTests()
        {
            this.userRepositoryMock = new Mock<IRepository<User>>();
        }

        [TestMethod]
        public void GetAll_UserListProvided_CorrectCountReturned()
        {
            //Arrange
            int expectedUserCount = 2;
            SetupUserRepositoryMockGetAll(MockUserData.Users);
            SetupUserService();

            //Act
            int actualCount = userService.GetAll().Count();

            //Assert
            Assert.AreEqual(expectedUserCount, actualCount);
        }

        [TestMethod]
        public void GetById_CorrectUserId_CorrectUserReturned()
        {
            //Arrange
            int correctUserId = 0;
            User expectedUser = MockUserData.Users.First();
            SetupUserRepositoryMockGet(expectedUser);
            SetupUserService();

            //Act
            User actualUser = userService.GetById(correctUserId);

            //Assert
            Assert.AreEqual(expectedUser.Username, actualUser.Username);
        }


        private void SetupUserRepositoryMockGet(User user)
        {
            userRepositoryMock.Setup(u => u.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
        }

        private void SetupUserRepositoryMockGetAll(IEnumerable<User> users)
        {
            userRepositoryMock.Setup(u => u.GetAll(It.IsAny<Expression<Func<User, bool>>>())).Returns(users);
        }

        private void SetupUserService()
        {
            this.userService = new UserService(userRepositoryMock.Object);
        }
    }
}
