﻿using Core.Entities.Abstract;
using Core.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext DataContext;

        public RepositoryBase(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var result = await DataContext.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public Task DeleteAsync(T entity)
        {
            var entityEntry = DataContext.Entry(entity);
            DataContext.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> FindAllAsync() => await DataContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = DataContext.Set<T>().Where(expression);
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return await query.ToListAsync();
        }
        public IQueryable<T> FindAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = DataContext.Set<T>().AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return  query;
        }
        public IQueryable<T> GetAllAsQueryable()
        {
            var query = DataContext.Set<T>().AsQueryable();
            

            return query;
        }
        public IQueryable<T> FindByConditionAsyncs(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = DataContext.Set<T>().Where(expression).AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }




        public Task UpdateAsync(T entity)
        {
            var entityEntry = DataContext.Entry(entity);
            entityEntry.State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task SaveAsync() => await DataContext.SaveChangesAsync();

        public async Task<T> FindById(int id)
        {
           return await DataContext.Set<T>().FindAsync(id);
        }
        public async Task<T> Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query =  DataContext.Set<T>().Where(expression);
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync();

        }

       /* public async Task<T> GetLastItem()
        {
            var result =  DataContext.Set<T>().OrderByDescending();
            return result;
        } */
    }
}
