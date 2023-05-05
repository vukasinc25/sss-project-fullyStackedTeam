using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Repository;
using SSSProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Service
{
    public class ClientService : IClientService
    {
        private IClientRepository clientRepository;

        public ClientService()
        {
            clientRepository = new ClientRepository();
        }

        public int Add(Client client)
        {
            return clientRepository.Add(client);
        }

        public void Delete(int id)
        {
            clientRepository.Delete(id);
        }

        public List<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        public List<Goal> GetAllGoals()
        {
            return clientRepository.GetAllGoals();
        }

        public List<Illness> GetAllIllnesses()
        {
            return clientRepository.GetAllIllnesses();
        }

        public List<Prop> GetAllProps()
        {
            return clientRepository.GetAllProps();
        }

        public Client GetById(int? id)
        {
            return clientRepository.GetById(id);
        }

        public void Update(int id, Client client)
        {
            clientRepository.Update(id, client);    
        }
    }
}
