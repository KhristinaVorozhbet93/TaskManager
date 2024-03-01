using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.DataEntityFramework.Repositories
{
    public class NoteRepositoryEF : EFRepository<Note>, INoteRepository
    {
        public NoteRepositoryEF(AppDbContext appDbContext)
            : base(appDbContext) { }

        public async Task<Note?> FindNoteById(Guid id, CancellationToken cancellationToken) 
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }
    }
}
