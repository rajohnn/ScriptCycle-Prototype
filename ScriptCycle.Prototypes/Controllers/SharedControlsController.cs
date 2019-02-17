using ScriptCycle.Prototypes.Data;
using ScriptCycle.Prototypes.Models;
using ScriptCycle.Prototypes.Repo;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class SharedControlsController : Controller {
        
        public ActionResult DrugSearch() {
            var vm = new TestControlViewModel {
                DrugSelection = new DrugSelectionViewModel {
                    DrugSelectionOption = DrugSelectionOption.Standard
                }
            };

            var context = new ScriptCycleContext();
            //var repo = new DrugRepo(context);
            //var results = repo.FindByGPI("39400075");
            //vm.DrugSelection.MapResultsToViewModel(results);
            return View(vm);
        }
        [HttpGet]
        public JsonResult GetDrugList() {
            var context = new ScriptCycleContext();
            var repo = new DrugRepo(context);
            var drugs = repo.GetDrugNames();
            return Json(drugs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult FindDrugsByGPI(string drugId) {           
            var context = new ScriptCycleContext();
            var repo = new DrugRepo(context);
            var results = repo.FindByGPI(drugId);

            var vm = new DrugSelectionViewModel();
            vm.MapResultsToViewModel(results);
            var dto = new DrugSearchResultDto {
                DisplayName = vm.DisplayAs,
                DosageOptions = vm.DosageOptions,
                GPIs = vm.GPIs,
                NDCs = vm.NDCs,
                SearchResults = results,
                Strengths = vm.Strengths
            };
            return Json(dto);
        }
        [HttpPost]
        public JsonResult FindDrugsByNDC(string drugId) {
            var context = new ScriptCycleContext();
            var repo = new DrugRepo(context);
            var results = repo.FindByNDC(drugId);

            var vm = new DrugSelectionViewModel();
            vm.MapResultsToViewModel(results);
            var dto = new DrugSearchResultDto {
                DisplayName = vm.DisplayAs,
                DosageOptions = vm.DosageOptions,
                GPIs = vm.GPIs,
                NDCs = vm.NDCs,
                SearchResults = results,
                Strengths = vm.Strengths
            };
            return Json(dto);
        }
        [HttpPost]
        public JsonResult FindDrugsByName(string drugId) {
            var context = new ScriptCycleContext();
            var repo = new DrugRepo(context);
            var results = repo.FindByName(drugId);

            var vm = new DrugSelectionViewModel();
            vm.MapResultsToViewModel(results);
            var dto = new DrugSearchResultDto {
                DisplayName = vm.DisplayAs,
                DosageOptions = vm.DosageOptions,
                GPIs = vm.GPIs,
                NDCs = vm.NDCs,
                SearchResults = results,
                Strengths = vm.Strengths
            };
            return Json(dto);
        }
    }

    public class TestControlViewModel {
        public DrugSelectionViewModel DrugSelection { get; set; }
    }

}