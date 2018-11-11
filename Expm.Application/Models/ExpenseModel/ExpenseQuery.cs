using Expm.Core;
using Expm.Core.Exepense.Queries;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    public class ExpenseQuery : ObjectGraphType
    {
        
        public ExpenseQuery(IUnitOfWork unitOfWork)
        {
            FieldAsync<ExpenseType>(
                "expense",
                "Represents an expense collection, like reciepts",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id" }
                ),
                resolve: async (ctx) => {
                    var cmd = new GetExpenseQuery(ctx.GetArgument<string>("id"));
                    var handlr = new GetExpenseQueryHandler(unitOfWork);
                    return await handlr.Handle(cmd);
                }
            );

            FieldAsync<ListGraphType<ExpenseType>>(
                "expenses",
                "Get all expenses",
                resolve: async ctx => {
                    var cmd = new GetAllExpensesQuery();
                    var handlr = new GetAllExpensesQueryHandler(unitOfWork);
                    return await handlr.Handle(cmd);
                }
            );
        }

    }
}