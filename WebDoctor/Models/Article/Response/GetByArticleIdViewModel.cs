using System;
using System.Web.Mvc;

namespace WebDoctor.Models
{
    public class GetByArticleIdViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}