using System;

namespace WebDoctor.Data
{
   public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
