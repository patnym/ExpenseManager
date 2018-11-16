using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Expm.Core.Expense;
using MediatR;

namespace Expm.Core.Expense.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IExpmRequestHandler<CreateExpenseCommand, ExpenseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExpenseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(CreateExpenseCommand request, 
            CancellationToken token = default(CancellationToken)) 
        {
            var result = await _unitOfWork.Expenses
                .AddAsync(new ExpenseEntity {
                    Name = request.Name
                });
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<ExpenseDto>(result);
        }
    }
}