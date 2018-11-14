using System;
using Expm.Core.Expense;

namespace Expm.Tests.Unit.Core.Expense
{
    public class TestExpenseSeeder
    {
        public static ExpenseEntity SeedExpense() {
            return new ExpenseEntity {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
        }

        public static ExpenseEntryEntity SeedExpenseEntry() {
            return new ExpenseEntryEntity {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Date = DateTime.UtcNow,
                Description = Guid.NewGuid().ToString(),
                Cost = 100
            };
        }
    }
}