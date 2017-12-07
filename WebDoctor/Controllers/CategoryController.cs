using System.Linq;
using System.Web.Mvc;
using WebDoctor.Business;
using WebDoctor.Models;

namespace WebDoctor.Controllers
{
    public class CategoryController : Controller
    {
        //Autofac kullanımı için konstruktor içinde injekte ediyoruz
        private readonly ICategoryEngine _categoryEngine;

        public CategoryController(ICategoryEngine categoryEngine)
        {
            this._categoryEngine = categoryEngine;
        }
        
        //Ekleme sırasında aynı isimde var mı diye kontrol ediyor
        [HttpGet]
        public JsonResult GetByName(GetByCategoryNameModel byNameRequest)
        {
            var category = _categoryEngine.GetByName(new GetByCategoryNameRequest() { Name = byNameRequest.Name });
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        // GET: Category- Categorilerin listelenmesi
        [HttpGet]
        public ActionResult Index()
        {
            var categoryList = this._categoryEngine.GetCategoryList();

            return this.View(categoryList.OrderByDescending(x => x.Id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryRequest categoryRequest)
        {
            CreateCategoryRequest create = new CreateCategoryRequest
            {
                Name = categoryRequest.Name,
                Description = categoryRequest.Description,
                IsActive = categoryRequest.IsActive
            };

            var result = this._categoryEngine.Create(create);

            if (result)
            {
                return this.RedirectToAction("Index");
            }

            return this.Content("<script language='javascript' type='text/javascript'> alert('Create processing is failed!');</script>");

        }



        [HttpGet]
        public CategoryViewModel GetById(int id)
        {
            var result = this._categoryEngine.GetById(id);

            CategoryViewModel response = new CategoryViewModel
            {
                Name = result.Name,
                Description = result.Description,
                IsActive = result.IsActive
            };

            return response;
        }

        [HttpGet]
        public ActionResult Update(GetByCategoryIdModel updateModel)
        {
            var result = this.GetById(updateModel.Id);

            if (result == null)
            {
                return View();
            }

            return this.View(result);
        }

        [HttpPost]
        public ActionResult Update(UpdateCategoryModel categoryRequest)
        {
            CategoryUpdateRequest getUpdate = new CategoryUpdateRequest
            {
                Id = categoryRequest.Id,
                Name = categoryRequest.Name,
                Description = categoryRequest.Description,
                IsActive = categoryRequest.IsActive
            };

            var result = this._categoryEngine.Update(getUpdate);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return this.Content("<script language='javascript' type='text/javascript'> alert('Update processing is failed!');</script>");
        }

        [HttpGet]
        public ActionResult Remove(DeleteCategoryModel request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Silinecek değer boş!";
            }

            DeleteCategoryRequest delete = new DeleteCategoryRequest()
            {
                Id = request.Id
            };

            var result = this._categoryEngine.Delete(delete);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return this.Content("<script language='javascript' type='text/javascript'> alert('Delete processing is failed!');</script>");
        }
    }
}