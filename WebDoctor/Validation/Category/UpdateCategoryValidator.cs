using FluentValidation;

namespace WebDoctor.Models
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is can not be null or empty!").GreaterThan(0)
                .WithMessage("Id greater must be greater than zero!");

            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!").MaximumLength(50)
                .WithMessage("Name cannot be greater than 50 characters!");

            this.RuleFor(x => x.Description).MaximumLength(250)
                .WithMessage("Description cannot be greater than 250 characters!");
        }

    }
}