using LogYourself.ViewModels.Logs;

namespace LogYourselfMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocializationPage : ContentPage
    {
        public SocializationPage(SocializationViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        public SocializationPage()
        {
            InitializeComponent();
            BindingContext = new SocializationViewModel();
        }
    }
}