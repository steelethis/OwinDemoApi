using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Diagnostics;

namespace DemoAPI.Model
{
    public class PersonRepository : IPersonRepository
    {

        private SQLiteConnection GetDbConnection()
        {
            return new SQLiteConnection(@"Data Source=E:\db\sqlite\peopleDB.db;Version=3;");
        }

        private void ExecuteSQLCommand(string sqlStatement)
        {
            SQLiteConnection dbConnection = GetDbConnection();
            
            using (dbConnection)
            {
                dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlStatement, dbConnection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

            }
        }

        public Person Add(Person item)
        {
            string sql = $"insert into people(name, address, email) values ('{item.Name}', '{item.Address}', '{item.Email}')";
            ExecuteSQLCommand(sql);

            return item;
        }

        public Person Get(int id)
        {
            Person retrievedPerson = new Person();
            string sql = $"select * from people where id = {id}";

            SQLiteConnection dbCon = GetDbConnection();
            using (dbCon)
            {
                dbCon.Open();
                SQLiteCommand command = new SQLiteCommand(sql, dbCon);
                SQLiteDataReader reader = command.ExecuteReader();

                reader.Read();
                retrievedPerson.Name = (string)reader["name"];
                retrievedPerson.Address = (string)reader["address"];
                retrievedPerson.Email = (string)reader["email"];
            }
                
            return retrievedPerson;
        }

        public IEnumerable<Person> GetAll()
        {

            SQLiteConnection dbCon = GetDbConnection();
            List<Person> people = new List<Person>();
            string sql = $"select * from people";

            using (dbCon)
            {
                dbCon.Open();
                SQLiteCommand command = new SQLiteCommand(sql, dbCon);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        Name = (string)reader["name"],
                        Address = (string)reader["address"],
                        Email = (string)reader["email"]
                    });
                }
            }
            return people;
        }

        public void Remove(string personId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}