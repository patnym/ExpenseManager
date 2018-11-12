using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Expm.Core.Exepense.Queries
{
    public class GetExpenseQueryHandler : IQueryHandler<ExpenseDto, GetExpenseQuery>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExpenseQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<ExpenseDto> Handle(GetExpenseQuery query) {
            var entity = await _unitOfWork.Expenses.GetAsync(query.Id);

            if(entity == null) {
                throw new System.Exception($"No entity of id {query.Id} exists");
            }

            return new ExpenseDto {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}