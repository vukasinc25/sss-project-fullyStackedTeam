using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Model
{
    public class Coach : ICloneable
    {
        public int Id { get; set; }
        public string DiplomaName { get; set; }
        public string SertificateName { get; set; }
        public string Title { get; set; }
        public double Profit { get; set; }
        public int NumberSuccessfulAppointments { get; set; }

        public bool IsSent { get; set; }
        public double Rank { get; set; }

        public Coach()
        {
            IsSent = false;
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
            return new Coach
            {
                DiplomaName = DiplomaName,
                SertificateName = SertificateName,
                Title = Title,
                Profit = Profit,
                User = User.Clone() as User,
                IsSent = IsSent,
                Rank = Rank
            };
        }

        public override string ToString()
        {
            return User.ToString();
        }
    }
}
