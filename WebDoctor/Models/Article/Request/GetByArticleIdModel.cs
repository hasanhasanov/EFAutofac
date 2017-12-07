using FluentValidation.Attributes;

namespace WebDoctor.Models
{
    [Validator(typeof(GetByArticleIdValidator))]
    public class GetByArticleIdModel
    {
        public int Id { get; set; }
    }
}