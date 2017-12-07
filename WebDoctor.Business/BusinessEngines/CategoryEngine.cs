using System;
using System.Collections.Generic;
using System.Linq;
using WebDoctor.Data;

namespace WebDoctor.Business
{
    public class CategoryEngine : ICategoryEngine
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryEngine(IRepository<Category> categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public bool Create(CreateCategoryRequest createModel)
        {
            Category category = new Category
            {
                Name = createModel.Name,
                Description = createModel.Description,
                IsActive = createModel.IsActive,

                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            var result = this._categoryRepository.Create(category);

            return result;
        }

        public bool Delete(DeleteCategoryRequest deleteModel)
        {
            var isDeleted = this._categoryRepository.GetById(deleteModel.Id);

            isDeleted.IsActive = false;
            isDeleted.IsDeleted = true;

            var result = this._categoryRepository.UpdateDelete(isDeleted);

            return result;
        }

        public GetByCategoryIdRequest GetById(int id)
        {
            var category = this._categoryRepository.GetById(id);


            if (category == null)
            {
                throw new ArgumentException(id + " Id bulunamadı!");
            }

            GetByCategoryIdRequest model = new GetByCategoryIdRequest
            {
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,
                CreatedDate = category.CreatedDate
            };

            return model;
        }

        public bool GetByName(GetByCategoryNameRequest modelByName)
        {
            var result = this._categoryRepository.GetAll().Any(x => x.Name == modelByName.Name);

            return result;
        }

        public List<GetCategoryListResponse> GetCategoryList()
        {
            var category = this._categoryRepository.GetList().Where(x => !x.IsDeleted);

            if (category == null)
            {
                return null;
            }

            List<GetCategoryListResponse> categoryList = new List<GetCategoryListResponse>();

            foreach (var item in category)
            {
                categoryList.Add(new GetCategoryListResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    IsActive = item.IsActive,
                    CreatedDate = Convert.ToDateTime(item.CreatedDate.ToShortDateString())
                });
            }

            return categoryList;
        }

        public bool Update(CategoryUpdateRequest updateModel)
        {
            var category = this._categoryRepository.GetById(updateModel.Id);

            if (category == null)
            {
                throw new ArgumentException(updateModel.Id + " Id bulunamadı!");
            }

            category.Name = updateModel.Name;
            category.Description = updateModel.Description;
            category.IsActive = updateModel.IsActive;

            category.UpdatedDate = DateTime.Now;

            var result = this._categoryRepository.Update(category);

            return result;
        }
    }
}
