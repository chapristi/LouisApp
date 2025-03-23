using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisApp.ViewModels;

namespace LouisApp.Views;

public partial class CountryPage : ContentPage
{
    public CountryPage()
    {
        InitializeComponent();
        
        BindingContext = new CountryViewModel();
    }
}