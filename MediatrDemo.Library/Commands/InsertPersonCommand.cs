using System;
using MediatR;
using MediatrDemo.Library.Models;

namespace MediatrDemo.Library.Commands
{
    public record InsertPersonCommand(string FirstName, string LastName) : IRequest<Person>;
}
