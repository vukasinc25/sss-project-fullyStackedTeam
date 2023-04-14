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
        User GetById(int id);
        int Add(User user);
        void Update(int id, User user);
        void Delete(int id);
    }
}