using Expm.Core.Exepense.Queries;
using GraphQL.Types;
using MediatR;

namespace Expm.Application.Models.ExpenseModel
{
    public class ExpenseQuery : ObjectGraphType
    {
        
        public ExpenseQuery(IMediator mediator)
        {
            FieldAsync<ExpenseType>(
                "expense",
                "Get a specific expense",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id" }
                ),
                resolve: async (ctx) => {
                    return await mediator.Send(new GetExpenseQuery(ctx.GetArgument<string>("id")));
                }
            );

            FieldAsync<ListGraphType<ExpenseType>>(
                "expenses",
                "Get all expenses",
                resolve: async ctx => {
                    return await mediator.Send(new GetAllExpensesQuery());
                }
            );
        }

    }
}