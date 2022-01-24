using LogYourself.ViewModels;

namespace LogYourselfMAUI.Views
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