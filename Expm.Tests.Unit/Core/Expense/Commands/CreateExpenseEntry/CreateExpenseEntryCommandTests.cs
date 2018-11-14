using System;
using System.Linq;
using System.Threading;
using Expm.Core;
using Expm.Core.Exceptions;
using Expm.Core.Expense;
using Expm.Core.Expense.Commands.CreateExpenseEntry;
using Moq;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Commands.CreateExpenseEntry
{
    public class CreateExpenseEntryCommandTests : TestExpenseBase
    {
        private ExpenseEntity _seededExpenseEntity;
        private IExpmRequestHandler<CreateExpenseEntryCommand, ExpenseDto> _handler; 
        private Mock<IExpenseRepository> _expenseRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        public CreateExpenseEntryCommandTests()
        {
            _seededExpenseEntity = TestExpenseSeeder.SeedExpense();
            _expenseRepository = new MockExpenseRepositoryBuilder()
                .GetAsyncIs(id => id == _seededExpenseEntity.Id, _seededExpenseEntity)
                .Build();
            _unitOfWork = new MockUnitOfWorkBuilder()
                .AddExpenseRepository(_expenseRepository.Object)
                .Build();
            _handler = new CreateExpenseEntryHandler(_unitOfWork.Object, _mapper);
        }

        [Fact]
        public async void Can_Create_ExpenseEntry()
        {
            //When
            var entity = await _handler.Handle(new CreateExpenseEntryCommand {
                ExpenseId = _seededExpenseEntity.Id,
                Name = "Test",
                Date = DateTime.UtcNow,
                Description = "Hello from outer space",
                Cost = 10
            });

            //Then
            _expenseRepository.Verify(exs => exs.GetAsync(It.Is<string>(s => s == _seededExpenseEntity.Id)));
            _unitOfWork.Verify(exs => exs.CompleteAsync(It.IsAny<CancellationToken>()));
            Assert.Single(entity.ExpenseEntries);            
        }

        [Fact]
        public async void Wrong_expense_id_throws_error()
        {
            //When
            await Assert.ThrowsAsync<NoEntityException>( async () => {
                await _handler.Handle(new CreateExpenseEntryCommand {
                    ExpenseId = "invalid"
                });
            });
        }

        [Fact]
        public async void Dto_converts_correctly()
        {
            //Given
            var seededEntry = TestExpenseSeeder.SeedExpenseEntry();

            //When
            var entity = await _handler.Handle(new CreateExpenseEntryCommand {
                ExpenseId = _seededExpenseEntity.Id,
                Name = seededEntry.Name,
                Description = seededEntry.Description,
                Cost = seededEntry.Cost,
                Date = seededEntry.Date
            });

            //Then
            TestExpenseHelper.AssertExpenseEntryEntityMatchesDto(seededEntry, entity.ExpenseEntries.First());
        }
    }
}