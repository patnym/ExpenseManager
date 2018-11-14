using System;
using System.Threading;
using System.Threading.Tasks;
using Expm.Core;
using Expm.Core.Expense;

namespace Expm.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IExpenseRepository _expenses;
        public IExpenseRepository Expenses { get => _expenses ?? new ExpenseRepository(); set { _expenses = value; } }

        public async Task<int> CompleteAsync(CancellationToken token = default(CancellationToken))
        {
            var exp = await Expenses.AllAsync();
            foreach(var item in exp)
            {
                item.ExpenseEntries.ForEach(en => {
                    if(string.IsNullOrEmpty(en.Id)) {
                        en.Id = Guid.NewGuid().ToString();
                    }
                });
            }

            return 0;
        }
    }
}
