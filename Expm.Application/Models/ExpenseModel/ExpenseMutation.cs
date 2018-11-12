using AutoMapper;
using Expm.Core;
using Expm.Core.Exepense.Commands;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    public class ExpenseMutation : ObjectGraphType
    {
        public ExpenseMutation(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Name = "CreateExpenseMutation";

            FieldAsync<ExpenseType>(
                name: "createExpense",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ExpenseInputType>> { Name = "expense" }
                ),
                resolve: async (ctx) => {
                    var input  = ctx.GetArgument<ExpenseInputType>("expense");
                    var cmd = new CreateExpenseCommand {
                        Name = input.Name
                    };
                    return await new CreateExpenseCommandHandler(unitOfWork, mapper).Handle(cmd);
                }
            );
        }
    }
}