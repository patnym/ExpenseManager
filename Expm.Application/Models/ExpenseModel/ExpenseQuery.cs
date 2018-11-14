using Expm.Core.Expense.Queries;
using GraphQL.Types;
using MediatR;

namespace Expm.Application.Models.ExpenseModel
{
    internal sealed class ExpenseQuery : ObjectGraphType
    {
        
        public ExpenseQuery(IMediator _mediator)
        {
            FieldAsync<ExpenseType>(
                "expense",
                "Get a specific expense",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id" }
                ),
                resolve: async (ctx) => {
                    return await _mediator.Send(new GetExpenseQuery(ctx.GetArgument<string>("id")));
                }
            );

            FieldAsync<ListGraphType<ExpenseType>>(
                "expenses",
                "Get all expenses",
                resolve: async ctx => {
                    return await _mediator.Send(new GetAllExpensesQuery());
                }
            );
        }

    }
}