namespace LogYourselfMAUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryTemplate : ContentView
    {
        public string EntryItem
        {
            get => (string)GetValue(EntryItemProperty);
            set => SetValue(EntryItemProperty, value);
        }

        // Using a DependencyProperty as the backing store for HeaderText.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty EntryItemProperty =
            BindableProperty.Create(nameof(EntryItem), typeof(string), typeof(HeaderBlock), default(string));

        public EntryTemplate()
        {
            InitializeComponent();
        }
    }
}