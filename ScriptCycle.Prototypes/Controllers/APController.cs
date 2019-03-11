using ScriptCycle.Prototypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class APController : Controller {

        // GET: AP
        public ActionResult Index() {
            var now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var vm = new APViewModel {
                BillingCycleRecords = new List<BillingCycleRecord> {
                    new BillingCycleRecord {
                        ClaimCount = 83441,
                        ClaimId = 11,
                        Date = startDate,
                        CycleStatus = "Processing",
                        PharmacyPaid = 481165.88M,
                        UniquePayments = 12485
                    },
                     new BillingCycleRecord {
                        ClaimCount = 77232,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-1),
                        CycleStatus = "Complete",
                        PharmacyPaid = 393643.16M,
                        UniquePayments = 12012
                    },
                      new BillingCycleRecord {
                        ClaimCount = 88123,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-2),
                        CycleStatus = "Complete",
                        PharmacyPaid = 549346.71M,
                        UniquePayments = 14232
                    },
                       new BillingCycleRecord {
                        ClaimCount = 83522,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-3),
                        CycleStatus = "Complete",
                        PharmacyPaid = 523121.11M,
                        UniquePayments = 13872
                    },
                        new BillingCycleRecord {
                        ClaimCount = 80122,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-4),
                        CycleStatus = "Complete",
                        PharmacyPaid = 462211.52M,
                        UniquePayments = 12442
                    },
                         new BillingCycleRecord {
                        ClaimCount = 81332,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-5),
                        CycleStatus = "Complete",
                        PharmacyPaid = 484221.22M,
                        UniquePayments = 12485
                    },
                          new BillingCycleRecord {
                        ClaimCount = 90112,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-6),
                        CycleStatus = "Complete",
                        PharmacyPaid = 554632.63M,
                        UniquePayments = 14201
                    },
                           new BillingCycleRecord {
                        ClaimCount = 74220,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-7),
                        CycleStatus = "Complete",
                        PharmacyPaid = 395122.12M,
                        UniquePayments = 12422
                    },
                            new BillingCycleRecord {
                        ClaimCount = 79899,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-8),
                        CycleStatus = "Complete",
                        PharmacyPaid = 463343.23M,
                        UniquePayments = 13422
                    },
                             new BillingCycleRecord {
                        ClaimCount = 94988,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-9),
                        CycleStatus = "Complete",
                        PharmacyPaid = 621212.12M,
                        UniquePayments = 15232
                    },
                              new BillingCycleRecord {
                        ClaimCount = 82990,
                        ClaimId = 11,
                        Date = startDate.AddMonths(-10),
                        CycleStatus = "Complete",
                        PharmacyPaid = 512363.63M,
                        UniquePayments = 14232
                    },
                }
            };
            vm.AnnualTotal = vm.BillingCycleRecords.Sum(bc => bc.PharmacyPaid);
            vm.AvgMonth = vm.AnnualTotal / vm.BillingCycleRecords.Count;

            var claimCountTotal = vm.BillingCycleRecords.Sum(bc => bc.ClaimCount);
            var paymentCountTotal = vm.BillingCycleRecords.Sum(bc => bc.UniquePayments);

            vm.AvgClaimCount = claimCountTotal / vm.BillingCycleRecords.Count;
            vm.AvgPaymentCount = paymentCountTotal / vm.BillingCycleRecords.Count;

            return View(vm);
        }
    }
}