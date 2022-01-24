using LogYourself.ViewModels.Logs;

namespace LogYourself.Views
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