using System.Collections.Generic;
using MediatrDemo.Library.Models;

namespace MediatrDemo.Library.DataAccess
{
    public interface IDataAccess
    {
        List<Person> GetPeople();
        Person GetPerson(int Id);
        Person InsertPerson(string firstName, string lastName);
        Person UpdatePerson(int id, string firstName = null, string lastName = null);
    }
}