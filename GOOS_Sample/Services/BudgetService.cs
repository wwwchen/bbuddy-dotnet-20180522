using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Models;
using GOOS_Sample.Repo;

namespace GOOS_Sample.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepo _repo;

        public BudgetService(IBudgetRepo repo)
        {
            _repo = repo;
        }
        
        public void Save(Budgets budgets)
        {
            throw new NotImplementedException();
        }

        public List<Budgets> GetBudgets()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalBudget(DateRange dateRange)
        {
            decimal totalBudget = 0;
            var allBudgets = _repo.GetBudgets();
            if (dateRange.isSameYearMonth())
            {
                totalBudget += currentYearMonthBudget(dateRange, allBudgets);
            }
            else
            {
                if(!dateRange.StartDateIsOneSt())
                    totalBudget += StartYearMonthBudget(dateRange, allBudgets);

                var includedYearMonthBudgets = allBudgets.Where(x => dateRange.CheckIncludedYearMonth<bool>(x.YearMonth));
                foreach (var yearMonthBudget in includedYearMonthBudgets)
                {
                    totalBudget += yearMonthBudget.Amount;
                }

                if(!dateRange.EndDateIsEndOfMonth())
                    totalBudget += EndYearMonthBudget(dateRange, allBudgets);
            }

            return totalBudget;
        }

        private decimal currentYearMonthBudget(DateRange dateRange, List<Budgets> allBudgets)
        {
            decimal totalBudget = 0;
            var currentYearMonthBudgets = allBudgets.Where(x => x.YearMonth == dateRange.startYearMonth());
            if (currentYearMonthBudgets.Count() != 0)
            {
                totalBudget = GetSameMonthBudget(dateRange.StartDate, dateRange.EndDate, currentYearMonthBudgets.First().Amount);
            }

            return totalBudget;
        }

        private decimal StartYearMonthBudget(DateRange dateRange, List<Budgets> allBudgets)
        {
            decimal totalBudget = 0;
            var currentYearMonthBudgets = allBudgets.Where(x => x.YearMonth == dateRange.startYearMonth());
            if (currentYearMonthBudgets.Count() != 0)
            {
                totalBudget = GetSameMonthBudget(dateRange.StartDate, dateRange.EndMonthOfStartDate(), currentYearMonthBudgets.First().Amount);
            }

            return totalBudget;
        }

        private decimal EndYearMonthBudget(DateRange dateRange, List<Budgets> allBudgets)
        {
            decimal totalBudget = 0;
            var currentYearMonthBudgets = allBudgets.Where(x => x.YearMonth == dateRange.endYearMonth());
            if (currentYearMonthBudgets.Count() != 0)
            {
                totalBudget = GetSameMonthBudget(dateRange.BeginningMonthOfEndDate(), dateRange.EndDate, currentYearMonthBudgets.First().Amount);
            }

            return totalBudget;
        }

        private decimal GetSameMonthBudget(DateTime startDate, DateTime endDate, decimal yearMonthBudget)
        {
            return (decimal)(yearMonthBudget / DateTime.DaysInMonth(startDate.Year, startDate.Month)) * ((endDate - startDate).Days + 1);
        }
    }
}