using System.Collections.Generic;
using Expm.Core.Expense;

namespace Expm.Application.Models
{
    public class IndexModel
    {
        public IEnumerable<ExpenseDto> Expenses { get; set; }
    }
}