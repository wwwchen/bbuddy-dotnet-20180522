using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOOS_Sample.Models;
using GOOS_Sample.Repo;
using GOOS_Sample.Services;
using NUnit.Framework;

namespace GOOS_SampleTests.Services
{
    [TestFixture]
    public class BudgetServiceTest
    {
        [Test]
        public void In_Same_Day()
        {
            DateRange dateRange = new DateRange(new DateTime(2018, 5, 1), new DateTime(2018, 5, 1));
            var budgetService = GetBudgetService(CreateBudgets("2018-05",310));

            var budgets = budgetService.GetTotalBudget(dateRange);

            Assert.AreEqual(10, budgets);
        }

        [Test]
        public void In_Same_Month()
        {
            DateRange dateRange = new DateRange(new DateTime(2018, 5, 1), new DateTime(2018, 5, 3));
            var budgetService = GetBudgetService(CreateBudgets("2018-05", 310));

            var budgets = budgetService.GetTotalBudget(dateRange);

            Assert.AreEqual(30, budgets);
        }

        [Test]
        public void Different_Month()
        {
            DateRange dateRange = new DateRange(new DateTime(2018, 5, 1), new DateTime(2018, 6, 3));
            var budgetService = GetBudgetService(
                CreateBudgets("2018-05", 310), 
                CreateBudgets("2018-06", 600));

            var budgets = budgetService.GetTotalBudget(dateRange);

            Assert.AreEqual(370, budgets);
        }

        [Test]
        public void Different_Month_And_MonthBudget_Is_Null()
        {
            DateRange dateRange = new DateRange(new DateTime(2018, 5, 1), new DateTime(2018, 7, 3));
            var budgetService = GetBudgetService(
                CreateBudgets("2018-05", 310),
                CreateBudgets("2018-07", 620));

            var budgets = budgetService.GetTotalBudget(dateRange);

            Assert.AreEqual(370, budgets);
        }

        [Test]
        public void Different_Year()
        {
            DateRange dateRange = new DateRange(new DateTime(2018, 12, 1), new DateTime(2019, 1, 31));
            var budgetService = GetBudgetService(
                CreateBudgets("2018-12", 310),
                CreateBudgets("2019-01", 620));

            var budgets = budgetService.GetTotalBudget(dateRange);

            Assert.AreEqual(930, budgets);
        }

        [Test]
        public void No_Budget()
        {
            DateRange dateRange = new DateRange(new DateTime(2018, 5, 1), new DateTime(2018, 5, 3));
            var budgetService = GetBudgetService();

            var budgets = budgetService.GetTotalBudget(dateRange);

            Assert.AreEqual(0, budgets);
        }

        private Budgets CreateBudgets(string yearMonth, int amount)
        {
            return new Budgets() { YearMonth = yearMonth, Amount = amount };
        }

        private IBudgetService GetBudgetService(params Budgets[] budgets)
        {
            IBudgetRepo mockRepo = new MockRepo(budgets.ToList());
            IBudgetService budgetService = new BudgetService(mockRepo);
            return budgetService;
        }


        internal class MockRepo : IBudgetRepo
        {
            private IList<Budgets> _budgets;

            public MockRepo(IList<Budgets> budgets)
            {
                _budgets = budgets;
            }

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
                return _budgets.ToList();
            }
        }
    }

}
