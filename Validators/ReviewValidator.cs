using FluentValidation;
using GameJournal.DTOs;

namespace GameJournal.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator()
        {
            RuleFor(ReviewDto => ReviewDto.Comment)
                .NotEmpty().WithMessage("Comment Cannot be empty")
                .MaximumLength(500).WithMessage("Comment cannot exceed 500 charachters");

            RuleFor(reviewDto => reviewDto.Grade)
                .InclusiveBetween(1, 5).WithMessage("Grade must be between 1 and 5.");
        }
    }
}
