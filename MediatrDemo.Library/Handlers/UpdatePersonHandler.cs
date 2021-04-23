using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Library.Commands;
using MediatrDemo.Library.DataAccess;
using MediatrDemo.Library.Models;

namespace MediatrDemo.Library.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Person>
    {
        private readonly IDataAccess _dataAccess;

        public UpdatePersonHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.UpdatePerson(request.Id, request.FirstName, request.LastName));
        }
    }
}
