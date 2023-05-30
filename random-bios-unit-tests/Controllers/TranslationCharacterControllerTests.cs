
namespace random_bios_unit_tests.Controllers
{
    [TestFixture]
    public class TranslationCharacterControllerTests
    {
        private Mock<ITranslatedRandomBio>? _mockTranslatedRandomBio;
        private TranslationCharacterController? _translationCharacterController;
        private Mock<ILogger<TranslationCharacterController>>? _mockLogger;        

        [SetUp]
        public void TestInit()
        {
            _mockTranslatedRandomBio = new Mock<ITranslatedRandomBio>();
            _mockLogger = new Mock<ILogger<TranslationCharacterController>>();            
            _translationCharacterController = new TranslationCharacterController(_mockLogger.Object, _mockTranslatedRandomBio.Object);
        }

        [Test]
        public async Task Get_ShouldReturnTranslatedViewResponseResult()
        {
            // Arrange

            var characterBio = new CharacterBioModel { Name = "Spiderman", Bio = "Was punctured by a spider" };
            _mockTranslatedRandomBio!.Setup(s => s.GetTranslatedRandomBio()).Returns(Task.FromResult(characterBio));

            //Act

            ActionResult? actionResult = await _translationCharacterController!.Get() as ActionResult;

            // Assert

            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsInstanceOf<TranslatedViewResponse>(((OkObjectResult?)actionResult)!.Value);
        }
    }
}