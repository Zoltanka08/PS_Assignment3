using OnlineClinic.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Repository.DatabaseContext;

namespace OnlineClinic.Controllers
{
    public class RoleController : ApiController
    {
        private IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public RoleModel GetRoleById(int id)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Role, RoleModel>(); });
            IMapper mapper = config.CreateMapper();
            Role role = roleService.GetById(id);
            return mapper.Map<Role, RoleModel>(role);
        }
    }
}
