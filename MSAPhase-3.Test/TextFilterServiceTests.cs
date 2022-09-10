using NSubstitute;
using Microsoft.Extensions.DependencyInjection;
using MSA_Phase_3.Service.Services;
using MSA_Phase_3.Service.Data;
using FluentAssertions;
using NUnit;
namespace MSAPhase_3.Test
{
    [TestFixture]
    public class TextFilterServiceTests
    {
        private readonly TextFilterService _textFilterService;
        public TextFilterServiceTests()
        {
            _textFilterService = new TextFilterService();
        }

        [Test]
        [TestCase("5hit")]
        [TestCase("fuck")]
        [TestCase("stop being a BITCH")]
        public void TestProfanityTrue(string text)
        {
            {
                bool result = _textFilterService.ContainsProfanity(text);
                result.Should().Be(true);
                //Assert.IsTrue(result);

            }
        }

        [Test]
        [TestCase("hi")]
        [TestCase("thank you")]
        [TestCase("you're the best :)")]
        public void TestProfanityFalse(string text)
        {
            {
                bool result = _textFilterService.ContainsProfanity(text);
                result.Should().Be(false);

            }
        }


    }
}