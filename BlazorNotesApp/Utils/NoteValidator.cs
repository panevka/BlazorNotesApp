using BlazorNotesApp.Models;
using FluentValidation;

namespace BlazorNotesApp.Utils;

public class NoteValidator : AbstractValidator<Note>
{
    public NoteValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .NotNull().WithMessage("Title is required")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters")
            .MaximumLength(50).WithMessage("Title must be less than 30 characters");;
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required")
            .NotNull().WithMessage("Content is required")
            .MinimumLength(30).WithMessage("Content must be at least 30 characters");
        RuleFor(x => x.CreatedAt)
            .NotNull().WithMessage("Creation date is required")
            .NotEmpty().WithMessage("Creation date is required");
    }
}