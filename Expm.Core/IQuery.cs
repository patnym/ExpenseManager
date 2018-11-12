using System.Threading.Tasks;

namespace Expm.Core
{
    public interface IQueryHandler<T, I> 
        where T : class where I : class
    {
        Task<T> Handle(I input);
    }
}