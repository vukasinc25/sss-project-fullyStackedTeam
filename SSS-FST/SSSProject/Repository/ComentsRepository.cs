using SSS_FullyStackedTeam.Repository;
using SSSProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSProject.Repository
{
    public class ComentsRepository : IComentRepository
    {
        CoachRepository coachRepository = new CoachRepository();
        ClientRepository clientRepository = new ClientRepository();
        public int Add(Coments coments)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into Coments (Coment, Rating, CoachId, ClientId) 
                    output inserted.Id
                    values (@Coment, @Rating, @CoachId, @ClientId)";

                command.Parameters.Add(new SqlParameter("Coment", coments.Coment));
                command.Parameters.Add(new SqlParameter("Rating", coments.Rating));
                command.Parameters.Add(new SqlParameter("CoachId", (object)coments.CoachId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("ClientId", (object)coments.ClientId ?? DBNull.Value));

                int id = (int)command.ExecuteScalar();

                return id;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Coments> GetAll()
        {
            List<Coments> coments = new List<Coments>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Coments";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Coments");
                foreach (DataRow row in ds.Tables["Coments"].Rows)
                {
                    var coment = new Coments()
                    {
                        Id = (int)row["Id"],
                        Coment = (string)row["Coment"],
                        Rating = (double)row["Rating"],
                        ClientId = (int)row["ClientId"],
                        CoachId = (int)row["CoachId"]
                    };

                    coment.Client = clientRepository.GetById(coment.ClientId);
                    coment.Coach = coachRepository.GetById(coment.CoachId);

                    coments.Add(coment);
                }
            }
            return coments;
        }

        public Coments GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Coments where Id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Coments");
                if (ds.Tables["Coments"].Rows.Count > 0)
                {
                    var row = ds.Tables["Coments"].Rows[0];

                    var coment = new Coments()
                    {
                        Id = (int)row["Id"],
                        Coment = (string)row["Coment"],
                        Rating = (double)row["Rating"],
                        ClientId = (int)row["ClientId"],
                        CoachId = (int)row["CoachId"]
                    };

                    coment.Client = clientRepository.GetById(coment.ClientId);
                    coment.Coach = coachRepository.GetById(coment.CoachId);
                    return coment;
                }
            }
            return new Coments();
        }

        public void Update(int id, Coments coments)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update Coments set Coment = @Coment, Rating = @Rating, CoachId = CoachId, ClientId = @ClientId where Id = @Id)";

                command.Parameters.Add(new SqlParameter("Coment", coments.Coment));
                command.Parameters.Add(new SqlParameter("Rating", coments.Rating));
                command.Parameters.Add(new SqlParameter("CoachId", (object)coments.ClientId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("ClientId", (object)coments.ClientId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("Id", id));

                command.ExecuteNonQuery();
            }
        }
    }
}
