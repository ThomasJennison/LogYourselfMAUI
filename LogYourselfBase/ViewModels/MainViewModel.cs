using LogYourself.Views;
using Xamarin.Forms;

namespace LogYourself.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command<PageNames> NavigateCommand { get; set; }

        public MainViewModel()
        {
            NavigateCommand = new Command<PageNames>((page) => Navigate(page));
        }

        private async void Navigate(PageNames page)
        {
            await Shell.Current.GoToAsync(page.ToString());
        }
    }
}
