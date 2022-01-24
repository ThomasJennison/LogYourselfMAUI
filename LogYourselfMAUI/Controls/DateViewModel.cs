﻿using LogYourself.ViewModels;

namespace LogYourself.Controls
{
    public class DateViewModel : BaseViewModel
    {
        private DateTime _date;

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public DateViewModel(DateTime date)
        {
            Date = date;
        }
    }
}