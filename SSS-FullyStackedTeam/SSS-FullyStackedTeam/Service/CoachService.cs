using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Service
{
    internal class CoachService : ICoachService
    {
        private ICouchRepository repository;
        public int Add(Coach coach)
        {
            return repository.Add(coach);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<Coach> GetAll()
        {
            return repository.GetAll();
        }

        public Coach GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(int id, Coach coach)
        {
            repository.Update(id, coach);
        }
    }
}
