using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Models;

namespace GOOS_Sample.Repo
{
    public class BudgetRepo : IBudgetRepo
    {
        public void UpdateBudget(Budgets budget)
        {
            throw new NotImplementedException();
        }

        public void AddBudget(Budgets newBudget)
        {
            throw new NotImplementedException();
        }

        public Budgets FindBudgetByMonth(string modelMonth)
        {
            throw new NotImplementedException();
        }

        public List<Budgets> GetBudgets()
        {
            throw new NotImplementedException();
        }

        public decimal GetYearMonthBudget(int year, int month)
        {
            throw new NotImplementedException();
        }
    }
}