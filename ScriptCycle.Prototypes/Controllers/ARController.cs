using ScriptCycle.Prototypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class ARController : Controller {

        // GET: AR
        public ActionResult Index() {
            var now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var vm = new ARViewModel {
                ClientPayments = new List<ClientPaymentModel> {
                    new ClientPaymentModel {
                        ClaimCount = 83441,
                        CycleId = 11,
                        Date = startDate,
                        PaymentCycle = "Processing",
                        ClientBilled = 481165.88M,
                        UniqueInvoices = 12485
                    },
                     new ClientPaymentModel {
                        ClaimCount = 77232,
                        CycleId = 11,
                        Date = startDate.AddMonths(-1),
                        PaymentCycle = "Complete",
                        ClientBilled = 393643.16M,
                        UniqueInvoices = 12012
                    },
                      new ClientPaymentModel {
                        ClaimCount = 88123,
                        CycleId = 11,
                        Date = startDate.AddMonths(-2),
                        PaymentCycle = "Complete",
                        ClientBilled = 549346.71M,
                        UniqueInvoices = 14232
                    },
                       new ClientPaymentModel {
                        ClaimCount = 83522,
                        CycleId = 11,
                        Date = startDate.AddMonths(-3),
                        PaymentCycle = "Complete",
                        ClientBilled = 523121.11M,
                        UniqueInvoices = 13872
                    },
                        new ClientPaymentModel {
                        ClaimCount = 80122,
                        CycleId = 11,
                        Date = startDate.AddMonths(-4),
                        PaymentCycle = "Complete",
                        ClientBilled = 462211.52M,
                        UniqueInvoices = 12442
                    },
                         new ClientPaymentModel {
                        ClaimCount = 81332,
                        CycleId = 11,
                        Date = startDate.AddMonths(-5),
                        PaymentCycle = "Complete",
                        ClientBilled = 484221.22M,
                        UniqueInvoices = 12485
                    },
                          new ClientPaymentModel {
                        ClaimCount = 90112,
                        CycleId = 11,
                        Date = startDate.AddMonths(-6),
                        PaymentCycle = "Complete",
                        ClientBilled = 554632.63M,
                        UniqueInvoices = 14201
                    },
                           new ClientPaymentModel {
                        ClaimCount = 74220,
                        CycleId = 11,
                        Date = startDate.AddMonths(-7),
                        PaymentCycle = "Complete",
                        ClientBilled = 395122.12M,
                        UniqueInvoices = 12422
                    },
                            new ClientPaymentModel {
                        ClaimCount = 79899,
                        CycleId = 11,
                        Date = startDate.AddMonths(-8),
                        PaymentCycle = "Complete",
                        ClientBilled = 463343.23M,
                        UniqueInvoices = 13422
                    },
                             new ClientPaymentModel {
                        ClaimCount = 94988,
                        CycleId = 11,
                        Date = startDate.AddMonths(-9),
                        PaymentCycle = "Complete",
                        ClientBilled = 621212.12M,
                        UniqueInvoices = 15232
                    },
                              new ClientPaymentModel {
                        ClaimCount = 82990,
                        CycleId = 11,
                        Date = startDate.AddMonths(-10),
                        PaymentCycle = "Complete",
                        ClientBilled = 512363.63M,
                        UniqueInvoices = 14232
                    },
                },
            };
            vm.AnnualTotal = vm.ClientPayments.Sum(bc => bc.ClientBilled);
            vm.AvgMonth = vm.AnnualTotal / vm.ClientPayments.Count;

            var claimCountTotal = vm.ClientPayments.Sum(bc => bc.ClaimCount);
            var paymentCountTotal = vm.ClientPayments.Sum(bc => bc.UniqueInvoices);

            vm.AvgClaimCount = claimCountTotal / vm.ClientPayments.Count;
            vm.AvgPaymentCount = paymentCountTotal / vm.ClientPayments.Count;
            return View(vm);
        }

        public ActionResult TemplateLibrary()
        {
            var model = new ARTemplateModel();
            return View(model);
        }
    }
}