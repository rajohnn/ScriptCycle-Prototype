using ScriptCycle.Prototypes.Models;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class StepTherapyController : Controller {

        // GET: StepTherapy
        public ActionResult Index() {
            var model = StepTherapyViewModel.GetTestModel();
            return View(model);
        }
    }
}