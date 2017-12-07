
using System;
using System.Collections.Generic;
using System.Linq;
using WebDoctor.Data;

namespace WebDoctor.Business
{
    public class ArticleEngine : IArticelEngine
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Article> _articleRepository;

        public ArticleEngine(IRepository<Article> articleRepository, IRepository<Category> categoryRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
        }


        public GetArticleListResponse GetArticle()
        {
            var result = _articleRepository.GetList().Where(x => !x.IsDeleted);


            return new GetArticleListResponse()
            {
                ArticleListItems = result.Select(x => new ArticleListItem()
                {
                    Id = x.Id,
                    Header = x.Header,
                    Content = x.Content,
                    CategoryId = x.CategoryId,
                    CreatedDate = x.CreatedDate,
                    IsActive = x.IsActive
                }).ToList()
            };
        }

        public List<CategoryListResponse> GetNameList()
        {
            var result = this._categoryRepository.GetList();

            return result.Select(category => new CategoryListResponse()
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();

        }


        public bool Create(CreateArticleRequest request)
        {
            var article = new Article()
            {
                Header = request.Header,
                Content = request.Content,
                CategoryId = request.CategoryId,
                IsActive = request.IsActive,

                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            var result = _articleRepository.Create(article);

            return result;
        }



        public bool GetByName(GetByArticleNameRequest request)
        {
            var result = _articleRepository.GetAll().Any(x => x.Header == request.Name && x.CategoryId == request.CategoryId);

            return result;
        }


        public GetByArticleIdResponse GetById(GetByArticleIdRequest request)
        {
            var result = _articleRepository.GetById(request.Id);

            return new GetByArticleIdResponse()
            {
                Id = result.Id,
                CategoryId = result.CategoryId,
                IsActive = result.IsActive,
                Content = result.Content,
                Header = result.Header
            };
        }

        public bool Update(UpdateArticleRequest articleRequest)
        {
            var id = new Article() { Id = articleRequest.Id };

            var article = this._articleRepository.GetById(articleRequest.Id);

            article.Header = articleRequest.Header;
            article.Content = articleRequest.Content;
            article.CategoryId = articleRequest.CategoryId;
            article.IsActive = articleRequest.IsActive;

            article.UpdatedDate = DateTime.Now;

            var result = this._articleRepository.Update(article);

            return result;
        }

        public bool Delete(DeleteArticleRequest request)
        {
            var id = new Article() { Id = request.Id };

            var article = this._articleRepository.GetById(request.Id);

            article.IsActive = false;
            article.IsDeleted = true;

            var result = this._articleRepository.UpdateDelete(article);

            return result;
        }


    }
}

