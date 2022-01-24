using LogYourself.ViewModels.Logs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace LogYourself.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubstancesPage : ContentPage
    {
        public SubstancesPage()
        {
            InitializeComponent();
            BindingContext = new SubstancesViewModel();
        }

        public SubstancesPage(SubstanceViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}