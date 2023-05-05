using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSProject.Model
{
    public class Coments : ICloneable
    {
        public int Id { get; set; }
        public string Coment { get; set; }
        public double Rating { get; set; }
        private Coach coach;
        public int CoachId { get; set; }
        public Coach Coach
        {
            get => coach;
            set
            {
                coach = value;
                CoachId = coach.Id;
            }
        }

        private Client client;
        public int ClientId { get; set; }
        public Client Client
        {
            get => client;
            set
            {
                client = value;
                ClientId = client.Id;
            }
        }
        public object Clone()
        {
            return new Coments
            {
                Id = Id,
                Coment = Coment,
                Rating = Rating,
                Coach = Coach.Clone() as Coach,
                Client = Client.Clone() as Client
            };
        }

        public override string ToString()
        {
            return Coment + "    "+"Rating: " + Rating;
        }
    }
}
