using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Domain.Services
{
    public class NoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
        }

        public async Task<Note> GetNote(Guid id, CancellationToken cancellationToken)
        {
            return await _noteRepository.GetById(id, cancellationToken);
        }
        public async Task<List<Note>> GetAllNotes(CancellationToken cancellationToken)
        {
           var existedNotes = await _noteRepository.GetAll(cancellationToken);
            if (existedNotes == null)
            {
                throw new ArgumentNullException(nameof(existedNotes));
            }
            return existedNotes; 
        }
        public async Task AddNote(string record, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException(nameof(record));
            }

            var note = new Note(Guid.NewGuid(), record);
            await _noteRepository.Add(note, cancellationToken);
        }
        public async Task UpdateNote(Guid id, string newRecord, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(nameof(newRecord)))
            {
                throw new ArgumentException(nameof(newRecord));
            }
            var note = await _noteRepository.FindNoteById(id, cancellationToken);

            if (note is null) 
            {
                throw new ArgumentException(nameof(note));
            }
            note.Record = newRecord; 
            await _noteRepository.Update(note, cancellationToken);
        }
        public async Task DeleteNote(Guid id, CancellationToken cancellationToken)
        {
            var note = await _noteRepository.GetById(id, cancellationToken);
            await _noteRepository.Delete(note, cancellationToken);
        }
    }
}
