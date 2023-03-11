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
        public Boolean Status { get; set; }

        public object Clone()
        {
            Appointment appointment = new Appointment
            {
                Id = Id,
                DateAndTimeOfStart = DateAndTimeOfStart,
                Duration = Duration,
                Price = Price,
                Status = Status
            };
            return appointment;
        }
    }
}
