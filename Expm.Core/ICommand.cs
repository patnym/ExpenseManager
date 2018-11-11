using System.Threading.Tasks;

namespace Expm.Core
{
    public interface ICommandHandler<T> where T : class
    {
        Task<T> Handle(T input);
    }
}