using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<Note?> FindNoteById(Guid id, CancellationToken cancellationToken); 
    }
}
