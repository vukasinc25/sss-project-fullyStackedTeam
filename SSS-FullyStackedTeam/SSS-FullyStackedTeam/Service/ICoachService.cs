using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Service
{
    internal interface ICoachService
    {
        List<Coach> GetAll();
        Coach GetById(int id);
        int Add(Coach coach);
        void Update(int id, Coach coach);
        void Delete(int id);
    }
}
