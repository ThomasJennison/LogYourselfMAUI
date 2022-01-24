using LogYourself.Models;
using LogYourself.ViewModels;

namespace LogYourselfMAUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyTrendsPage : ContentPage
    {
        private readonly DailyTrendsViewModel view_model;

        public DailyTrendsPage()
        {
            InitializeComponent();
            BindingContext = view_model = new DailyTrendsViewModel();
            view_model.TrendsUpdated += View_model_TrendsUpdated;
        }

        private void View_model_TrendsUpdated(object sender, DailyTrendsSelectedEventArgs e)
        {
            List<OccuranceModel> selectedTrendOccurances = e.SelectedTrend.Occurances;
            List<ChartEntry> chartItems = new List<ChartEntry>();
            foreach (OccuranceModel occurance in selectedTrendOccurances)
            {
                chartItems.Add(
                    new ChartEntry((float)occurance.Ammount)
                    {
                        Label = occurance.Time.ToString("h:m:tt"),
                        ValueLabel = occurance.Ammount.ToString("0.00"),
                        Color = SKColor.Parse(occurance.Ammount < 5 ? "#ff3f38" : "#65fa43")
                    });
            }

            LineChart chart = new LineChart { Entries = chartItems.Count > 0 ? chartItems.ToArray() : null };
            chartView.Chart = chart;
        }
    }
}