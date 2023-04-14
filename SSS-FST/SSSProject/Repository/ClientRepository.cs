using SSS_FullyStackedTeam.Model;
using SSSProject;
using SSSProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Repository
{
    public class ClientRepository : IClientRepository
    {
        UserRepository userRepository = new UserRepository();
        public int Add(Client client)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into Clients (Height, Weight, UserId) 
                    output inserted.Id
                    values (@Height, @Weight, @UserId)";

                command.Parameters.Add(new SqlParameter("Height", client.Height));
                command.Parameters.Add(new SqlParameter("Weight", client.Weight));
                command.Parameters.Add(new SqlParameter("UserId", client.UserId));

                int id = (int)command.ExecuteScalar();

                return id;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Clients";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Clients");
                foreach (DataRow row in ds.Tables["Clients"].Rows)
                {
                    var client = new Client()
                    {
                        Id = (int)row["id"],
                        Height = (double)row["Height"],
                        Weight = (double)row["Weight"],
                        //Dieses = (EDiseases)Enum.Parse(typeof(EDiseases), (string)row["Dieses"]),
                        //Props = (EProps)Enum.Parse(typeof(EProps), (string)row["Props"]),
                        //Goals = (EGoals)Enum.Parse(typeof(EGoals), (string)row["Goals"]),
                        UserId = (int)row["UserId"]
                    };

                    client.User = userRepository.GetById(client.UserId);

                    

                    clients.Add(client);
                }
            }
            return clients;
        }

        public List<Goal> GetAllGoals()
        {
            List<Goal> goals = new List<Goal>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Goals";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Goals");

                foreach (DataRow row in ds.Tables["Goals"].Rows)
                {
                    var goal = new Goal
                    {
                        Id = (int)row["id"],
                        Name = row["Name"] as string,
                    };

                    goals.Add(goal);
                }
            }

            return goals;
        }

        public void GetAllIllnesses()
        {
            throw new NotImplementedException();
        }

        public void GetAllProps()
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Client client)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Clients set 
                        Height = @Height,
                        Weight = @Weight
                        where id = @id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Height", client.Height));
                command.Parameters.Add(new SqlParameter("Weight", client.Weight));

                command.ExecuteScalar();

                SqlCommand command2 = conn.CreateCommand();
                command2.CommandText = @"delete from HasGoals where ClientId = @id";
                command2.Parameters.Add(new SqlParameter("id", id));

                command2.ExecuteScalar();

                foreach (Goal goal in client.Goals)
                {
                    SqlCommand command3 = conn.CreateCommand();
                    command3.CommandText = @"
                        insert into HasGoals (ClientId, GoalId) values (@ClientId, @GoalId)";

                    command3.Parameters.Add(new SqlParameter("ClientId", client.Id));
                    command3.Parameters.Add(new SqlParameter("GoalId", goal.Id));

                    command3.ExecuteScalar();
                }

                //if (user.UserType == EUserType.PROFESSOR)
                //{
                //    foreach (Language language in user.Languages)
                //    {
                //        SqlCommand command3 = conn.CreateCommand();
                //        command3.CommandText = @"
                //            insert into Teaches (langID, userProfID) values (@langID, @userProfID)";

                //        command3.Parameters.Add(new SqlParameter("langID", language.Id));
                //        command3.Parameters.Add(new SqlParameter("userProfID", user.Id));

                //        command3.ExecuteScalar();
                //    }
                //}
            }
        }
    }
}
