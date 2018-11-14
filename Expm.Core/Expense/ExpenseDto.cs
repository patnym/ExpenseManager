using System.Collections.Generic;

namespace Expm.Core.Expense
{
    public class ExpenseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ExpenseEntryDto> ExpenseEntries;
    }
}