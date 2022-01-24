using LogYourself.ViewModels.Logs;

namespace LogYourselfMAUI.Views
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