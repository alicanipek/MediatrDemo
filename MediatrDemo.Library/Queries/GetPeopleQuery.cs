using System;
using System.Collections.Generic;
using MediatR;
using MediatrDemo.Library.Models;

namespace MediatrDemo.Library.Queries
{
    public record GetPeopleQuery() : IRequest<List<Person>>;
}
