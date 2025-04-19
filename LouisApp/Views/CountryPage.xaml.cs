using System;
using LouisApp.Models;
using LouisApp.ViewModels;
using LouisApp.Views.Modals;
using System.Diagnostics;

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
        
        // Désélectionner l'item après la navigation
        if (sender is ListView listView)
        {
            listView.SelectedItem = null;
        }
    }
    
    private async void OnAddCountryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCountryPage());
    }
}