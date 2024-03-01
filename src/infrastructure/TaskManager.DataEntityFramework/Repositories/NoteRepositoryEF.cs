#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

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
