using System.Collections.Generic;
using Expm.Core.Expense;
using MediatR;

namespace Expm.Core.Expense.Queries.GetAllExpenses
{
    public class GetAllExpensesQuery : IRequest<List<ExpenseDto>>
    {
        
    }
}