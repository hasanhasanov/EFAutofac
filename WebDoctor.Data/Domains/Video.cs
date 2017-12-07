using System;

namespace WebDoctor.Data
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoPath { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}