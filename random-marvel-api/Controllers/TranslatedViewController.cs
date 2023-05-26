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
        public TranslatedViewResponse Get()
        {       
            return new TranslatedViewResponse { Bio = "Capitán america estuvo congelado durante décadas" };
        }
    }
}