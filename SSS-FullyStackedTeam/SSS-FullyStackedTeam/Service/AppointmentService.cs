using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Service
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository appointmentRepository;
        public int Add(Appointment appointment)
        {
            return appointmentRepository.Add(appointment);
        }

        public void Delete(int id)
        {
            appointmentRepository.Delete(id);
        }

        public List<Appointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return appointmentRepository.GetById(id);
        }

        public void Update(int id, Appointment appointment)
        {
            appointmentRepository.Update(id, appointment);
        }
    }
}
