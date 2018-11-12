using AutoMapper;
using Expm.Core.Expense;

namespace Expm.Core
{
    public class ExpmMapperProfile : Profile
    {
        
        public ExpmMapperProfile()
        {
            CreateMap<ExpenseEntity, ExpenseDto>();
        }

    }
}