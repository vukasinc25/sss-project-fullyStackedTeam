using SSS_FullyStackedTeam.Model;
using SSSProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        CoachRepository coachRepository = new CoachRepository();
        public int Add(Appointment appointment)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into Appointments (TimeOfStart, Duration, Price, Status, CoachId) 
                    output inserted.Id
                    values (@TimeOfStart, @Duration, @Price, @Status, @CoachId)";

                command.Parameters.Add(new SqlParameter("TimeOfStart", appointment.DateAndTimeOfStart));
                command.Parameters.Add(new SqlParameter("Duration", appointment.Duration));
                command.Parameters.Add(new SqlParameter("Price", appointment.Price));
                command.Parameters.Add(new SqlParameter("Status", appointment.Status));
                command.Parameters.Add(new SqlParameter("CoachId", (object)appointment.CoachId ?? DBNull.Value));

                int id = (int)command.ExecuteScalar();

                return id;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Appointments";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Appointments");
                foreach (DataRow row in ds.Tables["Appointments"].Rows)
                {
                    var appointment = new Appointment()
                    {
                        Id = (int)row["Id"],
                        DateAndTimeOfStart = DateTime.Parse((string)row["TimeOfStart"]),
                        Duration = TimeSpan.Parse((string)row["Duration"]),
                        Price = (double)row["Price"],
                        Status = (bool)row["Status"],
                        CoachId = (int)row["CoachId"]
                    };

                    appointment.Coach = coachRepository.GetById(appointment.CoachId);

                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public Appointment GetById(int id)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Appointments where Id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Appointments");
                if (ds.Tables["Appointments"].Rows.Count > 0)
                {
                    var row = ds.Tables["Appointments"].Rows[0];

                    var appointment = new Appointment()
                    {
                        Id = (int)row["Id"],
                        DateAndTimeOfStart = DateTime.Parse((string)row["TimeOfStart"]),
                        Duration = TimeSpan.Parse((string)row["Duration"]),
                        Price = (double)row["Price"],
                        Status = (bool)row["Status"],
                        CoachId = (int)row["CoachId"]
                    };

                    appointment.Coach = coachRepository.GetById(appointment.CoachId);
                    return appointment;
                }
            }
            return new Appointment();
        }

        public void Update(int id, Appointment appointment)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update Appointments set TimeOfStart = @TimeOfStart, Duration = @Duration, Price = @Price, Status = @Status, CoachId = @CoachId where Id = @Id";

                command.Parameters.Add(new SqlParameter("TimeOfStart", appointment.DateAndTimeOfStart));
                command.Parameters.Add(new SqlParameter("Duration", appointment.Duration));
                command.Parameters.Add(new SqlParameter("Price", appointment.Price));
                command.Parameters.Add(new SqlParameter("Status", appointment.Status));
                command.Parameters.Add(new SqlParameter("CoachId", (object)appointment.CoachId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("Id", appointment.Id));

                command.ExecuteNonQuery();
            }
        }
    }
}
