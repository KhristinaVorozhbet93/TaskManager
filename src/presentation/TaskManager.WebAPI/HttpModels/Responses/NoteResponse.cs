﻿#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
using System.ComponentModel.DataAnnotations;

namespace TaskManager.WebAPI.HttpModels.Responses
{
    public record NoteResponse (Guid id, string record);
}
