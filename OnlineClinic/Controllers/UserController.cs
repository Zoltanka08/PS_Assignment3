using ElectroShopServices.Interfaces;
using OnlineClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Repository.DatabaseContext;
using ElectroShopMobile.CustomAttributes;

namespace OnlineClinic.Controllers
{
    [UserAuthorize(Role = "Admin")]
    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public UserModel GetUserById(int id)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserModel>(); });
            IMapper mapper = config.CreateMapper();
            User user = userService.GetById(id);
            return mapper.Map<User, UserModel>(user);
        }

        public IEnumerable<UserModel> GetAll()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserModel>(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<User> users = userService.GetAll();

            return mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
        }

        [HttpPost]
        public void PostUser(UserModel model)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<UserModel, User>(); });
            IMapper mapper = config.CreateMapper();
            User user = mapper.Map<UserModel, User>(model);
            userService.Insert(user);
        }

        [HttpPost]
        public void UpdateUser(UserModel model)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<UserModel, User>(); });
            IMapper mapper = config.CreateMapper();
            User user = mapper.Map<UserModel, User>(model);
            userService.Update(user);
        }

        [HttpPost]
        public void DeleteUser(int id)
        {
            userService.Delete(id);
        }
    }
}
