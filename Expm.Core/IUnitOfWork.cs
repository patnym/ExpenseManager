using System.Threading;
using System.Threading.Tasks;
using Expm.Core.Expense;

namespace Expm.Core
{
    public interface IUnitOfWork
    {
        IExpenseRepository Expenses { get; set; } 

        Task<int> CompleteAsync(CancellationToken token = default(CancellationToken));
    }
}