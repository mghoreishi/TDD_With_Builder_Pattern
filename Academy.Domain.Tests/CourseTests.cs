using System;
using FluentAssertions;
using Xunit;

namespace Academy.Domain.Tests
{
    public class CourseTests
    {
        [Fact]
        public void Constructor_ShouldConstructCourseProperly()
        {
            const int id = 1;
            const string name = "tdd & bdd";
            const bool isOnline = true;
            const double tuition = 600;
            const string instructor = "hossein";
            var courseBuilder = new CourseTestBuilder();

            var course = courseBuilder.Build();

            course.Id.Should().Be(id);
            course.Name.Should().Be(name);
            course.IsOnline.Should().Be(isOnline);
            course.Tuition.Should().Be(tuition);
            course.Instructor.Should().Be(instructor);
            course.Sections.Should().BeEmpty();
     
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsNotProvided()
        {
            var courseBuilder = new CourseTestBuilder();

            Action course = () => courseBuilder.WithName("").Build();

            course.Should().ThrowExactly<CourseNameIsInvalidException>();
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenTuitionIsNotProvided()
        {
            var courseBuilder = new CourseTestBuilder();

            Action course = () => courseBuilder.WithTuition(0).Build();

            course.Should().ThrowExactly<CourseTuitionIsInvalidException>();
        }

        [Fact]
        public void AddSection_ShouldAddNewSectionToSections_WhenIdAndNamePassed()
        {
            //arrange
            var courseBuilder = new CourseTestBuilder();
            var course = courseBuilder.Build();
            var sectionToAdd = SectionFactory.Create();

            //act
            course.AddSection(sectionToAdd);

            //assert
            course.Sections.Should().ContainEquivalentOf(sectionToAdd);
        }
    }
}