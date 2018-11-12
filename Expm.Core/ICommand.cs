using System.Threading.Tasks;

namespace Expm.Core
{
    public interface ICommandHandler<T, I> 
        where T : class where I : class
    {
        Task<T> Handle(I input);
    }
}