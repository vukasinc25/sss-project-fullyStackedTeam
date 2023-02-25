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
        private ICouchRepository couchRepository;
        public int Add(Coach coach)
        {
            return couchRepository.Add(coach);
        }

        public void Delete(int id)
        {
            couchRepository.Delete(id);
        }

        public List<Coach> GetAll()
        {
            return couchRepository.GetAll();
        }

        public Coach GetById(int id)
        {
            return couchRepository.GetById(id);
        }

        public void Update(int id, Coach coach)
        {
            couchRepository.Update(id, coach);
        }
    }
}
