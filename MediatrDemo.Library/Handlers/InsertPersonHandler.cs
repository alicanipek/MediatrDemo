using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Library.Commands;
using MediatrDemo.Library.DataAccess;
using MediatrDemo.Library.Models;

namespace MediatrDemo.Library.Handlers
{
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, Person>
    {
        private readonly IDataAccess _dataAccess;

        public InsertPersonHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<Person> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            Person p = _dataAccess.InsertPerson(request.FirstName, request.LastName);
            return Task.FromResult(p);
        }
    }
}
