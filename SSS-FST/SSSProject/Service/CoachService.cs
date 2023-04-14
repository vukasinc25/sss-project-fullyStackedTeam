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
        private ICouchRepository coachRepository;

        public CoachService()
        {
            coachRepository = new CoachRepository();
        }
        public int Add(Coach coach)
        {
            return coachRepository.Add(coach);
        }

        public void Delete(int id)
        {
            coachRepository.Delete(id);
        }

        public List<Coach> GetAll()
        {
            return coachRepository.GetAll();
        }

        public Coach GetById(int id)
        {
            return coachRepository.GetById(id);
        }

        public void Update(int id, Coach coach)
        {
            coachRepository.Update(id, coach);
        }
    }
}
