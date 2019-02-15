using ScriptCycle.Prototypes.Models;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class SharedControlsController : Controller {

        // GET: SharedControls
        public ActionResult DrugSearch() {
            var vm = new TestControlViewModel {
                DrugSelection = new DrugSelectionViewModel()
            };
            return View(vm);
        }
    }

    public class TestControlViewModel {
        public DrugSelectionViewModel DrugSelection { get; set; }
    }

}