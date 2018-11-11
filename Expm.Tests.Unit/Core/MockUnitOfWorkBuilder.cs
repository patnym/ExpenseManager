using System;
using Expm.Core;
using Expm.Core.Expense;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Expm.Tests.Unit.Core
{
    public class MockUnitOfWorkBuilder : IDisposable
    {
        private Mock<IUnitOfWork> _unitOfWork;

        public MockUnitOfWorkBuilder()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        public MockUnitOfWorkBuilder AddExpenseRepository(IExpenseRepository repository) {
            _unitOfWork.Setup(ctx => ctx.Expenses)
                .Returns(repository);
            return this;
        }

        public Mock<IUnitOfWork> Build() {
            return _unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork = null;
        }
    }
}