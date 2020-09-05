using NUnit.Framework;

namespace Leff.FiasPublicApi.Test
{
    public class FiasApiClientTests
    {
        private FiasApiClient _fiasApiClient;

        [SetUp]
        public void Setup()
        {
            _fiasApiClient = new FiasApiClient();
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }
    }
}