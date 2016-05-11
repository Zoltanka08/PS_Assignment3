using ElectroShopRepository.Interfaces;
using Repository.DatabaseContext;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoleService : IRoleService
    {
        private IRepository<Role> roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Role GetById(int id)
        {
            return roleRepository.Get(r => r.Id == id);
        }
    }
}
