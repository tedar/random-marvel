
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Get random marvel character bio translated to spanish", 
            Description = "You will only get characters appearing in the House of M series that include any biography in the Marvel API.")]
        [SwaggerResponse(200, "OK", typeof(TranslatedViewResponse))]
        [SwaggerResponse(500, "Internal error", typeof(void))]
        public async Task<IActionResult> Get()
        {
            var characterBio = await _translatedRandomBio.GetTranslatedRandomBio();

            var response = new TranslatedViewResponse { Name = characterBio.Name, Bio = characterBio.Bio };

            return new OkObjectResult(response);
        }
    }
}