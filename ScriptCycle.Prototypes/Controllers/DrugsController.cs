using ScriptCycle.Prototypes.Data;
using ScriptCycle.Prototypes.Models;
using ScriptCycle.Prototypes.Repo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class DrugsController : Controller {

        public ActionResult Index() {
            var context = new ScriptCycleContext();
            var repo = new DrugRepo(context);
            var results = repo.GetGPI();

            
            return View(results);
        }

        
    }
}