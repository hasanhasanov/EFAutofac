using System.Web.Mvc;
using FluentValidation.Attributes;

namespace WebDoctor.Models
{
    [Validator(typeof(CreateArticleValidator))]
    public class CreateArticleModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public SelectList Categories { get; set; }
    }
}