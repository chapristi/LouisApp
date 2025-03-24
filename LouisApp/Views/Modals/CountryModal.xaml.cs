using System;
using LouisApp.Models;

namespace LouisApp.Views.Modals;

public partial class CountryModal : ContentPage
{
    public CountryModal(Country country)
    {
        InitializeComponent();
        BindingContext = country;
    }
    
    private async void OnCloseModalClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}