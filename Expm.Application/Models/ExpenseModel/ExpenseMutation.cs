using Expm.Core.Expense.Commands;
using GraphQL.Types;
using MediatR;

namespace Expm.Application.Models.ExpenseModel
{
    public class ExpenseMutation : ObjectGraphType
    {
        public ExpenseMutation(IMediator mediator)
        {
            Name = "CreateExpenseMutation";

            FieldAsync<ExpenseType>(
                name: "createExpense",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ExpenseInputType>> { Name = "expense" }
                ),
                resolve: async (ctx) => {
                    var input  = ctx.GetArgument<ExpenseInputType>("expense");
                    return await mediator.Send(new CreateExpenseCommand {
                        Name = input.Name
                    });
                }
            );
        }
    }
}