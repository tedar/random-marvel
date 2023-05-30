namespace random_marvel_api.Views.Response
{
    public class TranslatedViewResponse
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("bio")]
        public string? Bio { get; set; }
    }
}
