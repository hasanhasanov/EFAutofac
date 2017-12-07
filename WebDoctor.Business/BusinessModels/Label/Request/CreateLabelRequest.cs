namespace WebDoctor.Business
{
    public class CreateLabelRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        //public int? PhotoId { get; set; }
        //public int? VideoId { get; set; }
        public bool IsActive { get; set; }
    }
}
