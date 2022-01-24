using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LogYourself.ViewModels.Logs;
namespace LogYourself.Views
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