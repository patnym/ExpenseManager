using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Expm.Application.Models.ExpenseModel
{
    public static class ConfigureExpenseModel
    {
        
        public static void Configure(IServiceCollection services) {
            services.AddScoped<ExpenseQuery>();
            services.AddScoped<ExpenseMutation>();
            services.AddScoped<ExpenseType>();
            services.AddScoped<ExpenseEntryType>();
            services.AddScoped<ExpenseInputType>();
            services.AddScoped<ExpenseEntryInputType>();
            services.AddScoped<ISchema, ExpenseSchema>();
        }
    }
}