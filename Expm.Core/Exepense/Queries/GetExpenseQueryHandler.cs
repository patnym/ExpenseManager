using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Expm.Core.Expense;
using Microsoft.EntityFrameworkCore;

namespace Expm.Core.Exepense.Queries
{
    public class GetExpenseQueryHandler : IQueryHandler<ExpenseDto, GetExpenseQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetExpenseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(GetExpenseQuery query) {
            var entity = await _unitOfWork.Expenses.GetAsync(query.Id);

            if(entity == null) {
                throw new System.Exception($"No entity of id {query.Id} exists");
            }
            return _mapper.Map<ExpenseDto>(entity);
        }
    }
}