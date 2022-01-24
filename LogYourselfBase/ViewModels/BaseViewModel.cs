using LogYourself.Models;
using LogYourself.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogYourself.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IDatabaseService _database;

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { _ = SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { _ = SetProperty(ref title, value); }
        }

        public Command BackCommand { get; set; }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        public BaseViewModel(IDatabaseService db = null)
        {
            _database = db ?? DependencyService.Get<IDatabaseService>();
            BackCommand = new Command(async () =>
            {
                try
                {
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    await Shell.Current.GoToAsync("//MainPage");
                }
            });
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        // This will pop the current page off the navigation stack
        // await Shell.Current.GoToAsync("..");
        // await Shell.Current.GoToAsync(nameof(NewItemPage));

        // This will push the ItemDetailPage onto the navigation stack
        // await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");

        // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        // await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
    }
}
