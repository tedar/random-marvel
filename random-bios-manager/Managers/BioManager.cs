using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace random_bios_manager.Managers
{
    public class BioManager : IBioManager
    {
        private readonly IConfiguration _configuration;

        public BioManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        async Task<string?> IBioManager.GetRandomBio()
        {
            var houseOfMComicId = "251";
            string endpoint = $"events/{houseOfMComicId}/characters";
            var charactersByEvent = await GETAsync<CharactersByEventResponseModel>(endpoint);
            
            int? numCharacters = charactersByEvent?.Data?.Results?.Length;

            if (numCharacters == null)
            {
                throw new Exception("No characters found");
            }

            // Most of the characters doesn't have a bio (empty description)
            // We'll pick among those who have it

            var charactersWithBio = charactersByEvent?.Data?.Results?.Where(c => !string.IsNullOrEmpty(c.Description)).ToList();            

            int count = charactersWithBio?.Count ?? 0;

            if (charactersWithBio == null || charactersWithBio?.Count == 0)
            {
                throw new Exception("No characters with bio found");
            }

            // Now we have am array of all the characters with bio. Just pick one of them.

            Random random = new();

            int randomIndex = random.Next(0, count);

            return charactersWithBio?[randomIndex].Description;
        }

        private static string GetMd5Hash(string input)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2")); // Marvel auth requires hexadecimal string
            }

            return builder.ToString();
        }

        private async Task<T?> GETAsync<T>(string endpointURL)
        {
            using HttpClient client = new();
            var baseUrl = _configuration["MarvelAPI:BaseUrl"] ?? "";
            var privateKey = _configuration["MarvelAPI:PrivateKey"] ?? "";
            var publicKey = _configuration["MarvelAPI:PublicKey"] ?? "";

            client.DefaultRequestHeaders.Add("User-Agent", _configuration["HttpClient:UserAgent"]);

            string ts = DateTime.Now.Ticks.ToString();
            string hash = GetMd5Hash(ts + privateKey + publicKey);
            string url = $"{baseUrl}{endpointURL}?apikey={publicKey}&ts={ts}&hash={hash}";

            var json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
