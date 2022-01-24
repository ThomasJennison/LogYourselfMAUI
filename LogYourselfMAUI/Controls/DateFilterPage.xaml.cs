using System.Collections.ObjectModel;

namespace LogYourself.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateFilterPage : ContentView
    {
        public ObservableCollection<DateViewModel> DaysInRange
        {
            get { return (ObservableCollection<DateViewModel>)GetValue(DaysInRangeProperty); }
            set { SetValue(DaysInRangeProperty, value); }
        }

        public static readonly BindableProperty DaysInRangeProperty = BindableProperty.Create(
                               propertyName: nameof(DaysInRange),
                               returnType: typeof(ObservableCollection<DateViewModel>),
                               declaringType: typeof(DateFilterPage),
                               defaultValue: new ObservableCollection<DateViewModel>(),
                               defaultBindingMode: BindingMode.TwoWay);

        public bool Loading
        {
            get { return (bool)GetValue(LoadingProperty); }
            set { SetValue(LoadingProperty, value); }
        }

        public static readonly BindableProperty LoadingProperty = BindableProperty.Create(
                               propertyName: nameof(Loading),
                               returnType: typeof(bool),
                               declaringType: typeof(DateFilterPage),
                               defaultValue: false,
                               defaultBindingMode: BindingMode.TwoWay);

        public DateViewModel SelectedDateTime
        {
            get { return (DateViewModel)GetValue(SelectedDateTimeProperty); }
            set { SetValue(SelectedDateTimeProperty, value); }
        }

        public static readonly BindableProperty SelectedDateTimeProperty = BindableProperty.Create(
                               propertyName: nameof(SelectedDateTime),
                               returnType: typeof(DateViewModel),
                               declaringType: typeof(DateFilterPage),
                               defaultValue: new DateViewModel(DateTime.Now),
                               defaultBindingMode: BindingMode.TwoWay);

        public string SelectedMonth
        {
            get { return (string)GetValue(SelectedMonthProperty); }
            set { SetValue(SelectedMonthProperty, value); }
        }

        public static readonly BindableProperty SelectedMonthProperty = BindableProperty.Create(
                               propertyName: nameof(SelectedMonth),
                               returnType: typeof(string),
                               declaringType: typeof(DateFilterPage),
                               defaultValue: "May",
                               defaultBindingMode: BindingMode.TwoWay);

        public string SelectedYear
        {
            get { return (string)GetValue(SelectedYearProperty); }
            set { SetValue(SelectedYearProperty, value); }
        }

        public static readonly BindableProperty SelectedYearProperty = BindableProperty.Create(
                               propertyName: nameof(SelectedYear),
                               returnType: typeof(string),
                               declaringType: typeof(DateFilterPage),
                               defaultValue: "2021",
                               defaultBindingMode: BindingMode.TwoWay);

        public string PageTitle
        {
            get { return (string)GetValue(PageTitleProperty); }
            set { SetValue(PageTitleProperty, value); }
        }

        public static readonly BindableProperty PageTitleProperty = BindableProperty.Create(
                               propertyName: nameof(PageTitle),
                               returnType: typeof(string),
                               declaringType: typeof(DateFilterPage),
                               defaultValue: "Logs",
                               defaultBindingMode: BindingMode.TwoWay);

        public Command BackCommand
        {
            get { return (Command)GetValue(BackCommandProperty); }
            set { SetValue(BackCommandProperty, value); }
        }

        public static readonly BindableProperty BackCommandProperty = BindableProperty.Create(
                               propertyName: nameof(BackCommand),
                               returnType: typeof(Command),
                               declaringType: typeof(DateFilterPage),
                               defaultValue: new Command(async () => await Pop()),
                               defaultBindingMode: BindingMode.TwoWay);

        public bool DateFilterVisibility
        {
            get { return (bool)GetValue(DateFilterVisibilityProperty); }
            set { SetValue(DateFilterVisibilityProperty, value); }
        }

        public static readonly BindableProperty DateFilterVisibilityProperty = BindableProperty.Create(
                               propertyName: nameof(DateFilterVisibility),
                               returnType: typeof(bool),
                               declaringType: typeof(DateFilterPage),
                               defaultValue: false,
                               defaultBindingMode: BindingMode.TwoWay);

        public DateFilterPage()
        {
            InitializeComponent();
            BackCommand = new Command(async () => await Pop());
        }

        private static async Task Pop() => await Shell.Current.GoToAsync("..");
    }
}