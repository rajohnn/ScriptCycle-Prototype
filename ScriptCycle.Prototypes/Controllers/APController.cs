using ScriptCycle.Prototypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class APController : Controller {
       
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
                },
                PayeeDetailRecords = new List<PayeeDetailRecord> {
                    new PayeeDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        APCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        CheckNumber = "164582",
                        PaymentCenterId = "20465",
                        PaymentCenterName = "CVS Corp",
                        TotalClaims = 256,
                        TotalPharmacyPaid = 400581.11M
                    },
                    new PayeeDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        APCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        CheckNumber = "164583",
                        PaymentCenterId = "11442",
                        PaymentCenterName = "Walgreens Corp",
                        TotalClaims = 284,
                        TotalPharmacyPaid = 422581.95M
                    },
                    new PayeeDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        APCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        CheckNumber = "164584",
                        PaymentCenterId = "84544",
                        PaymentCenterName = "Costco Pharmacies",
                        TotalClaims = 211,
                        TotalPharmacyPaid = 18881.27M
                    },
                    new PayeeDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        APCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        CheckNumber = "164585",
                        PaymentCenterId = "91377",
                        PaymentCenterName = "Rite Aid",
                        TotalClaims = 316,
                        TotalPharmacyPaid = 199058.63M
                    },
                    new PayeeDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        APCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        CheckNumber = "164586",
                        PaymentCenterId = "20465",
                        PaymentCenterName = "CVS Corp",
                        TotalClaims = 256,
                        TotalPharmacyPaid = 374343.72M
                    },
                    new PayeeDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        APCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        CheckNumber = "164587",
                        PaymentCenterId = "11442",
                        PaymentCenterName = "Walgreens Corp",
                        TotalClaims = 284,
                        TotalPharmacyPaid = 422847.83M
                    },
                    new PayeeDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        APCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        CheckNumber = "164588",
                        PaymentCenterId = "84544",
                        PaymentCenterName = "Costco Pharmacies",
                        TotalClaims = 211,
                        TotalPharmacyPaid = 12532.18M
                    },
                    new PayeeDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        APCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        CheckNumber = "164589",
                        PaymentCenterId = "91377",
                        PaymentCenterName = "Rite Aid",
                        TotalClaims = 316,
                        TotalPharmacyPaid = 199058.38M
                    }
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

        [HttpGet]
        public JsonResult GetCycles() {
            var list = new List<BillingCycleDto> {
                new BillingCycleDto { Date = "11/01/2018", ID = 11, Name = "11-01-2018, Batch Name" },
                new BillingCycleDto { Date = "10/01/2018", ID = 10, Name = "10-01-2018, Batch Name" },
                new BillingCycleDto { Date = "09/01/2018", ID = 9, Name = "09-01-2018, Batch Name" },
                new BillingCycleDto { Date = "08/01/2018", ID = 8, Name = "08-01-2018, Batch Name" },
                new BillingCycleDto { Date = "07/01/2018", ID = 7, Name = "07-01-2018, Batch Name" },
                new BillingCycleDto { Date = "06/01/2018", ID = 6, Name = "06-01-2018, Batch Name" }
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetClaimDetails() {
            var list = new List<ClaimDetailDto> {
                new ClaimDetailDto {
                    Name ="20180101",
                    BillingDate ="01/01/2018",
                    ClaimDate = "01/10/2018",
                    Rx = "465821",
                    RxDate = "10/01/2018",
                    NCPDP = "1524677",
                    PharmacyName = "CVS #45887",
                    PharmacyChain = "039",
                    PharmacyChainCode = "039 CVS",
                    Col20180101 = "54688-1046-10",
                    Code = "Zocor 10MG",
                    NDC = "30",
                    DrugName = "$82.17"
                },
                new ClaimDetailDto {
                    Name ="20180101",
                    BillingDate ="01/01/2018",
                    ClaimDate = "01/10/2018",
                    Rx = "465822",
                    RxDate = "10/01/2018",
                    NCPDP = "1524678",
                    PharmacyName = "CVS #45887",
                    PharmacyChain = "039",
                    PharmacyChainCode = "039 CVS",
                    Col20180101 = "54688-1046-10",
                    Code = "Zocor 10MG",
                    NDC = "30",
                    DrugName = "$82.17"
                },
                new ClaimDetailDto {
                    Name ="20180101",
                    BillingDate ="01/01/2018",
                    ClaimDate = "01/10/2018",
                    Rx = "465823",
                    RxDate = "10/01/2018",
                    NCPDP = "1524679",
                    PharmacyName = "CVS #45887",
                    PharmacyChain = "039",
                    PharmacyChainCode = "039 CVS",
                    Col20180101 = "54688-1046-10",
                    Code = "Zocor 10MG",
                    NDC = "30",
                    DrugName = "$82.17"
                },
                new ClaimDetailDto {
                    Name ="20180101",
                    BillingDate ="01/01/2018",
                    ClaimDate = "01/10/2018",
                    Rx = "465824",
                    RxDate = "10/01/2018",
                    NCPDP = "1524687",
                    PharmacyName = "CVS #45887",
                    PharmacyChain = "039",
                    PharmacyChainCode = "039 CVS",
                    Col20180101 = "54688-1046-10",
                    Code = "Zocor 10MG",
                    NDC = "30",
                    DrugName = "$82.17"
                },
                new ClaimDetailDto {
                    Name ="20180101",
                    BillingDate ="01/01/2018",
                    ClaimDate = "01/10/2018",
                    Rx = "465825",
                    RxDate = "10/01/2018",
                    NCPDP = "1524697",
                    PharmacyName = "WAG #5541",
                    PharmacyChain = "226",
                    PharmacyChainCode = "226 Walgreens",
                    Col20180101 = "54688-1046-10",
                    Code = "Zocor 10MG",
                    NDC = "30",
                    DrugName = "$82.17"
                },
                new ClaimDetailDto {
                    Name ="20180101",
                    BillingDate ="01/01/2018",
                    ClaimDate = "01/10/2018",
                    Rx = "465826",
                    RxDate = "10/01/2018",
                    NCPDP = "213533",
                    PharmacyName = "WAG #5541",
                    PharmacyChain = "226",
                    PharmacyChainCode = "226 Walgreens",
                    Col20180101 = "54688-1046-10",
                    Code = "Zocor 10MG",
                    NDC = "30",
                    DrugName = "$82.17"
                },
                new ClaimDetailDto {
                    Name ="20180101",
                    BillingDate ="01/01/2018",
                    ClaimDate = "01/10/2018",
                    Rx = "465827",
                    RxDate = "10/01/2018",
                    NCPDP = "2342333",
                    PharmacyName = "WAG #5541",
                    PharmacyChain = "226",
                    PharmacyChainCode = "226 Walgreens",
                    Col20180101 = "54688-1046-10",
                    Code = "Zocor 10MG",
                    NDC = "30",
                    DrugName = "$82.17"
                },
                new ClaimDetailDto {
                    Name ="20180101",
                    BillingDate ="01/01/2018",
                    ClaimDate = "01/10/2018",
                    Rx = "465828",
                    RxDate = "10/01/2018",
                    NCPDP = "34243324",
                    PharmacyName = "WAG #5541",
                    PharmacyChain = "226",
                    PharmacyChainCode = "226 Walgreens",
                    Col20180101 = "54688-1046-10",
                    Code = "Zocor 10MG",
                    NDC = "30",
                    DrugName = "$82.17"
                }
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }

    
}