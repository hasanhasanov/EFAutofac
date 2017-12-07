namespace WebDoctor.Models
{
    public class GetLabelListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        //public int? PhotoId { get; set; }
        //public int? VideoId { get; set; }
        public bool IsActive { get; set; }
    }
}