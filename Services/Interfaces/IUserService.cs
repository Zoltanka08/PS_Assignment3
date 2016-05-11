using System.Collections.Generic;
using Repository.DatabaseContext;

namespace ElectroShopServices.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetByRoleName(string roleName);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByUsername(string username);
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
    }
}
