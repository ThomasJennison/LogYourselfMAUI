﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LogYourself.ViewModels;
namespace LogYourself.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
        }
    }
}