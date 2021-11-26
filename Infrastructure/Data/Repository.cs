using ApplicationCore.Common.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync()
        {
            var entityCount = await _applicationDbContext.Set<T>().CountAsync();
            return entityCount;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _applicationDbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<List<T>> GetListAsync()
        {
            var list = await _applicationDbContext.Set<T>().ToListAsync();
            return list;
        }

        public async Task<List<T>> GetListPage(int pageSize, int pageNumber, Func<T, object> orderExpression)
        {
            var list = await _applicationDbContext
                .Set<T>()
                .OrderBy(orderExpression)
                .AsQueryable()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return list;

        }

        public async Task UpdateAsync(T entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
