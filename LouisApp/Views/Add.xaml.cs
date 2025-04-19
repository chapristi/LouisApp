using System;
using LouisApp.ViewModels;
using System.Diagnostics;

namespace LouisApp.Views;

public partial class AddCountryPage : ContentPage
{
    public AddCountryPage()
    {
        InitializeComponent();
        BindingContext = new AddCountryViewModel();
    }
}