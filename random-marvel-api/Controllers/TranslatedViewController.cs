using Microsoft.AspNetCore.Mvc;
using random_marvel_api.Views.Response;

namespace random_marvel_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationCharacterController : ControllerBase
    {
        private readonly ILogger<TranslationCharacterController> _logger;

        public TranslationCharacterController(ILogger<TranslationCharacterController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "bio/random")]
        [ProducesResponseType(typeof(TranslatedViewResponse), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return new OkObjectResult(
                new TranslatedViewResponse { Bio = "Capitán america estuvo congelado durante décadas" });
        }
    }
}