using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expm.Core.Expense;

namespace Expm.Core.Exepense.Queries
{
    public class GetAllExpensesQueryHandler : IQueryHandler<List<ExpenseDto>, GetAllExpensesQuery>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllExpensesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ExpenseDto>> Handle(GetAllExpensesQuery input)
        {
            var expenses = await _unitOfWork.Expenses.AllAsync();
            var expensesDtos = expenses.Select( exp => new ExpenseDto {
                Name = exp.Name,
                Id = exp.Id
            });
            return expensesDtos.ToList();
        }
    }
}