using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Expm.Core.Expense;
using Moq;

namespace Expm.Tests.Unit.Core.Expense
{
    public class MockExpenseRepositoryBuilder
    {
        private Mock<IExpenseRepository> _repository;

        public MockExpenseRepositoryBuilder()
        {
            _repository = new Mock<IExpenseRepository>();
        }

        public MockExpenseRepositoryBuilder GetAsyncIs(Expression<Func<string, bool>> match,
            ExpenseEntity returns = default(ExpenseEntity))
        {
            _repository.Setup(r => r.GetAsync(It.Is<string>(match)))
                .ReturnsAsync(returns);
            return this;
        }

        public MockExpenseRepositoryBuilder AddAsync(ExpenseEntity returns) {
            _repository.Setup(r => r.AddAsync(It.IsAny<ExpenseEntity>()))
                .ReturnsAsync(returns);
            return this;
        }

        public MockExpenseRepositoryBuilder AllAsync(List<ExpenseEntity> returns) {
            _repository.Setup(r => r.AllAsync())
                .ReturnsAsync(returns);

            return this;
        }

        public Mock<IExpenseRepository> Build() {
            return _repository;
        }
    }
}