using System.Linq;
using System.Web.Mvc;
using WebDoctor.Business;
using WebDoctor.Models;

namespace WebDoctor.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticelEngine _articelEngine;

        public ArticleController(IArticelEngine articleEngine)
        {
            this._articelEngine = articleEngine;
        }

        // GET: Article
        public ActionResult Index()
        {
            var articles = _articelEngine.GetArticle();

            var list = articles.ArticleListItems.Select(x => new ArticleViewModel()
            {
                Id = x.Id,
                Header = x.Header,
                Content = x.Content,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                IsActive = x.IsActive
            }).ToList();

            return View(list.OrderByDescending(x => x.Id));
        }

        //Get CategoryName and Id
        [NonAction]
        public SelectList CategoriesList()
        {
            var categories = this._articelEngine.GetNameList();

            SelectList categoryList = new SelectList(categories, "Id", "Name");

            return categoryList;
        }

        public ActionResult Create()
        {
            CreateArticleModel model = new CreateArticleModel();

            model.Categories = this.CategoriesList();

            return View(model);
        }


        //Control by Name
        [HttpGet]
        public ActionResult GetByName(GetByArticleNameModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Json(nameModel, "Model is null!");
            //}

            //GetByArticleNameRequest model = new GetByArticleNameRequest() { Name = nameModel.Name };

            //var result = _articelEngine.GetByName(model);

            ////burası farklı bir şekilde mesaj döndürmeli
            //return Json(result, "{0}");

            var article = _articelEngine.GetByName(new GetByArticleNameRequest() { Name = model.Name, CategoryId = model.CategoryId });
            return Json(article, JsonRequestBehavior.AllowGet);

            //if (article)
            //{
            //    return Content("<script language='javascript' type='text/javascript'>alert('This record is already exists!');</script>");
            //}

            //return "";

        }

        [HttpPost]
        public ActionResult Create(CreateArticleModel articleModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Model is null!');</script>");
            }

            CreateArticleRequest article = new CreateArticleRequest()
            {
                Header = articleModel.Header,
                Content = articleModel.Content,
                CategoryId = articleModel.CategoryId,
                IsActive = articleModel.IsActive
            };

            var result = this._articelEngine.Create(article);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return Content("<script language='javascript' type='text/javascript'>alert('Create processing is failed!');</script>");

        }



        [NonAction]
        public GetByArticleIdViewModel GetById(GetByArticleIdModel idModel)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            GetByArticleIdRequest id = new GetByArticleIdRequest() { Id = idModel.Id };

            var result = _articelEngine.GetById(id);

            return new GetByArticleIdViewModel
            {
                Id = result.Id,
                Header = result.Header,
                Content = result.Content,
                CategoryId = result.CategoryId,
                IsActive = result.IsActive
            };
        }

        public ActionResult Update(GetByArticleIdModel idModel)
        {
            if (idModel == null)
            {
                return Json("Id cannot be null!");
            }

            GetByArticleIdModel id = new GetByArticleIdModel() { Id = idModel.Id };

            var articleId = this.GetById(id);

            if (articleId == null)
            {
                return this.Content("<script language='javascript' type='text/javascript'> alert('{0} id was not found!');</script>" + idModel.Id);
            }

            UpdateArticleViewModel articleViewModel = new UpdateArticleViewModel()
            {
                Id = articleId.Id,
                Header = articleId.Header,
                Content = articleId.Content,
                IsActive = articleId.IsActive,
                CategoryId = articleId.CategoryId
            };

            articleViewModel.Categories = this.CategoriesList();

            return View(articleViewModel);
        }

        [HttpPost]
        public ActionResult Update(UpdateArticleModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return Json("Model is null!");
            }

            UpdateArticleRequest request = new UpdateArticleRequest()
            {
                Id = updateModel.Id,
                Header = updateModel.Header,
                Content = updateModel.Content,
                CategoryId = updateModel.CategoryId,
                IsActive = updateModel.IsActive
            };

            var result = _articelEngine.Update(request);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return this.Content("<script language='javascript' type='text/javascript'> alert('Update processing is failed!');</script>");
        }

        [HttpPost]
        public ActionResult Delete(DeleteArticleModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Id null!");
            }

            var id = new DeleteArticleRequest() { Id = model.Id };

            var isDeleted = this._articelEngine.Delete(id);

            if (isDeleted)
            {
                return RedirectToAction("Index");
            }

            return this.Content("<script language='javascript' type='text/javascript'> alert('Delete processing is failed!');</script>");
        }


    }
}