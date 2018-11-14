using Expm.Core.Expense;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    internal sealed class ExpenseType : ObjectGraphType<ExpenseDto>
    {

        public ExpenseType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field<ListGraphType<ExpenseEntryType>>(
                name: "expenses",
                resolve: context => context.Source.ExpenseEntries
            );
        }
    }
}