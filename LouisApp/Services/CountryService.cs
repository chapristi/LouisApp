using System.Diagnostics;
using LouisApp.Models;
using Newtonsoft.Json;

namespace LouisApp.Services
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Country[]> GetCountriesAsync()
        {
            var url = "https://api.sampleapis.com/countries/countries";
            var response = await _httpClient.GetStringAsync(url);
            
            var countries = JsonConvert.DeserializeObject<Country[]>(response);
            return countries;
        }
    }
}