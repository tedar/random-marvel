using Newtonsoft.Json;

namespace random_marvel_api.Views.Response
{
    public class TranslatedViewResponse
    {
        [JsonProperty("bio")]
        public string? Bio { get; set; }
    }
}
