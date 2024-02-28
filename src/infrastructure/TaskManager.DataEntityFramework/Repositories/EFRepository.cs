using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.DataEntityFramework.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly AppDbContext _dbContext;
        protected DbSet<TEntity> Entities => _dbContext.Set<TEntity>();
        public EFRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public virtual async Task<TEntity> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleAsync(it => it.Id == id, cancellationToken);
        }
        public virtual async Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await Entities.ToListAsync(cancellationToken);
        }
        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken)
        {
            await Entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual Task Delete(TEntity entity, CancellationToken cancellationToken)
        {
            Entities.Remove(entity);
            _dbContext.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
