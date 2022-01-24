using LogYourself.ViewModels.Logs;

namespace LogYourselfMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoodsPage : ContentPage
    {
        public MoodsPage()
        {
            InitializeComponent();
            BindingContext = new MoodsViewModel();
        }
    }
}