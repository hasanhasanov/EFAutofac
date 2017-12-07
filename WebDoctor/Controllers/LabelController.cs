using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebDoctor.Business;
using WebDoctor.Models;

namespace WebDoctor.Controllers
{
    public class LabelController : Controller
    {


        private readonly ILabelEngine _labelEngine;

        public LabelController(ILabelEngine labelEngine)
        {
            _labelEngine = labelEngine;
        }

        // GET: Label
        public ActionResult Index()
        {
            var list = _labelEngine.GetLabelList();

            List<GetLabelListModel> model = list.LabelList.Select(x => new GetLabelListModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CategoryId = x.CategoryId
            }).ToList();

            return View(model.OrderByDescending(x=>x.Id));
        }
    }
}