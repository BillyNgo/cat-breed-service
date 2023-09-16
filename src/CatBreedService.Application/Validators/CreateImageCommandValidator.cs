using CatBreedService.Application.Breeds.Commands;
using FluentValidation;

namespace CatBreedService.Application.Validators
{
    public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
    {
        public CreateImageCommandValidator()
        {
            RuleFor(c => c.BreedId).NotEmpty();
            RuleFor(c => c.Url).NotEmpty();
            RuleFor(c => c.Url).Matches("(https?:)?//?[^'\"<>]+?\\.(jpg|jpeg|gif|png)");
            RuleFor(c => c.Width).NotEmpty();
            RuleFor(c => c.Height).NotEmpty();
        }
    }
}
