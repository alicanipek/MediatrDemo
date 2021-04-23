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
    public class GetPersonListHandler : IRequestHandler<GetPeopleQuery, List<Person>>
    {
        private readonly IDataAccess _dataAccess;
        public GetPersonListHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        public Task<List<Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetPeople());
        }
    }
}
