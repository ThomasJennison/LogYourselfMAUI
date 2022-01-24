using LogYourself.ViewModels.Logs;

namespace LogYourselfMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoodPage : ContentPage
    {
        public MoodPage(MoodViewModel mood)
        {
            InitializeComponent();
            BindingContext = mood;
        }

        public MoodPage()
        {
            InitializeComponent();
            BindingContext = new MoodViewModel();
        }
    }
}