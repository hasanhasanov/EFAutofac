using System.Collections.Generic;

namespace WebDoctor.Business
{
    public interface ICategoryEngine
    {
        List<GetCategoryListResponse> GetCategoryList(); //bu sonradan list içeren bir class geriye döndürecek
        bool GetByName(GetByCategoryNameRequest name);
        bool Create(CreateCategoryRequest createModel);
        bool Update(CategoryUpdateRequest updateModel);
        bool Delete(DeleteCategoryRequest deleteModel);
        GetByCategoryIdRequest GetById(int id);
    }
}
