using LouisApp.Models;
using LouisApp.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LouisApp.ViewModels
{
    public class CountryViewModel : INotifyPropertyChanged
    {
        private readonly CountryService _countryService;
        private ObservableCollection<Country> _countries;
        private static CountryViewModel _countryViewModel;


        public ObservableCollection<Country> Countries
        {
            get => _countries;
            set
            {
                if (_countries != value)
                {
                    if (_countries != null)
                    {
                        _countries.CollectionChanged -= Countries_CollectionChanged;
                    }
                    
                    _countries = value;
                    
                    if (_countries != null)
                    {
                        _countries.CollectionChanged += Countries_CollectionChanged;
                    }
                    
                    OnPropertyChanged();
                }
            }
        }

        private void Countries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Cette méthode est appelée chaque fois que la collection change
            Debug.WriteLine($"Collection changed: {e.Action}");
        }

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
            foreach (Country country in countries.Take(50))
            {
                Countries.Add(country);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}