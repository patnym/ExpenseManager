using System.Threading.Tasks;
using Expm.Core.Expense;

namespace Expm.Core.Exepense.Commands
{
    public class CreateExpenseCommandHandler : ICommandHandler<ExpenseDto, CreateExpenseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateExpenseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ExpenseDto> Handle(CreateExpenseCommand request) 
        {
            var result = await _unitOfWork.Expenses
                .AddAsync(new ExpenseEntity {
                    Name = request.Name
                });
            await _unitOfWork.CompleteAsync();

            return new ExpenseDto {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}