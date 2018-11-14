using System;
using MediatR;

namespace Expm.Core.Expense.Commands.CreateExpenseEntry
{
    public class CreateExpenseEntryCommand : IRequest<ExpenseDto>
    {
        public string ExpenseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
    }
}