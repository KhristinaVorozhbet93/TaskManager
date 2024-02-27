using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Services;

namespace TaskManager.WebAPI.Controllers
{
    [ApiController]
    [Route("note")]
    public class NoteController : ControllerBase
    {
        private readonly NoteService _noteService;

        public NoteController(NoteService noteService)
        {
            _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
        }

        [HttpGet("/get_note")]
        public async Task<ActionResult<Note>> GetNote(Note note, CancellationToken cancellationToken)
        {
            try
            {
                var existedNote = await _noteService.GetNote(note, cancellationToken);
                return Ok(existedNote);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (ArgumentNullException)
            {
                return BadRequest(); 
            }
        }

        [HttpGet("/get_notes")]
        public async Task<ActionResult<List<Note>>> GetNotes(CancellationToken cancellationToken)
        {
            try
            {
                var existedNotes = await _noteService.GetAllNotes(cancellationToken);
                return Ok(existedNotes);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost("/add_note")]
        public async Task<ActionResult> AddNote(Note note, CancellationToken cancellationToken)
        {
            try
            {
                await _noteService.AddNote(note, cancellationToken);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPost("/update_note")]
        public async Task<ActionResult> UpdateNote(Note newNote, CancellationToken cancellationToken)
        {
            try
            {
                await _noteService.UpdateNote(newNote, cancellationToken);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost("/delete_note")]
        public async Task<ActionResult> DeleteNote(Note note, CancellationToken cancellationToken)
        {
            try
            {
                await _noteService.DeleteNote(note, cancellationToken);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
