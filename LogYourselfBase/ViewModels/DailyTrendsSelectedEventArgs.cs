using LogYourself.Models;
using System;
using System.Collections.Generic;

namespace LogYourself.ViewModels
{
    public class DailyTrendsSelectedEventArgs : EventArgs
    {
        public TrendModel SelectedTrend { get; set; }
    }
}