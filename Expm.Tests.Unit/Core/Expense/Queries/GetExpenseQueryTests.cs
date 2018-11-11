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
    public class GetExpenseQueryTests
    {
        
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

            //When
            var expenseQuery = new GetExpenseQuery(mockId);
            var expenseEntity = await new GetExpenseQueryHandler(mockUnitOfWork.Object)
                .Handle(expenseQuery);

            //Then
            Assert.Equal(mockId, expenseEntity.Id);
        }

    }
}