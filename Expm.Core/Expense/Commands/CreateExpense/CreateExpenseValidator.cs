using FluentValidation;

namespace Expm.Core.Expense.Commands.CreateExpense
{
    public class CreateExpenseValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseValidator()
        {
            RuleFor(exp => exp.Name).NotNull().NotEmpty();
        }
    }
}