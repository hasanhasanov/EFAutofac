using System.Collections.Generic;

namespace WebDoctor.Business
{
    public interface IArticelEngine
    {
        GetArticleListResponse GetArticle();
        List<CategoryListResponse> GetNameList();
        bool Create(CreateArticleRequest request);
        bool GetByName(GetByArticleNameRequest request);
        GetByArticleIdResponse GetById(GetByArticleIdRequest request);
        bool Update(UpdateArticleRequest articleRequest);
        bool Delete(DeleteArticleRequest request);
    }
}
