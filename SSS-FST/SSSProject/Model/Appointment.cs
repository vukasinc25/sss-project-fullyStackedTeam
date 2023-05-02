using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Model
{
    public class Appointment : ICloneable
    {
        public int Id { get; set; }
        public DateTime DateAndTimeOfStart { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }

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

        public object Clone()
        {
            return new Appointment
            {
                Id = Id,
                DateAndTimeOfStart = DateAndTimeOfStart,
                Duration = Duration,
                Price = Price,
                Status = Status,
                Coach = Coach.Clone() as Coach
            };
        }
    }
}
