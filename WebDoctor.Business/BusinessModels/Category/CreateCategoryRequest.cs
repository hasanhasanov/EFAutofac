namespace WebDoctor.Business
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
