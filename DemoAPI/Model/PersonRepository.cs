using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Model
{
    public class PersonRepository : IPersonRepository
    {
        private static Dictionary<int, Person> people = new Dictionary<int, Person>();
        private static int index;

        public Person Add(Person item)
        {
            people.Add(index++, item);

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