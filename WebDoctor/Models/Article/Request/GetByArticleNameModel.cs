using FluentValidation.Attributes;

namespace WebDoctor.Models
{
    [Validator(typeof(GetByArticleNameValidator))]
    public class GetByArticleNameModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}