namespace LogYourselfMAUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderBlock : ContentView
    {
        public HeaderBlock()
        {
            InitializeComponent();
        }

        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for HeaderText.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty HeaderTextProperty =
            BindableProperty.Create("HeaderText", typeof(string), typeof(HeaderBlock), default(string));
    }
}