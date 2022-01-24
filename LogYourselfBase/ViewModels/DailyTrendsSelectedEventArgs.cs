using LogYourself.Models;

namespace LogYourself.ViewModels
{
    public class DailyTrendsSelectedEventArgs : EventArgs
    {
        public TrendModel SelectedTrend { get; set; }
    }
}