using System;

namespace WebDoctor.Data
{
    public class Article
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }

        public int? PhotoId { get; set; }
        public int? VideoId { get; set; }
        public int CategoryId { get; set; }

        public int? ViewCount { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


    }
}
