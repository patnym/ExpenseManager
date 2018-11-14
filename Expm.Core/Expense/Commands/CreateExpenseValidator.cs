using FluentValidation;

namespace Expm.Core.Expense.Commands
{
    public class CreateExpenseValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseValidator()
        {
            RuleFor(exp => exp.Name).NotNull().NotEmpty();
        }
    }
}