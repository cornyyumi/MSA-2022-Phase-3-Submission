using MSA_Phase_3.Service.Services;
using MSA_Phase_3.Service.Data;
using MSA_Phase_3.Domain.Models;

using NSubstitute;
using FluentAssertions;
namespace MSAPhase_3.Test
{
    [TestFixture]
    public class ProjServiceTests
    {

        private readonly IProjService _projService;
        private readonly IProjRepo _projRepo = Substitute.For<IProjRepo>();

        public ProjServiceTests()
        {
            _projService = new ProjService(_projRepo);
        }


        [Test]
        public void TestRegisterNull()
        {
            User result = _projRepo.getUser("username");
            result.Should().Be(null);
        }

        [Test]
        public void TestRegisterExists()
        {
            UserLogin details = Substitute.For<UserLogin>();
            details.UserName = "newuser";
            details.Password = "password";

            _projService.register(details).Returns(new User
            {
                UserName = details.UserName,
                Password = details.Password
            });
            details.UserName.Should().Be(_projService.register(details).UserName);
            // Assert.AreEqual(details, _projService.register(details).UserName);
        }

        [Test]
        public void TestLoginNull()
        {
            UserLogin login = Substitute.For<UserLogin>();
            login.UserName = "username";
            login.Password = "password";

            _projService.login(login).Returns(new User
            {
                UserName = null,
                Password = null
            });

            User result = _projRepo.login(login);
            result.UserName.Should().Be(null);
        }

        [Test]
        public void TestLoginExist()
        {
            UserLogin details = Substitute.For<UserLogin>();
            details.UserName = "username";
            details.Password = "password";
            var user = new User
            {
                UserName = "username",
                Password = "password"
            };

            _projService.login(details).Returns(user);


            details.UserName.Should().Be(_projService.login(details).UserName);


        }

        [Test]
        public void TestAllBooksEmpty()
        {
            IEnumerable<Book> result = _projService.getBooks();
            result.Count().Should().Be(0);
        }
    }
}