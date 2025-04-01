using FluentValidation;
using GameJournal.DTOs;

namespace GameJournal.Validators
{
    public class GameValidator : AbstractValidator<GameDto>
    {
        public GameValidator()
        {
            string[] allowedGenres = new string[] { "Action", "Adventure", "RPG", "Strategy", "Puzzle", "Shooter" };
            string[] alloweStatuses = new string[] { "Not Started", "In Progress", "Completed" };


            RuleFor(gameDto => gameDto.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 charachtgers");

            RuleFor(gameDto => gameDto.Genre)
                .NotEmpty().WithMessage("Genre is required.")
                .Must(genre => allowedGenres.Contains(genre)).WithMessage("Invalid genre. Allowed genres are: Action, Adventure, RPG, Strategy, Puzzle, Shooter.");

            RuleFor(gameDto => gameDto.Status)
                .NotEmpty().WithMessage("Status Cannot be empty")
                .Must(status => alloweStatuses.Contains(status)).WithMessage("Invalid status. Allowed statuses are: Not Started, In Progress, Completed");
        }
    }
}
