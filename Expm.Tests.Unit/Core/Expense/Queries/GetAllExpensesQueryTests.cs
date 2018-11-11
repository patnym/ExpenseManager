using System.Collections.Generic;
using Expm.Core;
using Expm.Core.Exepense;
using Expm.Core.Exepense.Queries;
using Expm.Core.Expense;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Queries
{
    public class GetAllExpensesQueryTests
    {
        private IQueryHandler<List<ExpenseDto>, GetAllExpensesQuery> _handler;

        [Fact]
        public async void Can_Retrieve_All_Expenses()
        {
            //Given
            var seededEntities = new List<ExpenseEntity> {
                new ExpenseEntity {
                    Name = "1"
                },
                new ExpenseEntity {
                    Name = "2"
                },
                new ExpenseEntity {
                    Name = "3"
                }
            };
            var expenseRepository = new MockExpenseRepositoryBuilder()
                .AllAsync(seededEntities)
                .Build();
            var unitOfWork = new MockUnitOfWorkBuilder()
                .AddExpenseRepository(expenseRepository.Object)
                .Build();

            _handler = new GetAllExpensesQueryHandler(unitOfWork.Object);



            //When
            var cmd = new GetAllExpensesQuery();
            var expensesDto = await _handler.Handle(cmd);

            //Then
            Assert.Equal(3, expensesDto.Count);
        }

        //Todo: Need test that asserts the dto returned is as expected

    }
}