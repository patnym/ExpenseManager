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
            return 0;
        }
    }
}
