using System;
using System.Threading.Tasks;
using Expm.Core;
using Expm.Core.Exepense;
using Expm.Core.Exepense.Queries;
using Expm.Core.Expense;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Queries
{
    public class GetExpenseQueryTests
    {
        
        private IQueryHandler<ExpenseDto, GetExpenseQuery> _handler;

        [Fact]
        public async void Can_Retrieve_Expense_By_Id()
        {
            //Given
            var mockId = Guid.NewGuid().ToString();
            var mockExpenseRepository = new MockExpenseRepositoryBuilder()
                .GetAsyncIs(id => id == mockId, new ExpenseEntity {
                    Id = mockId
                })
                .Build();
            var mockUnitOfWork = new MockUnitOfWorkBuilder()
                .AddExpenseRepository(mockExpenseRepository.Object)
                .Build();
            _handler = new GetExpenseQueryHandler(mockUnitOfWork.Object);

            //When
            var expenseQuery = new GetExpenseQuery(mockId);
            var expenseEntity = await _handler.Handle(expenseQuery);

            //Then
            Assert.Equal(mockId, expenseEntity.Id);
        }

    }
}