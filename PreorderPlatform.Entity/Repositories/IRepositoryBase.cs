﻿using PreorderPlatform.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Entity.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {  
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IQueryable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithIncludeAsync(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[]? includes);
        Task<IEnumerable<T>> GetAllWithIncludeLoadRelatedEntitiesAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task<T> GetWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task UpdateAsync(T entity);
    }
}
