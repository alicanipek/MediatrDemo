using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using MediatrDemo.Library.DataAccess;
using MediatrDemo.Library.Handlers;
using MediatrDemo.Library.Models;
using MediatrDemo.Library.Queries;
using Moq;
using Xunit;

namespace MediatrDemo.Library.UnitTests.Handlers {
	public class GetPeopleHandlerTests {
		private readonly Fixture fixture;

		public GetPeopleHandlerTests() {
			fixture = new Fixture();
		}

		[Fact]
		public async Task GetPersonListHandler_Handle_ShouldReturnPeopleList() {
			//Given
			var request = fixture.Create<GetPeopleQuery>();
			var mockDataAccess = new Mock<IDataAccess>();
			mockDataAccess.Setup(x => x.GetPeople()).Returns(new List<Person> {
				new Person {
					Id = 1,
					FirstName = "John",
					LastName = "Doe"
				},
				new Person {
					Id = 2,
					FirstName = "Jane",
					LastName = "Doe"
				}
			});
			//When
			var handler = new GetPersonListHandler(mockDataAccess.Object);
			var result = await handler.Handle(request, default);
			//Then
			result.Should().NotBeNull();
			result.Count.Should().Be(2);
		}
	}
}