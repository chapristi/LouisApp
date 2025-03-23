using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisApp.Models;

namespace LouisApp.Views.Modals;

public partial class CountryModal : ContentPage
{
    private readonly List<Country> _countries;

    public CountryModal(List<Country> countries)
    {
        InitializeComponent();
        _countries = countries;
        CountriesListView.ItemsSource = _countries;  

    }
    private async void OnCloseModalClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();  // Fermer le modal
    }
}