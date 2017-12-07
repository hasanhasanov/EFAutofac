namespace WebDoctor.Business
{
    public class CreateArticleRequest
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
