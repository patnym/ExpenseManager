using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expm.Core.Expense;

namespace Expm.Infrastructure
{
    public sealed class ExpenseRepository : IExpenseRepository
    {
        private static Dictionary<string, ExpenseEntity> entities = new Dictionary<string, ExpenseEntity>();

        public async Task<ExpenseEntity> AddAsync(ExpenseEntity entity)
        {   
            entity.Id = Guid.NewGuid().ToString();
            entities.Add(entity.Id, entity);
            return entity;
        }

        public async Task<IEnumerable<ExpenseEntity>> AllAsync()
        {
            return entities.Values.ToList() as IEnumerable<ExpenseEntity>;
        }

        public async Task<ExpenseEntity> GetAsync(string id)
        {
            entities.TryGetValue(id, out var entity);
            return entity;
        }
    }
}
