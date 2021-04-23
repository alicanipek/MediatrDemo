using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Library.Commands;
using MediatrDemo.Library.Models;
using MediatrDemo.Library.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediatrDemo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PeopleController : Controller
    {
        public IMediator _mediator;

        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Person>> GetPeople()
        {
            return await _mediator.Send(new GetPeopleQuery());
        }

        [HttpGet("{id}")]
        public async Task<Person> GetPerson(int id)
        {
            return await _mediator.Send(new GetPersonQuery(id));
        }

        [HttpPost]
        public async Task<Person> InsertPerson([FromBody] Person p)
        {
            return await _mediator.Send(new InsertPersonCommand(p.FirstName, p.LastName));
        }

        [HttpPost]
        public async Task<Person> UpdatePerson([FromBody] Person p)
        {
            return await _mediator.Send(new UpdatePersonCommand(p.Id, p.FirstName, p.LastName));
        }
    }
}
