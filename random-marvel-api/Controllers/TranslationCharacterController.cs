
namespace random_marvel_api.Controllers
{
    [ApiController]
    [Route("translate/marvel-characters/bios/random")]
    public class TranslationCharacterController : ControllerBase
    {
        private readonly ILogger<TranslationCharacterController> _logger;
        private readonly ITranslatedRandomBio _translatedRandomBio;

        public TranslationCharacterController(
            ILogger<TranslationCharacterController> logger, 
            ITranslatedRandomBio translatedRandomBio)
        {
            _logger = logger;
            _translatedRandomBio = translatedRandomBio;
        }

        [HttpGet(Name = "bio/random")]
        [ProducesResponseType(typeof(TranslatedViewResponse), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(
                new TranslatedViewResponse { Bio = await _translatedRandomBio.GetTranslatedRandomBio() });
        }
    }
}