using LouisApp.Models;
using LouisApp.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LouisApp.ViewModels
{
    public class CountryViewModel
    {
        private readonly CountryService _countryService;
        public ObservableCollection<Country> Countries { get; set; }

        public CountryViewModel()
        {
            _countryService = new CountryService();
            Countries = new ObservableCollection<Country>();
            Task.Run(async () => 
            {
                await LoadCountriesAsync();
            });
        }

        public async Task LoadCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();

            Debug.WriteLine("Hello from .NET MAUI!");
            Debug.WriteLine(countries);
            Countries.Clear();
            foreach (Country country in countries)
            {
                Countries.Add(country);
            }
        }
    }
}