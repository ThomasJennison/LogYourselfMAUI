using LogYourself.ViewModels.Logs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace LogYourself.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealsPage : ContentPage
    {
        public MealsPage()
        {
            InitializeComponent();
            BindingContext = new MealsViewModel();
        }
    }
}