using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Academy.Domain.Tests
{
    public class SectionTests
    {
        [Fact]
        public void Constructor_Should_Construct_Section_Properly()
        {
            //Arrange
            const int id = 1;
            const string name = "tdd section";

            //Act
            var section = new Section(id, name);

            //Assert
            section.Id.Should().Be(id);
            section.Name.Should().Be(name);
        }
    }
}
