using System;
using MediatR;
using MediatrDemo.Library.Models;

namespace MediatrDemo.Library.Queries
{
    public record GetPersonQuery(int Id) : IRequest<Person>;

}
