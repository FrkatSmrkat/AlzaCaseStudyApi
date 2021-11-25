﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Abstractions
{
    public interface IRepository<T>
    {
        public Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> CountAsync();
        public Task<List<T>> GetListAsync();
        public Task<List<T>> GetPagedListAsync(int pageSize, int pageNumber);
    }
}
