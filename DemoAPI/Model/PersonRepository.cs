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
        private static Dictionary<int, Person> people = new Dictionary<int, Person>();
        private static int index;

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
            return people[id];
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
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