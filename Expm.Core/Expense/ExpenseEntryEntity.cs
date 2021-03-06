
using System;

namespace Expm.Core.Expense 
{

    public class ExpenseEntryEntity : BaseEntity 
    {
        public ExpenseEntryEntity() 
        {
            Description = "";
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
    }

}