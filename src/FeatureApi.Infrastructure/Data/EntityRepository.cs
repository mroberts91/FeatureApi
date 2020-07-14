using FeatureApi.Core;
using FeatureApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FeatureApi.Infrastructure.Data
{
    public class EntityRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly ICurrentUserService _userService;

        public EntityRepository(AppDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _userService = currentUserService;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
        public virtual async Task<T> GetByUniqueAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

		public async Task<IReadOnlyList<T>> ListAllAsync(
			int perPage,
			int page)
		{
			return await _dbContext.Set<T>().Skip(perPage * (page - 1)).Take(perPage).ToListAsync();
		}

		public async Task<T> AddAsync(T entity)
        {
            entity.Created = DateTime.Now;
            entity.ModifiedBy = _userService.CurrentUserName();
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            entity.LastModified = DateTime.Now;
            entity.ModifiedBy = _userService.CurrentUserName();
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}