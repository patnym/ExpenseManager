using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Expm.Core.Expense;

namespace Expm.Core.Exepense.Queries
{
    public class GetAllExpensesQueryHandler : IExpmRequestHandler<GetAllExpensesQuery, List<ExpenseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllExpensesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ExpenseDto>> Handle(GetAllExpensesQuery input, 
            CancellationToken token = default(CancellationToken))
        {
            var expenses = await _unitOfWork.Expenses.AllAsync();
            return _mapper.Map<List<ExpenseDto>>(expenses);;
        }
    }
}