using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOOS_Sample.Models;

namespace GOOS_Sample.Repo
{
    public interface IBudgetRepo
    {
        void UpdateBudget(Budgets budget);
        void AddBudget(Budgets newBudget);
        Budgets FindBudgetByMonth(string modelMonth);
        List<Budgets> GetBudgets();
    }
}
