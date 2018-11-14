using System.Collections.Generic;
using Expm.Core;

namespace Expm.Core.Expense 
{
    public class ExpenseEntity : BaseEntity
    {
        public ExpenseEntity()
        {
            ExpenseEntries = new List<ExpenseEntryEntity>();
        }

        public string Name { get; set; }

        public virtual List<ExpenseEntryEntity> ExpenseEntries { get; private set; }
    }
}