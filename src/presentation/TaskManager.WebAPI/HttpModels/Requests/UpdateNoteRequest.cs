#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
using System.ComponentModel.DataAnnotations;

namespace TaskManager.WebAPI.HttpModels.Requests
{
    public class UpdateNoteRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string NewRecord { get; set; }
    }
}
