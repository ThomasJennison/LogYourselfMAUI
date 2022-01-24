using LogYourself.Models;
using System.Collections.ObjectModel;

namespace LogYourself.ViewModels
{
    public class DailyTrendsViewModel : BaseViewModel
    {
        public ObservableCollection<TrendModel> Trends { get; private set; }
        private DateTime _selectedDay = DateTime.Now;
        private bool _loading;
        private string _selectedTrendLabel;
        private double _sleepForDay;

        public double SleepForDay
        {
            get => _sleepForDay;
            set => SetProperty(ref _sleepForDay, value);
        }

        private bool loadInDaySelect = false;

        public DateTime SelectedDay
        {
            get => _selectedDay;
            set
            {
                _ = SetProperty(ref _selectedDay, value);
                if (loadInDaySelect)
                {
                    LoadData().SafeFireAndForget(false);
                }
            }
        }

        public string SelectedTrendLabel
        {
            get => _selectedTrendLabel;
            set => SetProperty(ref _selectedTrendLabel, value);
        }

        public bool Loading
        {
            get => _loading;
            set => SetProperty(ref _loading, value);
        }

        public Command DateForwardCommand { get; set; }
        public Command DateBackwardCommand { get; set; }
        public Command LoadSelectedDateCommand { get; set; }

        private TrendModel _selectedTrend;

        public TrendModel SelectedTrend
        {
            get => _selectedTrend;
            set
            {
                _ = SetProperty(ref _selectedTrend, value);
                if (value != null)
                {
                    DailyTrendsSelectedEventArgs args = new DailyTrendsSelectedEventArgs
                    {
                        SelectedTrend = _selectedTrend
                    };
                    OnTrendSelected(args);
                }
            }
        }

        public event EventHandler<DailyTrendsSelectedEventArgs> TrendsUpdated;

        public DailyTrendsViewModel()
        {
            Trends = new ObservableCollection<TrendModel>();

            DateForwardCommand = new Command(async () =>
            {
                loadInDaySelect = false;
                SelectedDay = SelectedDay.AddDays(1);
                SelectedTrend = null;
                Trends.Clear();

                await LoadData();
                loadInDaySelect = true;
            });

            DateBackwardCommand = new Command(async () =>
            {
                loadInDaySelect = false;
                SelectedDay = SelectedDay.AddDays(-1);
                SelectedTrend = null;
                Trends.Clear();

                await LoadData();
                loadInDaySelect = true;
            });

            LoadData().SafeFireAndForget(true);
        }

