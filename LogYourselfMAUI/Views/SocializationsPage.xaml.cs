using LogYourself.ViewModels.Logs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace LogYourself.Views
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