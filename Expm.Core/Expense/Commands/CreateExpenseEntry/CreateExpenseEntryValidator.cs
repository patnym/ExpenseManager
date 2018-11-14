using System;
using FluentValidation;

namespace Expm.Core.Expense.Commands.CreateExpenseEntry
{
    public class CreateExpenseEntryValidator : AbstractValidator<CreateExpenseEntryCommand>
    {
        public CreateExpenseEntryValidator()
        {
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.Date).NotEqual(DateTime.MinValue);
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}