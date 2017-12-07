using System.Collections.Generic;
using WebDoctor.Business.Entities;

namespace WebDoctor.Business.Contracts
{
    public interface ICategoryEngine
    {
        List<CategoryList> GetCategoryList();
        bool GetByName(GetByName name);
        bool Create(GetCreate createModel);
        bool Update(GetUpdate updateModel);
        bool Delete(Delete deleteModel);
    }
}
