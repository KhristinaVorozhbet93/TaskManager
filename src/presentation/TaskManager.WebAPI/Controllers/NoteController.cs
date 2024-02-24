using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.WebAPI.Controllers
{
    [ApiController]
    [Route("note")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(noteRepository));
            _noteRepository = noteRepository;
        }

        [HttpGet("/get_note")]
        public async Task<ActionResult<Note>> GetNote(Note note, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _noteRepository.GetById(note, cancellationToken);
                return Ok(result);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet("/get_notes")]
        public async Task<List<Note>> GetNotes(CancellationToken cancellationToken)
        {
            return await _noteRepository.GetAll(cancellationToken);
        }

        [HttpPost("/add_note")]
        public async Task AddNote(Note note, CancellationToken cancellationToken)
        {
            await _noteRepository.Add(note, cancellationToken);
        }

        [HttpPost("/update_note")]
        public async Task<ActionResult> UpdateNote(Note note, CancellationToken cancellationToken)
        {
            try
            {
                await _noteRepository.Update(note, cancellationToken);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
        [HttpPost("/delete_note")]
        public async Task DeleteNote(Note note, CancellationToken cancellationToken)
        {
            await _noteRepository.Delete(note, cancellationToken);
        }
    }
}
