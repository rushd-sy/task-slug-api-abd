using SlugGenerator.Api.DTOs;
using FluentValidation;

namespace SlugGenerator.Api.Validators
{
    public class SlugRequestValidator : AbstractValidator<GenerateSlugRequest>
    {
        public SlugRequestValidator()
        {
            RuleFor(request => request.Text)
            .NotEmpty()
            .WithMessage("Text is required.")
            .MaximumLength(500)
            .WithMessage("Text must not exceed 500 characters.");

            RuleFor(request => request.Separator)
            .Must(separator => separator == '-' || separator == '_')
            .WithMessage("Separator must be either '-' or '_'.")
            .When(request => request.Separator != null);
        }

    }
}
