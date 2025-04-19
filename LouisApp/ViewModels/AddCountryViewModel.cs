using LouisApp.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace LouisApp.ViewModels
{
    public class AddCountryViewModel : INotifyPropertyChanged
    {
        private Country _newCountry;
        private readonly CountryViewModel _countryViewModel;
        private bool _isBusy;

        public Country NewCountry
        {
            get => _newCountry;
            set
            {
                if (_newCountry != value)
                {
                    _newCountry = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                    ((Command)AddCountryCommand).ChangeCanExecute();
                }
            }
        }

        public ICommand AddCountryCommand { get; }

        public AddCountryViewModel(CountryViewModel countryViewModel)
        {
            _countryViewModel = countryViewModel ?? throw new ArgumentNullException(nameof(countryViewModel));
            Debug.WriteLine($"CountryViewModel instance: {_countryViewModel.GetHashCode()}");
            
            ResetNewCountry();
            AddCountryCommand = new Command(ExecuteAddCountry, () => !IsBusy);
        }

        private void ResetNewCountry()
        {
            NewCountry = new Country
            {
                name = string.Empty,
                capital = string.Empty,
                currency = string.Empty,
                population = 0,
                media = new Media { flag = string.Empty }
            };
        }

        private async void ExecuteAddCountry()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (string.IsNullOrWhiteSpace(NewCountry.name) || 
                    string.IsNullOrWhiteSpace(NewCountry.capital))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Validation", "Le nom et la capitale sont requis.", "OK");
                    return;
                }
                
                var countryToAdd = new Country
                {
                    name = NewCountry.name,
                    capital = NewCountry.capital,
                    currency = NewCountry.currency,
                    population = NewCountry.population,
                    media = new Media { flag = NewCountry.media?.flag }
                };

                _countryViewModel.Countries.Insert(0,countryToAdd);
                
                Debug.WriteLine($"Country added to ViewModel: {countryToAdd.name}");

                await Application.Current.MainPage.DisplayAlert(
                    "Succès", $"Le pays {countryToAdd.name} a été ajouté avec succès!", "OK");

                ResetNewCountry();
                
                if (Application.Current.MainPage is NavigationPage navigationPage)
                {
                    await navigationPage.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding country: {ex}");
                await Application.Current.MainPage.DisplayAlert(
                    "Erreur", $"Une erreur s'est produite: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}