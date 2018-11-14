using Expm.Core.Expense;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    internal sealed class ExpenseEntryType : ObjectGraphType<ExpenseEntryDto>
    {
        public ExpenseEntryType()
        {
            Field(x => x.Id);
            Field(x => x.Description, nullable: true);
            Field(x => x.Name);
            Field(x => x.Date);
            Field(x => x.Cost);
        }
    }
}