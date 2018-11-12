using Expm.Core.Expense;
using MediatR;

namespace Expm.Core.Exepense.Queries
{
    public class GetExpenseQuery : IRequest<ExpenseDto>
    {
        public string Id { get; set; }

        public GetExpenseQuery(string id)
        {
            Id = id;    
        }
    }
}