using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Services;
using TaskManager.WebAPI.HttpModels.Requests;
using TaskManager.WebAPI.HttpModels.Responses;

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
        public async Task<ActionResult<NoteResponse>> GetNote
            (Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var existedNote = await _noteService.GetNote(id, cancellationToken);
                return Ok(new NoteResponse(existedNote.Id, existedNote.Record));
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
        public async Task<ActionResult<List<NoteResponse>>> GetNotes(CancellationToken cancellationToken)
        {
            try
            {
                var existedNotes = await _noteService.GetAllNotes(cancellationToken);
                List<NoteResponse> notesResponse = new();
                foreach (var note in existedNotes)
                {
                    notesResponse.Add(new NoteResponse(note.Id, note.Record));
                }

                return Ok(notesResponse);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost("/add_note")]
        public async Task<ActionResult> AddNote(NoteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _noteService.AddNote(request.Record, cancellationToken);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPost("/update_note")]
        public async Task<ActionResult> UpdateNote
            (UpdateNoteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _noteService.UpdateNote(request.Id, request.NewRecord, cancellationToken);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost("/delete_note")]
        public async Task<ActionResult> DeleteNote(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _noteService.DeleteNote(id, cancellationToken);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
