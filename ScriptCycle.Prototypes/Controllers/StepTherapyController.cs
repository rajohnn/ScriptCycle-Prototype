using ScriptCycle.Prototypes.Models;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class StepTherapyController : Controller {

        public ActionResult Index() {
            var model = StepTherapyViewModel.GetTestModel();
            return View(model);
        }

        [HttpPost]
        public JsonResult CreateProgram(string name) {
            var program = new Program {
                Name = name
            };
            return Json(program);
        }

    }
}