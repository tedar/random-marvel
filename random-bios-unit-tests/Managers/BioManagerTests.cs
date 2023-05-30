using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_unit_tests.Managers
{
    [TestFixture]
    internal class BioManagerTests
    {
        //private Mock<IConfiguration>? _configuration;
        private BioManager? _bioManager; 

        [SetUp]
        public void TestInit()
        {         
            //_configuration = new Mock<IConfiguration>();            
        }

        [Test]
        public async Task GetRandomBio_ShouldReturnBioResult()
        {
            // Arrange

            var bio = "{\"code\": 200,\"data\": {\"results\": [{\"id\": 1009159,\"name\": \"Archangel\",\"description\": \"Biography\"}]}}";

            var inMemorySettings = new Dictionary<string, string?> {
                { "MarvelAPI:BaseUrl", "https://acme.org"},
                { "MarvelAPI:PrivateKey", "PrivateKey"},
                { "MarvelAPI:PublicKey", "PublicKey"},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var httpClient = HttpMessageHandlerHelper.CreateHttpClient(HttpStatusCode.OK, bio);

            _bioManager = new BioManager(httpClient, configuration);

            //Act

            string? s = await _bioManager!.GetRandomBio();

            // Assert

            Assert.AreEqual(s!, "Biography");
        }
    }
}
