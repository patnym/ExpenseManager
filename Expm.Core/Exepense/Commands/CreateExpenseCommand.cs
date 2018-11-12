using Expm.Core.Expense;
using MediatR;

namespace Expm.Core.Exepense.Commands
{
    public class CreateExpenseCommand : IRequest<ExpenseDto>
    {
        public CreateExpenseCommand()
        {
        }
        
        public string Name { get; set; }
    }
}