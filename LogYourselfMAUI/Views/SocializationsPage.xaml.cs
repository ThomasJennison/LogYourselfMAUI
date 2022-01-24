using LogYourself.ViewModels.Logs;

namespace LogYourselfMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocializationsPage : ContentPage
    {
        public SocializationsPage()
        {
            InitializeComponent();
            BindingContext = new SocializationsViewModel();
        }
    }
}