using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Model
{
    // treba da nasledi User
    public class Coach : ICloneable
    {
        public string Id { get; set; }
        public string nameOfTheDiploma { get; set; }
        public string nameOfTheCertificate { get; set; }
        public string Title { get; set; }
        public double Profit { get; set; }
        public int NumberOfFinishedTrainings { get; set; }

        public object Clone()
        {
            return new Coach
            {
                //dodaj jos atribute iz korinsika(User)
                nameOfTheCertificate = nameOfTheCertificate,
                nameOfTheDiploma = nameOfTheDiploma,
                Title = Title,
                Profit = Profit,
                NumberOfFinishedTrainings = NumberOfFinishedTrainings
            };
        }
    }
}
