using Expm.Core.Expense;
using Expm.Core.Expense.Commands.CreateExpense;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    internal sealed class ExpenseInputType : InputObjectGraphType<CreateExpenseCommand>
    {
        
        public ExpenseInputType()
        {
            Field(x => x.Name);
        }

    }
}