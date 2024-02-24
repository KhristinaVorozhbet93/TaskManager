using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.DataEntityFramework.Repositories
{
    public class NoteRepository : EFRepository<Note>, INoteRepository
    {
        private AppDbContext _appDbContext;
        public NoteRepository(AppDbContext _appDbContext)
            : base(_appDbContext) { }

        public override async Task Update(Note newNote, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(newNote));
            var note = await _appDbContext.Notes.SingleOrDefaultAsync(it => it.Id == newNote.Id);
            if (note is null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            note.Record = newNote.Record;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
