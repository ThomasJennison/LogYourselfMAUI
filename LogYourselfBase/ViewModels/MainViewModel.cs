using LogYourself.Models;

namespace LogYourself.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command<PageNames> NavigateCommand { get; set; }

        public MainViewModel()
        {
            NavigateCommand = new Command<PageNames>((page) => MainViewModel.Navigate(page));
        }

        private static async void Navigate(PageNames page)
        {
            await Shell.Current.GoToAsync(page.ToString());
        }
    }
}