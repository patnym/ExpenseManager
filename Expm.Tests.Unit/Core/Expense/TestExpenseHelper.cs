using Expm.Core.Expense;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense
{
    public static class TestExpenseHelper
    {
        public static void AssertExpenseEntityMatchesDto(ExpenseEntity entity, ExpenseDto dto) {
            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.Name, dto.Name);
        }

        public static void AssertExpenseEntryEntityMatchesDto(ExpenseEntryEntity entity, ExpenseEntryDto dto) {
            Assert.Equal(entity.Name, dto.Name);
            Assert.Equal(entity.Cost, dto.Cost);
            Assert.Equal(entity.Date, dto.Date);
            Assert.Equal(entity.Description, dto.Description);
        }

        public static bool IsEntitySameAsDto(ExpenseEntity entity, ExpenseDto dto) {
            return (entity.Id == dto.Id) &&
                (entity.Name == dto.Name);
        }
    }
}