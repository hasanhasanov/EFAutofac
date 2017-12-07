using System;
using System.Linq;
using WebDoctor.Data;

namespace WebDoctor.Business
{
    public class LabelEngine : ILabelEngine
    {
        private readonly IRepository<Label> _labelRepository;

        public LabelEngine(IRepository<Label> labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public GetLabelListResponse GetLabelList()
        {
            var labelList = this._labelRepository.GetList().Where(x => !x.IsDeleted);

            if (labelList == null)
            {
                throw new Exception("Moedel is null!");
            }

            return new GetLabelListResponse()
            {
                LabelList = labelList.Select(x=> new LabelListItems()
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    IsActive = x.IsActive,
                    Description = x.Description,
                    Name = x.Name
                }).ToList()
            };
        }

    }
}
