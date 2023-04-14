using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }
        public int Add(User user)
        {
            return userRepository.Add(user);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public void Update(int id, User user)
        {
            userRepository.Update(id, user);
        }
    }
}
