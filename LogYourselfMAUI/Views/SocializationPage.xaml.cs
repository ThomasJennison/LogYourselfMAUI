using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LogYourself.ViewModels.Logs;
namespace LogYourself.Views
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