using Expm.Core.Expense.Commands.CreateExpenseEntry;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    internal sealed class ExpenseEntryInputType : InputObjectGraphType<CreateExpenseEntryCommand>
    {

        public ExpenseEntryInputType()
        {
            Field(x => x.ExpenseId);
            Field(x => x.Name);
            Field(x => x.Description, nullable: true);
            Field(x => x.Date);
            Field(x => x.Cost);
        }
    }
}