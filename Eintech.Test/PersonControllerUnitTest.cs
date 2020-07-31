using Eintech.Data;
using Eintech.Data.Entities;
using Eintech.WebApi.Controllers;
using Moq;
using System;
using Xunit;

namespace Eintech.Test
{
    public class PersonControllerUnitTest
    {
        public Person _person;

        private readonly PersonController _personController;
        private readonly Mock<IPersonRepository> _mockPersonRepository;


        public PersonControllerUnitTest()
        {
            _person = new Person
            {
                Id = 1,
                Name = "TestName",
                DateAdded = DateTime.Now
            };


            _mockPersonRepository = new Mock<IPersonRepository>();
            _personController = new PersonController(_mockPersonRepository.Object);

        }
        [Fact]
        public void ShouldAddPersonMethodReturnPersonObjectWithSavedData()
        {
            var result = _personController.Post(_person);

            Assert.NotNull(_person);
            Assert.Equal(result.Result.Name, _person.Name);
            Assert.Equal(result.Result.DateAdded, _person.DateAdded);
            Assert.Equal(result.Result.Id, _person.Id);
        }

        [Fact]
        public void ShouldThrowExceptionIfParametreIsNullOrEmpty()
        {
            var exception = Assert.ThrowsAsync<ArgumentNullException>(() => _personController.Post(null));
            Assert.Equal("person", exception.Result.ParamName);
        }

        [Fact]
        public void ShouldSaveThePersonData()
        {
            Person savedPerson = null;
            _mockPersonRepository.Setup(m => m.Save(It.IsAny<Person>()))
                .Callback<Person>(person =>
                {
                    savedPerson = person;
                });

            var result = _personController.Post(_person);

            _mockPersonRepository.Verify(p => p.Save(It.IsAny<Person>()), Times.Once);

            Assert.NotNull(savedPerson);
            Assert.Equal(_person.Name, savedPerson.Name);
            Assert.Equal(_person.DateAdded, savedPerson.DateAdded);
            Assert.Equal(_person.Id, savedPerson.Id);
        }
    }
}
