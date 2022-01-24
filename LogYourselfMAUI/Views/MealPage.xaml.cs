using LogYourself.ViewModels.Logs;

namespace LogYourselfMAUI.Views
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