using LogYourself.ViewModels.Logs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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