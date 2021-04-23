using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Library.DataAccess;
using MediatrDemo.Library.Models;
using MediatrDemo.Library.Queries;

namespace MediatrDemo.Library.Handlers
{
    public class GetPersonHandler : IRequestHandler<GetPersonQuery, Person>
    {
        private readonly IDataAccess _dataAccess;

        public GetPersonHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<Person> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = _dataAccess.GetPerson(request.Id);
            return Task.FromResult(person);
        }
    }
}
