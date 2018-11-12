using System;
using System.Threading.Tasks;
using Expm.Core;
using Expm.Core.Exepense.Queries;
using Expm.Core.Expense;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Queries
{
    public class GetExpenseQueryHandlerTests
    {
        private ExpenseEntity _seededEntity;
        private IQueryHandler<ExpenseDto, GetExpenseQuery> _handler;
        private Mock<IExpenseRepository> _expenseRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        public GetExpenseQueryHandlerTests()
        {
            _seededEntity = TestExpenseSeeder.Seed();
        }

        [Fact]
        public async void Can_retrieve_expense_by_id()
        {
            //Given
            GetShouldReturn(_seededEntity);

            //When
            var expenseQuery = new GetExpenseQuery(_seededEntity.Id);
            var expenseEntity = await _handler.Handle(expenseQuery);

            //Then
            Assert.Equal(_seededEntity.Id, expenseEntity.Id);
        }

        [Fact]
        public async void Dto_returned_is_valid()
        {
            //Given
            GetShouldReturn(_seededEntity);

            //When
            var entity = await _handler.Handle(new GetExpenseQuery(_seededEntity.Id));
            
            //Then
            Assert.Equal(_seededEntity.Id, entity.Id);
            Assert.Equal(_seededEntity.Name, entity.Name);
        }

        private void GetShouldReturn(ExpenseEntity entity) {
            _expenseRepository = new MockExpenseRepositoryBuilder()
                .GetAsyncIs(id => id == entity.Id, entity)
                .Build();
            _unitOfWork = new MockUnitOfWorkBuilder()
                .AddExpenseRepository(_expenseRepository.Object)
                .Build();
            _handler = new GetExpenseQueryHandler(_unitOfWork.Object);
        }
    }
}