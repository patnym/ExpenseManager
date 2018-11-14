using System;

namespace Expm.Core.Expense
{
    public class ExpenseEntryDto
    {
        public ExpenseEntryDto()
        {
            Description = "";
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
    }
}