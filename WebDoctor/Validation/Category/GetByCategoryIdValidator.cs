using FluentValidation;

namespace WebDoctor.Models.Validation.Category
{
    public class GetByCategoryIdValidator:AbstractValidator<GetByCategoryIdModel>
    {
        public GetByCategoryIdValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is can not be null or empty!").GreaterThan(0)
                .WithMessage("Id greater must be greater than zero!");
        }
    }
}