using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Repository
{
    interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int? id);
        List<User> GetByUserType(string type);
        int Add(User user);
        void Update(int id, User user);
        void Delete(int id);
    }
}

