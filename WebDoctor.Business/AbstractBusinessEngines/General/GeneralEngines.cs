using System;

namespace WebDoctor.Business
{
    public class GeneralEngines : IGeneralEngine
    {
        public ICategoryEngine CategoryEngine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IArticelEngine ArticelEngine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ILabelEngine LabelEngine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
