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
    }
}