using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    public class ExpenseInputType : InputObjectGraphType
    {
        
        public ExpenseInputType()
        {
            Name = "ExpenseInput";
            Field<StringGraphType>(
                "name",
                "Name of the expense"
            );
        }

    }
}