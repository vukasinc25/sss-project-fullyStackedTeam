using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Service
{
    interface IUserService
    {
        List<User> GetAll();
        List<User> GetActiveUsers();
        List<User> GetByUserType(string type);
        void Add(User user);
        void AddRegistered(User user);
        void Update(int id, User user);
        void Delete(int id);
    }
}