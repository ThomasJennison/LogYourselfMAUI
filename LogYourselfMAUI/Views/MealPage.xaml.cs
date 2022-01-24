using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LogYourself.ViewModels.Logs;
namespace LogYourself.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealPage : ContentPage
    {
        public MealPage(MealViewModel meal)
        {
            InitializeComponent();
            BindingContext = meal;
        }

        public MealPage()
        {
            InitializeComponent();
            BindingContext = new MealViewModel();
        }
    }
}