using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.DataEntityFramework.Repositories
{
    public class NoteRepositoryEF : EFRepository<Note>, INoteRepository
    {
        private AppDbContext _dbContext;
        public NoteRepositoryEF(AppDbContext _appDbContext)
            : base(_appDbContext) { }

        public async Task<Note?> FindNoteById(Note note, CancellationToken cancellationToken) 
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(note));
            return await _dbContext.Notes.SingleOrDefaultAsync(it => it.Id == note.Id, cancellationToken);
        }
        public override async Task Update(Note newNote, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(newNote));
            var note = await FindNoteById(newNote, cancellationToken);
            if (note is null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            note.Record = newNote.Record;
            await _dbContext.SaveChangesAsync();
        }
    }
}
