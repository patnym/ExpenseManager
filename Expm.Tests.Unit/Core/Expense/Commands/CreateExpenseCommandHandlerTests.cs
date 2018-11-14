using System.Threading;
using Expm.Core;
using Expm.Core.Expense;
using Expm.Core.Expense.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Commands
{
    public class CreateExpenseCommandHandlerTests : TestExpenseBase
    {
        private ExpenseEntity _seededEntity;
        private IExpmRequestHandler<CreateExpenseCommand, ExpenseDto> _handler;
        private Mock<IExpenseRepository> _expenseRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        public CreateExpenseCommandHandlerTests() : base()
        {
            _seededEntity = TestExpenseSeeder.SeedExpense();
        }

        [Fact]
        public async void Can_add_expense_entity()
        {
            //Given
            AddShouldReturn(_seededEntity);

            //When
            var expenseEntity = await _handler.Handle(new CreateExpenseCommand() {
                Name = _seededEntity.Name
            });

            //Then
            _expenseRepository.Verify(exs => exs.AddAsync(It.IsAny<ExpenseEntity>()), Times.Once);
            _unitOfWork.Verify(ctx => ctx.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(_seededEntity.Name, expenseEntity.Name);
        }

        [Fact]
        public async void Dto_returned_is_valid()
        {
            //Given
            AddShouldReturn(_seededEntity);

            //When
            var entity = await _handler.Handle(new CreateExpenseCommand {
                Name = _seededEntity.Name
            });

            //Then
            TestExpenseHelper.AssertExpenseEntityMatchesDto(_seededEntity, entity);
        }

        private void AddShouldReturn(ExpenseEntity entity) {
            _expenseRepository = new MockExpenseRepositoryBuilder()
                .AddAsync(entity)
                .Build();
            _unitOfWork = new MockUnitOfWorkBuilder()
                .AddExpenseRepository(_expenseRepository.Object)
                .Build();
            _handler = new CreateExpenseCommandHandler(_unitOfWork.Object, _mapper);
        }
    }
}