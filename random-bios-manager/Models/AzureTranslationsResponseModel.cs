using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_manager.Models
{
    internal class AzureTranslationsResponseModel
    {
        [JsonProperty("translations")]
        public AzureTranslationsResponseTranslationModel[]? Translations { get; set; }

    }

    internal class AzureTranslationsResponseTranslationModel
    {
        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("to")]
        public string? To { get; set; }
    }
}
