namespace WebDoctor.Business
{
    public interface IGeneralEngine
    {
        ICategoryEngine CategoryEngine { get; set; }
        IArticelEngine ArticelEngine { get; set; }
        ILabelEngine LabelEngine { get; set; }
    }
}
