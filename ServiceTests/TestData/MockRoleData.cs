using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests.TestData
{
    internal static class MockRoleData
    {
        internal static Role correctRole = new Role()
        {
            Id = 2,
            Name = "Doctor"
        };

        internal static Role expectedRole = new Role()
        {
            Id = 2,
            Name = "Doctor"
        };
    }
}
