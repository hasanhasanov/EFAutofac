using FluentValidation;

namespace WebDoctor.Models
{
    public class GetByArticleIdValidator:AbstractValidator<GetByArticleIdModel>
    {
        public GetByArticleIdValidator()
        {
            this.RuleFor(x => x.Id).NotNull().WithMessage("Id is can not be null or empty!").GreaterThan(0)
                .WithMessage("Id greater must be greater than zero!");
        }
    }
}