using GraphQL;
using GraphQL.Types;

namespace Expm.Application.Models.ExpenseModel
{
    public class ExpenseSchema : Schema
    {
        
        public ExpenseSchema(IDependencyResolver  resolver) : base(resolver)
        {
            Query = resolver.Resolve<ExpenseQuery>();
            Mutation = resolver.Resolve<ExpenseMutation>();
        }

    }
}