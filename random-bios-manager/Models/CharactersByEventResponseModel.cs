using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_manager.Models
{
    internal class CharactersByEventResponseModel
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("data")]
        public CharactersByEventResponseDataModel? Data { get; set; }

    }

    internal class CharactersByEventResponseDataModel
    {
        [JsonProperty("results")]
        public CharactersByEventResponseDataResultsModel[]? Results { get; set; }
    }

    internal class CharactersByEventResponseDataResultsModel
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }

    }
}
