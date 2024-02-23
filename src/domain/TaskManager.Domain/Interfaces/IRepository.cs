﻿namespace TaskManager.Domain.Interfaces
{
    public interface IRepository<TEntity> 
    {
        Task<TEntity> GetById(TEntity entity, CancellationToken cancellationToken);
        Task<List<TEntity>> GetAll(TEntity entity, CancellationToken cancellationToken);
        Task Add(TEntity entity, CancellationToken cancellationToken);
        Task Update(TEntity entity, CancellationToken cancellationToken);
        Task Delete(TEntity entity, CancellationToken cancellationToken);
    }
}