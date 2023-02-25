using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Repository;
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

        public Client GetById(int id)
        {
            return clientRepository.GetById(id);
        }

        public void Update(int id, Client client)
        {
            clientRepository.Update(id, client);    
        }
    }
}
