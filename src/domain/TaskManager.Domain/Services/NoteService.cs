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

        public async Task<Note> GetNote(Note note, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(note));
            return await _noteRepository.GetById(note, cancellationToken);
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
        public async Task AddNote(Note note, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(note));
            await _noteRepository.Add(note, cancellationToken);
        }
        public async Task UpdateNote(Note note, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(note));
            await _noteRepository.Update(note, cancellationToken);
        }
        public async Task DeleteNote(Note note, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(note));
            await _noteRepository.Delete(note, cancellationToken);
        }
    }
}
