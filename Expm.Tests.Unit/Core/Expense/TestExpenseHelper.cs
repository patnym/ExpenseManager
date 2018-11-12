using Expm.Core.Expense;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense
{
    public static class TestExpenseHelper
    {
        public static void AssertEntityMatchesDto(ExpenseEntity entity, ExpenseDto dto) {
            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.Name, dto.Name);
        }

        public static bool IsEntitySameAsDto(ExpenseEntity entity, ExpenseDto dto) {
            return (entity.Id == dto.Id) &&
                (entity.Name == dto.Name);
        }
    }
}