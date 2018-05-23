using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOOS_Sample.Services
{
    public class DateRange
    {
        private DateTime _endDate;
        private DateTime _startDate;

        public DateRange(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public DateTime StartDate
        {
            get { return _startDate; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
        }

        public bool CheckIncludedYearMonth<T>(string budgetYearMonth)
        {
            string[] budgetYearMonthSplit = budgetYearMonth.Split('-');
            
            DateTime yearMonthStart = new DateTime(int.Parse(budgetYearMonthSplit[0]), int.Parse(budgetYearMonthSplit[1]), 1);
            DateTime yearMonthEnd = yearMonthStart.AddMonths(1).AddDays(-1);

            int budgetYearMonthStart = int.Parse(yearMonthStart.ToString("yyyyMMdd"));
            int budgetYearMonthEnd = int.Parse(yearMonthEnd.ToString("yyyyMMdd"));

            int start = int.Parse(_startDate.ToString("yyyyMMdd"));
            int end = int.Parse(_endDate.ToString("yyyyMMdd"));

            return budgetYearMonthStart >= start && budgetYearMonthEnd <= end;
        }

        public bool isSameYearMonth()
        {
            return (_startDate.Month == _endDate.Month) && (_startDate.Month == _endDate.Month);
        }

        public string startYearMonth()
        {
            return _startDate.ToString("yyyy-MM");
        }

        public DateTime EndMonthOfStartDate()
        {
            return new DateTime(_startDate.Year, _startDate.Month, 1).AddMonths(1).AddDays(-1);
        }

        public string endYearMonth()
        {
            return _endDate.ToString("yyyy-MM");
        }

        public DateTime BeginningMonthOfEndDate()
        {
            return new DateTime(_endDate.Year, _endDate.Month, 1);
        }

        public bool StartDateIsOneSt()
        {
            return _startDate.Day == 1;
        }

        public bool EndDateIsEndOfMonth()
        {
            return _endDate.Day == DateTime.DaysInMonth(_endDate.Year, _endDate.Month);
        }
    }
}