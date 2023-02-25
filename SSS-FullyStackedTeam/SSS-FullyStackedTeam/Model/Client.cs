using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Model
{
    // mora da nasledi User
    public class Client : ICloneable
    {
        public double Height { get; set; }  
        public double Weight { get; set; }

        // ubaci atribute od User-a
        public object Clone()
        {
            return new Client
            {
                Height = Height,
                Weight = Weight
            };
        }
    }
}
