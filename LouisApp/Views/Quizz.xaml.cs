using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisApp.Models;
using LouisApp.ViewModels;
using LouisApp.Views.Modals;

namespace LouisApp.Views;

public partial class Quizz : ContentPage
{
    public Quizz()
    {
        InitializeComponent();
        BindingContext = new QuizzViewModel();
    }
 
}