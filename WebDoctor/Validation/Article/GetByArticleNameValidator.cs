using FluentValidation;

namespace WebDoctor.Models
{
    public class GetByArticleNameValidator:AbstractValidator<GetByArticleNameModel>
    {
        public GetByArticleNameValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!").MaximumLength(50)
                .WithMessage("Name cannot be greater than 50 characters!");
        }
    }
}