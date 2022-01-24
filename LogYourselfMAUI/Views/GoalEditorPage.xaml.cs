using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LogYourself.ViewModels;
namespace LogYourself.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalEditorPage : ContentPage
    {
        public GoalEditorPage(GoalEditorViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
        public GoalEditorPage()
        {
            InitializeComponent();
            BindingContext = new GoalEditorViewModel();
        }
    }
}