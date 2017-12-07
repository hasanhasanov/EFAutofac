using FluentValidation.Attributes;
using WebDoctor.Models.Validation.Category;

namespace WebDoctor.Models
{
    [Validator(typeof(DeleteCategoryValidator))]
    public class DeleteCategoryModel
    {
        public int Id { get; set; }
    }
}