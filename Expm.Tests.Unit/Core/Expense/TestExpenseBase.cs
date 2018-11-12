using AutoMapper;
using Expm.Core;

namespace Expm.Tests.Unit.Core.Expense
{
    public class TestExpenseBase
    {
        protected IMapper _mapper;

        public TestExpenseBase()
        {
            var cfg = new MapperConfiguration(ctx => ctx.AddProfile(new ExpmMapperProfile()));
            _mapper = new Mapper(cfg);
        }
    }
}