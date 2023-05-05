using SSS_FullyStackedTeam.Model;
using SSSProject;
using SSSProject.Model;
using SSSProject.Repository;
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
                

                string commandText2 = "select * from HasGoals";
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(commandText2, conn);

                DataSet ds2 = new DataSet();
                dataAdapter2.Fill(ds2, "HasGoals");


                string commandText3 = "select * from HasIllneses";
                SqlDataAdapter dataAdapter3 = new SqlDataAdapter(commandText3, conn);

                DataSet ds3 = new DataSet();
                dataAdapter3.Fill(ds3, "HasIllneses");


                string commandText4 = "select * from HasProps";
                SqlDataAdapter dataAdapter4 = new SqlDataAdapter(commandText4, conn);

                DataSet ds4 = new DataSet();
                dataAdapter4.Fill(ds4, "HasProps");

                foreach (DataRow row in ds.Tables["Clients"].Rows)
                {
                    var client = new Client()
                    {
                        Id = (int)row["id"],
                        Height = (double)row["Height"],
                        Weight = (double)row["Weight"],
                        UserId = (int)row["UserId"]
                    };

                    client.User = userRepository.GetById(client.UserId);

                    foreach (DataRow row2 in ds2.Tables["HasGoals"].Rows)
                    {
                        if (client.Id == (int)row2["ClientId"])
                        {
                            client.Goals.Add(GetGoalById((int)row2["GoalId"]));
                        }
                    }

                    foreach (DataRow row3 in ds3.Tables["HasIllneses"].Rows)
                    {
                        if (client.Id == (int)row3["ClientId"])
                        {
                            client.Illnesses.Add(GetIllnessById((int)row3["IllnessId"]));
                        }
                    }

                    foreach (DataRow row4 in ds4.Tables["HasProps"].Rows)
                    {
                        if (client.Id == (int)row4["ClientId"])
                        {
                            client.Props.Add(GetPropById((int)row4["PropId"]));
                        }
                    }

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

        public List<Illness> GetAllIllnesses()
        {
            List<Illness> illnesses = new List<Illness>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Illnesses";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Illnesses");

                foreach (DataRow row in ds.Tables["Illnesses"].Rows)
                {
                    var illness = new Illness
                    {
                        Id = (int)row["id"],
                        Name = row["Name"] as string,
                    };

                    illnesses.Add(illness);
                }
            }

            return illnesses;
        }

        public List<Prop> GetAllProps()
        {
            List<Prop> props = new List<Prop>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Props";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Props");

                foreach (DataRow row in ds.Tables["Props"].Rows)
                {
                    var prop = new Prop
                    {
                        Id = (int)row["id"],
                        Name = row["Name"] as string,
                    };

                    props.Add(prop);
                }
            }

            return props;
        }

        public Client GetById(int? id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Clients where id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Clients");


                string commandText2 = "select * from HasGoals";
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(commandText2, conn);

                DataSet ds2 = new DataSet();
                dataAdapter2.Fill(ds2, "HasGoals");


                string commandText3 = "select * from HasIllneses";
                SqlDataAdapter dataAdapter3 = new SqlDataAdapter(commandText3, conn);

                DataSet ds3 = new DataSet();
                dataAdapter3.Fill(ds3, "HasIllneses");


                string commandText4 = "select * from HasProps";
                SqlDataAdapter dataAdapter4 = new SqlDataAdapter(commandText4, conn);

                DataSet ds4 = new DataSet();
                dataAdapter4.Fill(ds4, "HasProps");

                if (ds.Tables["Clients"].Rows.Count > 0)
                {
                    var row = ds.Tables["Clients"].Rows[0];

                    var client = new Client()
                    {
                        Id = (int)row["id"],
                        Height = (double)row["Height"],
                        Weight = (double)row["Weight"],
                        UserId = (int)row["UserId"]
                    };

                    client.User = userRepository.GetById(client.UserId);

                    foreach (DataRow row2 in ds2.Tables["HasGoals"].Rows)
                    {
                        if (client.Id == (int)row2["ClientId"])
                        {
                            client.Goals.Add(GetGoalById((int)row2["GoalId"]));
                        }
                    }

                    foreach (DataRow row3 in ds3.Tables["HasIllneses"].Rows)
                    {
                        if (client.Id == (int)row3["ClientId"])
                        {
                            client.Illnesses.Add(GetIllnessById((int)row3["IllnessId"]));
                        }
                    }

                    foreach (DataRow row4 in ds4.Tables["HasProps"].Rows)
                    {
                        if (client.Id == (int)row4["ClientId"])
                        {
                            client.Props.Add(GetPropById((int)row4["PropId"]));
                        }
                    }

                    return client;
                }
            }

            return new Client();
        }

        public Goal GetGoalById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Goals where id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Goals");
                if (ds.Tables["Goals"].Rows.Count > 0)
                {
                    var row = ds.Tables["Goals"].Rows[0];

                    var goal = new Goal
                    {
                        Id = (int)row["id"],
                        Name = row["Name"] as string,
                    };

                    return goal;
                }
            }

            return null;
        }

        public Illness GetIllnessById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Illnesses where id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Illnesses");
                if (ds.Tables["Illnesses"].Rows.Count > 0)
                {
                    var row = ds.Tables["Illnesses"].Rows[0];

                    var illness = new Illness
                    {
                        Id = (int)row["id"],
                        Name = row["Name"] as string,
                    };

                    return illness;
                }
            }

            return null;
        }

        public Prop GetPropById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Props where id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Props");
                if (ds.Tables["Props"].Rows.Count > 0)
                {
                    var row = ds.Tables["Props"].Rows[0];

                    var prop = new Prop
                    {
                        Id = (int)row["id"],
                        Name = row["Name"] as string,
                    };

                    return prop;
                }
            }

            return null;
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


                SqlCommand command4 = conn.CreateCommand();
                command4.CommandText = @"delete from HasIllneses where ClientId = @id";
                command4.Parameters.Add(new SqlParameter("id", id));
                command4.ExecuteScalar();

                foreach (Illness illness in client.Illnesses)
                {
                    SqlCommand command5 = conn.CreateCommand();
                    command5.CommandText = @"
                        insert into HasIllneses (ClientId, IllnessId) values (@ClientId, @IllnessId)";

                    command5.Parameters.Add(new SqlParameter("ClientId", client.Id));
                    command5.Parameters.Add(new SqlParameter("IllnessId", illness.Id));
                    command5.ExecuteScalar();
                }


                SqlCommand command6 = conn.CreateCommand();
                command6.CommandText = @"delete from HasProps where ClientId = @id";
                command6.Parameters.Add(new SqlParameter("id", id));
                command6.ExecuteScalar();

                foreach (Prop prop in client.Props)
                {
                    SqlCommand command7 = conn.CreateCommand();
                    command7.CommandText = @"
                        insert into HasProps (ClientId, PropId) values (@ClientId, @PropId)";

                    command7.Parameters.Add(new SqlParameter("ClientId", client.Id));
                    command7.Parameters.Add(new SqlParameter("PropId", prop.Id));
                    command7.ExecuteScalar();
                }
            }
        }
    }
}
