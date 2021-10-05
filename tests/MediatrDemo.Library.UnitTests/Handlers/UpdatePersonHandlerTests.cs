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
	public class UpdatePersonHandlerTests {
		private readonly Fixture fixture;

		public UpdatePersonHandlerTests() {
			fixture = new Fixture();
		}

		[Fact]
		public async Task UpdatePersonHandler_Handle_ShouldReturnPeople() {
			// Arrange
			var request = fixture.Create<UpdatePersonCommand>();
			var person = fixture.Build<Person>()
				.With(x => x.Id, request.Id)
				.With(x => x.FirstName, request.FirstName)
				.With(x => x.LastName, request.LastName)
				.Create();
			var mockDataAccess = new Mock<IDataAccess>();
			mockDataAccess.Setup(x => x.UpdatePerson(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).Returns(person);

			// Act
			var handler = new UpdatePersonHandler(mockDataAccess.Object);
			var result = await handler.Handle(request, default);

			// Assert
			person.FirstName.Should().Be(result.FirstName);
			person.LastName.Should().Be(result.LastName);

		}
	}
}