using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Repository
{
    interface IAppointmentRepository
    {
        List<Appointment> GetAll();
        Appointment GetById(int id);
        int Add(Appointment appointment);
        void Update(int id, Appointment appointment);
        void Delete(int id);
    }
}
