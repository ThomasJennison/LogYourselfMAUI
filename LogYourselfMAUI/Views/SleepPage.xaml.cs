using LogYourself.ViewModels.Logs;

namespace LogYourselfMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SleepPage : ContentPage
    {
        public SleepPage(SleepViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        public SleepPage()
        {
            InitializeComponent();
            BindingContext = new SleepViewModel();
        }
    }
}