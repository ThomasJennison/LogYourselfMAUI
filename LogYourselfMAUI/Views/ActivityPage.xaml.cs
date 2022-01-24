using LogYourself.ViewModels.Logs;

namespace LogYourselfMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage(ActivityViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        public ActivityPage()
        {
            InitializeComponent();
            BindingContext = new ActivityViewModel();
        }
    }
}