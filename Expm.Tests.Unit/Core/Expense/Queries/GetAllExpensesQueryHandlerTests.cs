using System.Collections.Generic;
using System.Linq;
using Expm.Core;
using Expm.Core.Exepense;
using Expm.Core.Exepense.Queries;
using Expm.Core.Expense;
using Moq;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Queries
{
    public class GetAllExpensesQueryHandlerTests
    {
        private IQueryHandler<List<ExpenseDto>, GetAllExpensesQuery> _handler;
        private Mock<IExpenseRepository> _expenseRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        [Fact]
        public async void Can_retrieve_all_expenses()
        {
            //Given
            var seedAmount = 10;
            AllShouldReturn(SeedEntities(10));

            //When
            var expensesDto = await _handler.Handle(new GetAllExpensesQuery());

            //Then
            Assert.Equal(seedAmount, expensesDto.Count);
        }

        [Fact]
        public async void Dto_returned_is_valid()
        {
            //Given
            var seededEntities = SeedEntities(3);
            AllShouldReturn(seededEntities);

            //When
            var entities = await _handler.Handle(new GetAllExpensesQuery());
            
            //Then
            Assert.All(entities, dto => 
                Assert.Contains(seededEntities, ent =>
                    TestExpenseHelper.IsEntitySameAsDto(ent, dto)));
        }

        private void AllShouldReturn(List<ExpenseEntity> entities) {
            _expenseRepository = new MockExpenseRepositoryBuilder()
                .AllAsync(entities)
                .Build();
            _unitOfWork = new MockUnitOfWorkBuilder()
                .AddExpenseRepository(_expenseRepository.Object)
                .Build();
            _handler = new GetAllExpensesQueryHandler(_unitOfWork.Object);
        }

        private List<ExpenseEntity> SeedEntities(int amount) {
            var entities = new List<ExpenseEntity>();
            for(int i = 0; i < amount; i++) {
                entities.Add(TestExpenseSeeder.Seed());
            }
            return entities;
        }
    }
}