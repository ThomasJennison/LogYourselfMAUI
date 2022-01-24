using LogYourself.Models.Base;

namespace LogYourselfMAUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogView : ContentView
    {
        public LogView()
        {
            InitializeComponent();
        }

        #region Title

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                               propertyName: nameof(Title),
                               returnType: typeof(string),
                               declaringType: typeof(LogView),
                               defaultValue: default(string));

        #endregion Title

        #region Edit Command

        public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
                               propertyName: nameof(EditCommand),
                               returnType: typeof(Command),
                               declaringType: typeof(LogView),
                               defaultValue: default(Command));

        public Command EditCommand
        {
            get => (Command)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        #endregion Edit Command

        #region Delete Command

        public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
                               propertyName: nameof(DeleteCommand),
                               returnType: typeof(Command),
                               declaringType: typeof(LogView),
                               defaultValue: default(Command));

        public Command DeleteCommand
        {
            get => (Command)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        #endregion Delete Command

        #region Add Command

        public static readonly BindableProperty AddCommandProperty = BindableProperty.Create(
                               propertyName: nameof(AddCommand),
                               returnType: typeof(Command),
                               declaringType: typeof(LogView),
                               defaultValue: default(Command));

        public Command AddCommand
        {
            get => (Command)GetValue(AddCommandProperty);
            set => SetValue(AddCommandProperty, value);
        }

        #endregion Add Command
    }
}