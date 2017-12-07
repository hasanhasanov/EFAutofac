using FluentValidation.Attributes;
using WebDoctor.Models.Validation.Category;

namespace WebDoctor.Models
{
    [Validator(typeof(GetByCategoryIdValidator))]
    public class GetByCategoryIdModel
    {
        public int Id { get; set; }
    }
}