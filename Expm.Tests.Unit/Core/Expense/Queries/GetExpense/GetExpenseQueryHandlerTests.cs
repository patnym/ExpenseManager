using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expm.Core;
using Expm.Core.Exceptions;
using Expm.Core.Expense;
using Expm.Core.Expense.Queries.GetExpense;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Queries
{
    public class GetExpenseQueryHandlerTests : TestExpenseBase
    {
        private ExpenseEntity _seededEntity;
        private IExpmRequestHandler<GetExpenseQuery, ExpenseDto> _handler;
        private Mock<IExpenseRepository> _expenseRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        public GetExpenseQueryHandlerTests() : base()
        {
            _seededEntity = TestExpenseSeeder.SeedExpense();
        }

        [Fact]
        public async void Can_retrieve_expense_by_id()
        {
            //Given
            GetShouldReturn(_seededEntity, _seededEntity.Id);

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
            _seededEntity.ExpenseEntries.AddRange(new List<ExpenseEntryEntity> {
                TestExpenseSeeder.SeedExpenseEntry(),
                TestExpenseSeeder.SeedExpenseEntry()
            });
            GetShouldReturn(_seededEntity, _seededEntity.Id);

            //When
            var entity = await _handler.Handle(new GetExpenseQuery(_seededEntity.Id));
            
            //Then
            Assert.Equal(_seededEntity.Id, entity.Id);
            Assert.Equal(_seededEntity.Name, entity.Name);
            TestExpenseHelper.AssertExpenseEntryEntityMatchesDto(
                _seededEntity.ExpenseEntries.ElementAt(0),
                entity.ExpenseEntries.ElementAt(0));
            TestExpenseHelper.AssertExpenseEntryEntityMatchesDto(
                _seededEntity.ExpenseEntries.ElementAt(1),
                entity.ExpenseEntries.ElementAt(1));
        }

        [Fact]
        public async void Get_should_throw_exception_when_wrong_id()
        {
            //Given
            GetShouldReturn(null);

            //Then
            await Assert.ThrowsAsync<NoEntityException>(async () => {
                await _handler.Handle(new GetExpenseQuery("invalid"));
            });
        }

        private void GetShouldReturn(ExpenseEntity entity, string whenId = "") {
            _expenseRepository = new MockExpenseRepositoryBuilder()
                .GetAsyncIs(id => id == whenId, entity)
                .Build();
            _unitOfWork = new MockUnitOfWorkBuilder()
                .AddExpenseRepository(_expenseRepository.Object)
                .Build();
            _handler = new GetExpenseQueryHandler(_unitOfWork.Object, _mapper);
        }
    }
}