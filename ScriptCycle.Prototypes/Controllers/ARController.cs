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

        public ActionResult Details()
        {
            var vm = GetMockAPViewModel();
            return View(vm);
        }

        public ActionResult TemplateLibrary()
        {
            var vm = new ARTemplateModel();
            return View(vm);
        }

        public ActionResult PayerList()
        {
            var vm = new PayerListViewModel();
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            vm.Payers.Add(new PayerListModel { });
            return View(vm);
        }

        private ARViewModel GetMockAPViewModel()
        {
            var now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var vm = new ARViewModel
            {
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
                InvoiceDetailRecords = new List<InvoiceDetailRecord> {
                    new InvoiceDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        ARCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        InvoiceNumber = "164582",
                        PayerID = "20465",
                        PayerName = "CVS Corp",
                        TotalClaims = 256,
                        TotalInvoiceAmount = 400581.11M,
                        DueDate = DateTime.Now.AddDays(31),
                        Status = "Unpaid"
                    },
                    new InvoiceDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        ARCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        InvoiceNumber = "164583",
                        PayerID = "11442",
                        PayerName = "Walgreens Corp",
                        TotalClaims = 284,
                        TotalInvoiceAmount = 422581.95M,
                        DueDate = DateTime.Now.AddDays(31),
                        Status = "Unpaid"
                    },
                    new InvoiceDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        ARCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        InvoiceNumber = "164584",
                        PayerID = "84544",
                        PayerName = "Costco Pharmacies",
                        TotalClaims = 211,
                        TotalInvoiceAmount = 18881.27M,
                        DueDate = DateTime.Now.AddDays(31),
                        Status = "Unpaid"
                    },
                    new InvoiceDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        ARCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        InvoiceNumber = "164585",
                        PayerID = "91377",
                        PayerName = "Rite Aid",
                        TotalClaims = 316,
                        TotalInvoiceAmount = 199058.63M,
                        DueDate = DateTime.Now.AddDays(31),
                        Status = "Unpaid"
                    },
                    new InvoiceDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        ARCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        InvoiceNumber = "164586",
                        PayerID = "20465",
                        PayerName = "CVS Corp",
                        TotalClaims = 256,
                        TotalInvoiceAmount = 374343.72M,
                        DueDate = DateTime.Now.AddDays(31),
                        Status = "Partial Payment"
                    },
                    new InvoiceDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        ARCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        InvoiceNumber = "164587",
                        PayerID = "11442",
                        PayerName = "Walgreens Corp",
                        TotalClaims = 284,
                        TotalInvoiceAmount = 422847.83M,
                        DueDate = DateTime.Now.AddDays(31),
                        Status = "Paid in Full"
                    },
                    new InvoiceDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        ARCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        InvoiceNumber = "164588",
                        PayerID = "84544",
                        PayerName = "Costco Pharmacies",
                        TotalClaims = 211,
                        TotalInvoiceAmount = 12532.18M,
                        DueDate = DateTime.Now.AddDays(31),
                        Status = "Paid in Full"
                    },
                    new InvoiceDetailRecord {
                        BillingCycleDate = startDate.AddMonths(-3),
                        ARCycleName = String.Concat(startDate.AddMonths(-3).Year, startDate.AddMonths(-3).Month, startDate.AddMonths(-3).Day),
                        InvoiceNumber = "164589",
                        PayerID = "91377",
                        PayerName = "Rite Aid",
                        TotalClaims = 316,
                        TotalInvoiceAmount = 199058.38M,
                        DueDate = DateTime.Now.AddDays(31),
                        Status = "Paid in Full"
                    }
                }
            };
            vm.AnnualTotal = vm.BillingCycleRecords.Sum(bc => bc.PharmacyPaid);
            vm.AvgMonth = vm.AnnualTotal / vm.BillingCycleRecords.Count;

            var claimCountTotal = vm.BillingCycleRecords.Sum(bc => bc.ClaimCount);
            var paymentCountTotal = vm.BillingCycleRecords.Sum(bc => bc.UniquePayments);

            vm.AvgClaimCount = claimCountTotal / vm.BillingCycleRecords.Count;
            vm.AvgPaymentCount = paymentCountTotal / vm.BillingCycleRecords.Count;
            return vm;
        }
    }
}