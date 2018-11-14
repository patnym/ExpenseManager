using GraphQL;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    internal sealed class ExpenseSchema : Schema
    {
        
        public ExpenseSchema(IDependencyResolver  resolver) : base(resolver)
        {
            Query = resolver.Resolve<ExpenseQuery>();
            Mutation = resolver.Resolve<ExpenseMutation>();
        }

    }
}