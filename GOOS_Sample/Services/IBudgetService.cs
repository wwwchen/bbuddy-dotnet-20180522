using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Models;

namespace GOOS_Sample.Services
{
    public interface IBudgetService
    {
        void Save(Budgets budgets);
        List<Budgets> GetBudgets();
        decimal GetTotalBudget(DateRange dateRange);
    }
}