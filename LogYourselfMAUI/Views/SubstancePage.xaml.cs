using LogYourself.ViewModels.Logs;

namespace LogYourself.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubstancePage : ContentPage
    {
        public SubstancePage(SubstanceViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        public SubstancePage()
        {
            InitializeComponent();
            BindingContext = new SubstanceViewModel();
        }
    }
}