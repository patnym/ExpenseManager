using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Expm.Application.Models.ExpenseModel
{
    public static class ConfigureExpenseModel
    {
        
        public static void Configure(IServiceCollection services) {
            services.AddSingleton<ExpenseSchema>();
            services.AddSingleton<ExpenseQuery>();
            services.AddSingleton<ExpenseMutation>();
            services.AddSingleton<ExpenseType>();
            services.AddSingleton<ExpenseInputType>();
        }

        public static void ConfigureSchema(IServiceCollection services, ServiceProvider provider) {
            services.AddSingleton<ISchema>(new ExpenseSchema(new FuncDependencyResolver(type => provider.GetService(type))));
        }

    }
}