using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSProject.Repository
{
    class LanguageRepository : ILanguageRepository
    {
        public int Add(Language language)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into Languages (Name)
                    output inserted.id
                    values (@Name)";

                command.Parameters.Add(new SqlParameter("Name", language.Name));

                return (int)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Language> GetAll()
        {
            List<Language> languages = new List<Language>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Languages";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Languages");

                foreach (DataRow row in ds.Tables["Languages"].Rows)
                {
                    var language = new Language
                    {
                        Id = (int)row["id"],
                        Name = row["Name"] as string
                    };

                    languages.Add(language);
                }
            }

            return languages;
        }

        public Language GetById(int id)
        {
            {
                using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
                {
                    string commandText = $"select * from Languages where id={id}";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                    DataSet ds = new DataSet();

                    dataAdapter.Fill(ds, "Languages");
                    if (ds.Tables["Languages"].Rows.Count > 0)
                    {
                        var row = ds.Tables["Languages"].Rows[0];

                        var language = new Language
                        {
                            Id = (int)row["id"],
                            Name = row["Name"] as string,
                        };

                        return language;
                    }
                }

                return null;
            }
        }

        public void Update(int id, Language language)
        {
            throw new NotImplementedException();
        }
    }
}
