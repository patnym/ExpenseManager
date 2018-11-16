using Expm.Core.Expense.Commands.CreateExpense;
using Expm.Core.Expense.Commands.CreateExpenseEntry;
using GraphQL.Types;
using MediatR;

namespace Expm.Application.Models.ExpenseModel
{
    internal sealed class ExpenseMutation : ObjectGraphType
    {
        public ExpenseMutation(IMediator _mediator)
        {
            Name = "CreateExpenseMutation";

            FieldAsync<ExpenseType>(
                name: "createExpense",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ExpenseInputType>> { Name = "expense" }
                ),
                resolve: async (ctx) => {
                    var cmd  = ctx.GetArgument<CreateExpenseCommand>("expense");
                    return await _mediator.Send(cmd);
                }
            );

            FieldAsync<ExpenseType>(
                name: "addExpenseEntry",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ExpenseEntryInputType>> { Name = "entry"}
                ),
                resolve: async (ctx) => {
                    var cmd = ctx.GetArgument<CreateExpenseEntryCommand>("entry");
                    return await _mediator.Send(cmd);
                }
            );
        }
    }
}