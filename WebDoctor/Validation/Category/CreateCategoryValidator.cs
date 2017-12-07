using FluentValidation;

namespace WebDoctor.Models
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!").MaximumLength(50)
                .WithMessage("Name cannot be greater than 50 characters!");

            this.RuleFor(x => x.Description).MaximumLength(250)
                .WithMessage("Description cannot be greater than 250 characters!");
        }
    }
}