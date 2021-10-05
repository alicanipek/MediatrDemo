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
	public class GetPersonHandlerTests {
		private readonly Fixture fixture;

		public GetPersonHandlerTests() {
			fixture = new Fixture();
		}

		[Fact]
		public async Task GetPersonHandler_Handle_ShouldReturnPerson() {
			// Arrange
			var person = fixture.Create<Person>();
			var request = fixture.Create<GetPersonQuery>();
			var mockDataAccess = new Mock<IDataAccess>();
			mockDataAccess.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(person);
			var handler = new GetPersonHandler(mockDataAccess.Object);

			// Act
			var result = await handler.Handle(request, default);

			// Assert
			result.Should().Be(person);
		}
	}
}