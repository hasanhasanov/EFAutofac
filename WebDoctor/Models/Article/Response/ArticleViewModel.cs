using System;

namespace WebDoctor.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}