using System.Collections.Generic;
using Expm.Core.Expense;
using MediatR;

namespace Expm.Core.Exepense.Queries
{
    public class GetAllExpensesQuery : IRequest<List<ExpenseDto>>
    {
        
    }
}