using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisApp.Views;

public partial class Main : ContentPage
{
    public Main()
    {
        InitializeComponent();
    }
    private async void OnNavigateButtonClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new Gif());
    }
    
}