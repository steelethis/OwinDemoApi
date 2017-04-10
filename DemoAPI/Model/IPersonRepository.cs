using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Model
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person item);
        void Remove(string personId);
        bool Update(Person item);
    }
}