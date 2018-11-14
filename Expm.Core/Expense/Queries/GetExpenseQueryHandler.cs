using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Expm.Core.Exceptions;
using Expm.Core.Expense;
using Microsoft.EntityFrameworkCore;

namespace Expm.Core.Expense.Queries
{
    public class GetExpenseQueryHandler : IExpmRequestHandler<GetExpenseQuery, ExpenseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetExpenseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(GetExpenseQuery query,
            CancellationToken token = default(CancellationToken)) 
        {
            var entity = await _unitOfWork.Expenses.GetAsync(query.Id);
            Guard.AgainstNull(entity, $"No entity of id '{query.Id}' exists");
            return _mapper.Map<ExpenseDto>(entity);
        }
    }
}