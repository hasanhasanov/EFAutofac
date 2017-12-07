using System;
namespace WebDoctor.Business.Entities
{
    public class CategoryList
    {
        //private DateTime _date;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        //public DateTime CreatedDateString
        //{
        //    get => Convert.ToDateTime(this.CreatedDateString.ToShortDateString());
        //    set => this.CreatedDateString = Convert.ToDateTime(value);
        //}
    }
}
