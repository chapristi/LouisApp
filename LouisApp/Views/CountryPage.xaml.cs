using System;
using LouisApp.Models;
using LouisApp.ViewModels;
using LouisApp.Views.Modals;

namespace LouisApp.Views;

public partial class CountryPage : ContentPage
{
    public CountryPage()
    {
        InitializeComponent();
        BindingContext = new CountryViewModel();
    }
    
    private async void OnCountrySelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;
            
        var country = e.SelectedItem as Country;
        var modal = new CountryModal(country);
        await Navigation.PushModalAsync(modal);
    }
}