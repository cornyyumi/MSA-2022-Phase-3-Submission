using MSA_Phase_3.Domain.Data;
using NSubstitute;
namespace MSAPhase_3.Test
{
    public class Tests
    {

        private readonly IProjRepo _projRepo = Substitute.For<IProjRepo>();
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {

            Assert.Pass();
        }
    }
}