using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.DataEntityFramework.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly AppDbContext _dbContext;
        protected DbSet<TEntity> _entities => _dbContext.Set<TEntity>();
        public EFRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public virtual async Task<TEntity> GetById(TEntity entity, CancellationToken cancellationToken)
        {
            return await _entities.FirstAsync(it => it.Id == entity.Id, cancellationToken);
        }
        public virtual async Task<List<TEntity>> GetAll(TEntity entity, CancellationToken cancellationToken)
        {
            return await _entities.ToListAsync(cancellationToken);
        }
        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken)
        {
            await _entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual Task Delete(TEntity entity, CancellationToken cancellationToken)
        {
            _entities.Remove(entity);
            _dbContext.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
