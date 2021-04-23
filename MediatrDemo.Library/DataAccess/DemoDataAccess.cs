using System;
using System.Collections.Generic;
using System.Linq;
using MediatrDemo.Library.Models;

namespace MediatrDemo.Library.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<Person> people = new();

        public DemoDataAccess()
        {
            people.Add(new Person { Id = 1, FirstName = "LeBron", LastName = "James" });
            people.Add(new Person { Id = 2, FirstName = "Kobe", LastName = "Bryant" });
        }

        public List<Person> GetPeople()
        {
            return people;
        }

        public Person GetPerson(int id)
        {
            Person p = people.FirstOrDefault(x => x.Id == id);
            return p;
        }

        public Person InsertPerson(string firstName, string lastName)
        {
            Person p = new() { FirstName = firstName, LastName = lastName };
            p.Id = people.Max(x => x.Id) + 1;
            people.Add(p);
            return p;
        }

        public Person UpdatePerson(int id, string firstName = null, string lastName = null)
        {
            Person p = people.FirstOrDefault(x => x.Id == id);
            if(p != null)
            {
                p.FirstName = firstName ?? p.FirstName;
                p.LastName = lastName ?? p.LastName;
            }
            return p;
        }
    }
}
