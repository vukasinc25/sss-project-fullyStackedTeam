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
    public class CoachRepository : ICouchRepository
    {
        UserRepository userRepository = new UserRepository();
        public int Add(Coach coach)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into Coaches (DiplomaName, SertificateName, Title, NumberSuccessfulAppointments, Profit, IsSent, UserId)
                output inserted.id
                values (@DiplomaName, @SertificateName, @Title, @NumberSuccessfulAppointments, @Profit, @IsSent, @UserId)";

                command.Parameters.Add(new SqlParameter("DiplomaName", coach.DiplomaName));
                command.Parameters.Add(new SqlParameter("SertificateName", coach.SertificateName));
                command.Parameters.Add(new SqlParameter("Title", coach.Title));
                command.Parameters.Add(new SqlParameter("NumberSuccessfulAppointments", coach.NumberSuccessfulAppointments));
                command.Parameters.Add(new SqlParameter("Profit", coach.Profit));
                command.Parameters.Add(new SqlParameter("IsSent", coach.IsSent));
                command.Parameters.Add(new SqlParameter("UserId", coach.UserId));

                return (int)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Coach> GetAll()
        {
            List<Coach> coaches = new List<Coach>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Coaches";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Coaches");
                foreach (DataRow row in ds.Tables["Coaches"].Rows)
                {
                    var coach = new Coach()
                    {
                        Id = (int)row["Id"],
                        DiplomaName = (string)row["DiplomaName"],
                        SertificateName = (string)row["SertificateName"],
                        Title = (string)row["Title"],
                        Profit = (double)row["Profit"],
                        IsSent = (bool)row["IsSent"],
                        NumberSuccessfulAppointments = (int)row["NumberSuccessfulAppointments"],
                        UserId = (int)row["UserId"]
                    };

                    coach.User = userRepository.GetById(coach.UserId);

                    coaches.Add(coach);
                }
            }
            return coaches;
        }

        public Coach GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Coaches where id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Coaches");
                if (ds.Tables["Coaches"].Rows.Count > 0)
                {
                    var row = ds.Tables["Coaches"].Rows[0];
                    var coach = new Coach()
                    {
                        Id = (int)row["Id"],
                        DiplomaName = (string)row["DiplomaName"],
                        SertificateName = (string)row["SertificateName"],
                        Title = (string)row["Title"],
                        Profit = (double)row["Profit"],
                        IsSent = (bool)row["IsSent"],
                        NumberSuccessfulAppointments = (int)row["NumberSuccessfulAppointments"],
                        UserId = (int)row["UserId"]
                    };

                    coach.User = userRepository.GetById(coach.UserId);

                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = "select * from Has";

                    return coach;
                }
            }
            return new Coach();
        }

        public void Update(int id, Coach coach)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update Coaches set DiplomaName = @DiplomaName, SertificateName = @SertificateName, Title = @Title, NumberSuccessfulAppointments = @NumberSuccessfulAppointments, Profit = @Profit, IsSent = @IsSent where id = @id";

                command.Parameters.Add(new SqlParameter("DiplomaName", coach.DiplomaName));
                command.Parameters.Add(new SqlParameter("SertificateName", coach.SertificateName));
                command.Parameters.Add(new SqlParameter("Title", coach.Title));
                command.Parameters.Add(new SqlParameter("NumberSuccessfulAppointments", coach.NumberSuccessfulAppointments));
                command.Parameters.Add(new SqlParameter("Profit", coach.Profit));
                command.Parameters.Add(new SqlParameter("IsSent", coach.IsSent));
                command.Parameters.Add(new SqlParameter("id", id));

                command.ExecuteScalar();
            }
        }
    }
}
