using FluentValidation.Attributes;

namespace WebDoctor.Models
{
    [Validator(typeof(DeleteArticleValidator))]
    public class DeleteArticleModel
    {
        public int Id { get; set; }
    }
}