using FluentValidation;

namespace WebDoctor.Models
{
    public class UpdateArticleValidator:AbstractValidator<UpdateArticleModel>
    {
        public UpdateArticleValidator()
        {
            this.RuleFor(x => x.Id).NotNull().WithMessage("Id is can not be null or empty!").GreaterThan(0)
                .WithMessage("Id greater must be greater than zero!");

            this.RuleFor(x => x.Header)
                .NotEmpty().WithMessage("Header cannot be empty!").MaximumLength(200)
                .WithMessage("Header cannot be greater than 200 characters!");

            this.RuleFor(x => x.Content).MaximumLength(1000)
                .WithMessage("Content cannot be greater than 1000 characters!");

            this.RuleFor(x => x.CategoryId).NotNull().WithMessage("Category Id is can not be null or empty!").GreaterThan(0)
                .WithMessage("Category Id greater must be greater than zero!");
        }
    }
}