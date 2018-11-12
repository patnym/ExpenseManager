using System.Threading;
using Expm.Core;
using Expm.Core.Exepense;
using Expm.Core.Exepense.Commands;
using Expm.Core.Expense;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Commands
{
    public class CreateExpenseCommandHandlerTests
    {
        
        private ICommandHandler<ExpenseDto, CreateExpenseCommand> _handler;

        [Fact]
        public async void Can_Add_Expense_Entity()
        {
            //Given
            var expenseName = "My first expense";
            var mockExpenseRepository = new MockExpenseRepositoryBuilder()
                .AddAsync(new ExpenseEntity {
                    Name = expenseName
                })
                .Build();
            var mockUnitOfWork = new MockUnitOfWorkBuilder()
                .AddExpenseRepository(mockExpenseRepository.Object)
                .Build();
            _handler = new CreateExpenseCommandHandler(mockUnitOfWork.Object);

            //When
            var expenseCmd = new CreateExpenseCommand() {
                Name = expenseName
            };
            var expenseEntity = await _handler.Handle(expenseCmd);

            //Then
            mockExpenseRepository.Verify(exs => exs.AddAsync(It.IsAny<ExpenseEntity>()), Times.Once);
            mockUnitOfWork.Verify(ctx => ctx.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.Equal(expenseName, expenseEntity.Name);
        }

    }
}