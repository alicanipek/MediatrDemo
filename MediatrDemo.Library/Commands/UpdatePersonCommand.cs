using System;
using MediatR;
using MediatrDemo.Library.Models;

namespace MediatrDemo.Library.Commands
{
    #nullable enable
    public record UpdatePersonCommand(int Id, string? FirstName, string? LastName) : IRequest<Person>;
}
