using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests.TestData
{
    internal static class MockUserData
    {
        internal static IEnumerable<User> Users = new List<User>()
        {
            new User()
            {
                Firstname = "test1",
                Lastname = "test2",
                Mail = "mail_mail@mail.com",
                Password = "1234",
                Id = 1,
                Mobile = "5235235",
                RoleId = 2
            },
            new User()
            {
                Firstname = "test2",
                Lastname = "test2",
                Mail = "mail2_mail@mail.com",
                Password = "1234",
                Id = 2,
                Mobile = "34456335",
                RoleId = 3
            }
        };
    }
}
