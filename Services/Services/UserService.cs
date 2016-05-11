using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using ElectroShopRepository.Interfaces;
using ElectroShopServices.Interfaces;
using Repository.DatabaseContext;
using System;

namespace ElectroShopServices.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetByRoleName(string roleName)
        {
            return userRepository.GetAll(u => u.Role.Name.Equals(roleName));
        }

        public void Delete(int id)
        {
            User user = GetById(id);
            userRepository.Delete(user);
            userRepository.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll().ToList();
        }

        public User GetById(int id)
        {
            var user = userRepository.Get(u => u.Id == id);
            return user;
        }

        public User GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Error Null username!");
            }

            User user = null;
            try
            {
                user = userRepository.Get(u => u.Username.Equals(username));
            }
            catch (DbException)
            {
                throw new Exception("Error Wrong username");
            }

            return user;
        }

        public void Insert(User user)
        {
            try
            {
                userRepository.Add(user);
                userRepository.SaveChanges();
            }
            catch (DbException)
            {
                throw new Exception("Error Insert failed!");
            }
        }

        public void Update(User user)
        {
            try
            {
                this.userRepository.Update(user);
                userRepository.SaveChanges();
            }
            catch (DbException)
            {
                throw new Exception("Error Update failed!");
            }
        }
    }
}
