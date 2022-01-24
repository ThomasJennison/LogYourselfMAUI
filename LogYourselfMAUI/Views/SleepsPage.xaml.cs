using LogYourself.ViewModels.Logs;

namespace LogYourself.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SleepsPage : ContentPage
    {
        public SleepsPage()
        {
            InitializeComponent();
            BindingContext = new SleepsViewModel();
        }
    }
}