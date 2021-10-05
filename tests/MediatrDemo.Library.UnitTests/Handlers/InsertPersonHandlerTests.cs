using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using MediatrDemo.Library.Commands;
using MediatrDemo.Library.DataAccess;
using MediatrDemo.Library.Handlers;
using MediatrDemo.Library.Models;
using Moq;
using Xunit;

namespace MediatrDemo.Library.UnitTests.Handlers {
	public class InsertPersonHandlerTests {
		private readonly Fixture fixture;

		public InsertPersonHandlerTests() {
			fixture = new Fixture();
		}

		[Fact]
		public async Task InsertPersonHandler_Handle_ShouldReturnPeople() {
			// Arrange
			var request = fixture.Create<InsertPersonCommand>();
			var person = fixture.Build<Person>()
				.With(x => x.FirstName, request.FirstName)
				.With(x => x.LastName, request.LastName)
				.Create();
			var mockDataAccess = new Mock<IDataAccess>();
			mockDataAccess.Setup(x => x.InsertPerson(It.IsAny<string>(), It.IsAny<string>())).Returns(person);

			// Act
			var handler = new InsertPersonHandler(mockDataAccess.Object);
			var result = await handler.Handle(request, default);

			// Assert
			person.FirstName.Should().Be(result.FirstName);
			person.LastName.Should().Be(result.LastName);

		}
	}
}