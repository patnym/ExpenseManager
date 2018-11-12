using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Expm.Core
{
    public interface IExpmRequestHandler<T, I> : IRequestHandler<T, I>
        where T : class, IRequest<I> where I : class
    {
        new Task<I> Handle(T input, CancellationToken token = default(CancellationToken));
    }
}