using Expm.Core.Exepense;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    public class ExpenseType : ObjectGraphType<ExpenseDto>
    {

        public ExpenseType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}