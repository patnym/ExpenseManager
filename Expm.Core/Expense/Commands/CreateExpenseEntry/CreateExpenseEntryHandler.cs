using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Expm.Core.Exceptions;

namespace Expm.Core.Expense.Commands.CreateExpenseEntry
{
    public class CreateExpenseEntryHandler : IExpmRequestHandler<CreateExpenseEntryCommand, ExpenseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExpenseEntryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(CreateExpenseEntryCommand input, CancellationToken token = default(CancellationToken))
        {
            var entity = await _unitOfWork.Expenses.GetAsync(input.ExpenseId).ConfigureAwait(false);
            Guard.AgainstNull(entity, $"No entity of id '{input.ExpenseId}' exists");

            entity.ExpenseEntries.Add(new ExpenseEntryEntity {
                Name = input.Name,
                Description = input.Description,
                Date = input.Date,
                Cost = input.Cost
            });
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ExpenseDto>(entity);
        }
    }
}