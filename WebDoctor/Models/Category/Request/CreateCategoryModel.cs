using FluentValidation.Attributes;

namespace WebDoctor.Models
{
    [Validator(typeof(CreateCategoryValidator))]
    public class CreateCategoryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}