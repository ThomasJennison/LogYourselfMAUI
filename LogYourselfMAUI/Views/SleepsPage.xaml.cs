using LogYourself.ViewModels.Logs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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