        /// <summary>
        /// Looks at the data base and try's to pick apart information about the users habits
        /// </summary>
        /// <returns></returns>
        public async Task LoadData()
        {
            Loading = true;
            try
            {
                DateTime date = SelectedDay.Date;

                #region Filter sleep data

                List<MoodModel> moods = await _database.GetMoodsAsync(SelectedDay, SelectedDay);
                List<OccuranceModel> moodOccurances = (from MoodModel model in moods
                                                       select new OccuranceModel(model.RegisteredTime, model.OverallMood)).ToList();
                if (moodOccurances.Count > 0)
                {
                    TrendModel moodTrend = new TrendModel()
                    {
                        Occurances = moodOccurances,
                        TrendContextTotal = moodOccurances.Average(x => x.Ammount),
                        TrendContextUnit = "Average Mood",
                        TrendName = "Mood",
                        TotalOccurances = moodOccurances.Count,
                        ShowExtendedData = false,
                    };
                    Trends.Add(moodTrend);
                }

                List<SleepModel> sleepData = await _database.GetSleepsAsync(SelectedDay, SelectedDay);
                if (sleepData.Count > 0)
                {
                    SleepForDay = sleepData.Sum(x => x.TotalSleep);
                }

                #endregion Filter sleep data

                #region Pick out substances

                List<SubstanceModel> substanceData = await _database.GetSubstancesAsync(SelectedDay, SelectedDay);
                Dictionary<string, List<OccuranceModel>> substanceOccurances = new Dictionary<string, List<OccuranceModel>>();
                foreach (SubstanceModel substance in substanceData)
                {
                    OccuranceModel occurance = new OccuranceModel(substance.RegisteredTime, substance.Amount)
                    {
                        Unit = substance.Unit,
                    };

                    if (substanceOccurances.ContainsKey(substance.SubstanceName))
                    {
                        substanceOccurances[substance.SubstanceName].Add(occurance);
                    }
                    else
                    {
                        substanceOccurances.Add(substance.SubstanceName, new List<OccuranceModel>() { occurance });
                    }
                }

                foreach (List<OccuranceModel> occurances in substanceOccurances.Values)
                {
                    _ = occurances.OrderBy(x => x.Time);
                }

                foreach (KeyValuePair<string, List<OccuranceModel>> substanceOccurance in substanceOccurances)
                {
                    List<TimeSpan> timebetween = new List<TimeSpan>();
                    for (int i = 1; i < substanceOccurance.Value.Count; i++)
                    {
                        timebetween.Add(substanceOccurance.Value[i].Time - substanceOccurance.Value[i - 1].Time);
                    }

                    Trends.Add(new TrendModel
                    {
                        Occurances = substanceOccurance.Value,
                        TotalOccurances = substanceOccurance.Value.Count(),
                        FirstTime = substanceOccurance.Value.First().Time,
                        LastTime = substanceOccurance.Value.Last().Time,
                        AverageTimeBetween = timebetween.Count > 0 ? timebetween.Average(x => x.TotalHours) : 0,
                        LongestTimeBetween = timebetween.Count > 0 ? timebetween.Max().TotalHours : 0,
                        ShortestTimeBetween = timebetween.Count > 0 ? timebetween.Min().TotalHours : 0,
                        TrendContextTotal = substanceOccurance.Value.Sum(x => x.Ammount),
                        TrendContextUnit = substanceOccurance.Value.First().Unit,
                        TrendName = substanceOccurance.Key,
                        ShowExtendedData = true
                    });
                }

                #endregion Pick out substances

                #region Activity Occurrences

                List<ActivityModel> activityData = await _database.GetActivitiesAsync(SelectedDay, SelectedDay);
                Dictionary<string, List<OccuranceModel>> activityOccurances = new Dictionary<string, List<OccuranceModel>>();
                foreach (ActivityModel activity in activityData)
                {
                    OccuranceModel occurance = new OccuranceModel(activity.EndTime, activity.Duration)
                    {
                        Unit = "Hours",
                    };

                    if (activityOccurances.ContainsKey(activity.ActivityName))
                    {
                        activityOccurances[activity.ActivityName].Add(occurance);
                    }
                    else
                    {
                        activityOccurances.Add(activity.ActivityName, new List<OccuranceModel>() { occurance });
                    }
                }

                foreach (KeyValuePair<string, List<OccuranceModel>> activityOccurance in activityOccurances)
                {
                    Trends.Add(new TrendModel
                    {
                        Occurances = activityOccurance.Value,
                        TotalOccurances = activityOccurance.Value.Count(),
                        TrendContextTotal = activityOccurance.Value.Sum(x => x.Ammount),
                        TrendContextUnit = activityOccurance.Value.First().Unit,
                        TrendName = activityOccurance.Key
                    });
                }

                #endregion Activity Occurrences

                if (Trends.Count <= 0)
                {
                    DailyTrendsSelectedEventArgs noTrendArgs = new DailyTrendsSelectedEventArgs
                    {
                        SelectedTrend = new TrendModel()
                        {
                            Occurances = new List<OccuranceModel>(),
                            TotalOccurances = 0,
                        }
                    };
                    OnTrendSelected(noTrendArgs);
                    return;
                }

                DailyTrendsSelectedEventArgs args = new DailyTrendsSelectedEventArgs
                {
                    SelectedTrend = Trends.First()
                };
                OnTrendSelected(args);
            }
            finally
            {
                Loading = false;
            }
        }

        protected virtual void OnTrendSelected(DailyTrendsSelectedEventArgs e)
        {
            TrendsUpdated?.Invoke(this, e);
        }
    }
}