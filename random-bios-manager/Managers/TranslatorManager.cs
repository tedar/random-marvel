using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_manager.Managers
{
    public class TranslatorManager : ITranslatorManager
    {
        private readonly IConfiguration _configuration;

        public TranslatorManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        async Task<string> ITranslatorManager.Translate(string text)
        {
            var baseURL = _configuration["AzureTranslator:BaseUrl"] ?? "";
            var region = _configuration["AzureTranslator:Region"] ?? "";
            var key1 = _configuration["AzureTranslator:Key1"] ?? "";
            var endpointURL = "/translate?api-version=3.0&from=en&to=es";

            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key1);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", region);

            var response = await client.PostAsync(baseURL + endpointURL, new StringContent(requestBody, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error when requesting translation:{response.StatusCode}:{errorMessage}");
            }

            var json = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<AzureTranslationsResponseModel[]>(json);
            return obj?[0]?.Translations?.Where(t => t.To == "es").ToList()[0]?.Text ?? "";
        }      
    }
}
