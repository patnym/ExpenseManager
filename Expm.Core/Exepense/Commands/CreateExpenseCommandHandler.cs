using System.Threading.Tasks;
using AutoMapper;
using Expm.Core.Expense;

namespace Expm.Core.Exepense.Commands
{
    public class CreateExpenseCommandHandler : ICommandHandler<ExpenseDto, CreateExpenseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExpenseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(CreateExpenseCommand request) 
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