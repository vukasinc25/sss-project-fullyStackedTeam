using SSSProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Model
{
    public class Client : ICloneable
    {
        public int Id { get; set; }
        public double Height { get; set; }  
        public double Weight { get; set; }
        public List<Goal> Goals { get; set; }
        public List<Illness> Illnesses { get; set; }
        public List<Prop> Props { get; set; }

        public Client()
        {
            Goals = new List<Goal>();
            Illnesses = new List<Illness>();
            Props = new List<Prop>();
        }

        private User user;

        public int UserId { get; set; }

        public User User
        {
            get => user;
            set
            {
                user = value;
                UserId = user.Id;
            }
        }

        public object Clone()
        {
            return new Client
            {
                Height = Height,
                Weight = Weight,
                User = User.Clone() as User
            };
        }
    }
}
