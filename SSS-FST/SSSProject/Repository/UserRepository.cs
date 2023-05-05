using SSS_FullyStackedTeam.Model;
using SSSProject;
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
    public class UserRepository : IUserRepository
    {
        LanguageRepository languageRepository = new LanguageRepository();
        public int Add(User user)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into Users (FirstName, LastName, Email, Password, Tel, CreditCard, Street, City, Country, PrimaryLanguageId) 
                    output inserted.Id
                    values (@FirstName, @LastName, @Email, @Password, @Tel, @CreditCard, @Street, @City, @Country, @PrimaryLanguageId)";
                
                command.Parameters.Add(new SqlParameter("FirstName", user.FirstName));
                command.Parameters.Add(new SqlParameter("LastName", user.LastName));
                command.Parameters.Add(new SqlParameter("Email", user.Email));
                command.Parameters.Add(new SqlParameter("Password", user.Password));
                command.Parameters.Add(new SqlParameter("Tel", user.Tel));
                command.Parameters.Add(new SqlParameter("CreditCard", user.CreditCard));
                command.Parameters.Add(new SqlParameter("Street", user.Street));
                command.Parameters.Add(new SqlParameter("City", user.City));
                command.Parameters.Add(new SqlParameter("Country", user.Country));
                command.Parameters.Add(new SqlParameter("PrimaryLanguageId", user.PrimaryLanguageId));

                int id = (int)command.ExecuteScalar();

                foreach (Language language in user.SecondaryLanguages)
                {
                    SqlCommand command2 = conn.CreateCommand();
                    command2.CommandText = @"
                            insert into HasLanguages (UserId, LangId) values (@UserId, @LangId)";

                    command2.Parameters.Add(new SqlParameter("UserId", id));
                    command2.Parameters.Add(new SqlParameter("LangId", language.Id));

                    command2.ExecuteScalar();
                }

                return id;
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "delete from Users where id = @id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Users";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Users");

                string commandText2 = "select * from HasLanguages";
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(commandText2, conn);

                DataSet ds2 = new DataSet();

                dataAdapter2.Fill(ds2, "HasLanguages");

                foreach (DataRow row in ds.Tables["Users"].Rows)
                {
                    var user = new User
                    {
                        Id = (int)row["id"],
                        FirstName = row["FirstName"] as string,
                        LastName = row["LastName"] as string,
                        Email = row["Email"] as string,
                        Password = row["Password"] as string,
                        Tel = row["Tel"] as string,
                        CreditCard = row["CreditCard"] as string,
                        Street = row["Street"] as string,
                        City = row["City"] as string,
                        Country = row["Country"] as string,
                        isAdmin = row["isAdmin"] as string
                        //TODO time zone
                    };

                    user.PrimaryLanguage = languageRepository.GetById((int)row["PrimaryLanguageId"]);

                    foreach (DataRow row2 in ds2.Tables["HasLanguages"].Rows)
                    {
                        if (user.Id == (int)row2["UserId"])
                        {
                            user.SecondaryLanguages.Add(languageRepository.GetById((int)row2["LangId"]));
                        }
                    }

                    users.Add(user);
                }
            }

            return users;
        }

        public User GetById(int? id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Users where id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Users");

                string commandText2 = "select * from HasLanguages";
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(commandText2, conn);

                DataSet ds2 = new DataSet();

                dataAdapter2.Fill(ds2, "HasLanguages");

                if (ds.Tables["Users"].Rows.Count > 0)
                {
                    var row = ds.Tables["Users"].Rows[0];

                    var user = new User
                    {
                        Id = (int)row["id"],
                        FirstName = row["FirstName"] as string,
                        LastName = row["LastName"] as string,
                        Email = row["Email"] as string,
                        Password = row["Password"] as string,
                        Tel = row["Tel"] as string,
                        CreditCard = row["CreditCard"] as string,
                        Street = row["Street"] as string,
                        City = row["City"] as string,
                        Country = row["Country"] as string,
                        isAdmin = row["isAdmin"] as string
                        //TODO time zone
                    };

                    user.PrimaryLanguage = languageRepository.GetById((int)row["PrimaryLanguageId"]);

                    foreach (DataRow row2 in ds2.Tables["HasLanguages"].Rows)
                    {
                        if (user.Id == (int)row2["UserId"])
                        {
                            user.SecondaryLanguages.Add(languageRepository.GetById((int)row2["LangId"]));
                        }
                    }

                    return user;
                }
            }

            return null;
        }

        public List<User> GetByUserType(string type)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User user)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update Users set 
                        FirstName = @FirstName,
                        LastName = @LastName,
                        Password = @Password,
                        Tel = @Tel,
                        CreditCard = @CreditCard,
                        Street = @Street,
                        City = @City,
                        Country = @Country,
                        PrimaryLanguageId = @PrimaryLanguageId
                        where id = @id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("FirstName", user.FirstName));
                command.Parameters.Add(new SqlParameter("LastName", user.LastName));
                command.Parameters.Add(new SqlParameter("Password", user.Password));
                command.Parameters.Add(new SqlParameter("Tel", user.Tel));
                command.Parameters.Add(new SqlParameter("CreditCard", user.CreditCard));
                command.Parameters.Add(new SqlParameter("Street", user.Street));
                command.Parameters.Add(new SqlParameter("City", user.City));
                command.Parameters.Add(new SqlParameter("Country", user.Country));
                command.Parameters.Add(new SqlParameter("PrimaryLanguageId", user.PrimaryLanguageId));

                command.ExecuteScalar();
            }
        }
    }
}
