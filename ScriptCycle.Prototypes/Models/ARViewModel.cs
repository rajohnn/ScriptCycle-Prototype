using System;
using System.Collections.Generic;

namespace ScriptCycle.Prototypes.Models {

    public class ARViewModel {
        public decimal? AnnualTotal { get; set; } = 0.00m;
        public decimal? AvgMonth { get; set; } = 0.00m;
        public decimal? AvgClaimCount { get; set; } = 0.00m;
        public decimal? AvgPaymentCount { get; set; } = 0.00m;
        public bool? ShowDashboard { get; set; } = true;
        public bool? ShowARDetails { get; set; } = false;
        public bool? ShowDetails { get; set; } = false;
        public bool? ShowConfig { get; set; } = false;
        public List<ClientPaymentModel> ClientPayments { get; set; } = new List<ClientPaymentModel>();
        public ClaimDetailDto SelectedClaim { get; set; }
        public ClaimDetailModel ClaimDetail = new ClaimDetailModel {
            PaymentInfo = new PaymentInfoModel {
                CheckDate = DateTime.Now.AddMonths(-2),
                CheckNumber = 16458,
                CheckTotal = 393643.16M,
                ClaimAmount = 393643.16M,
                PaidToChain = "CVS",
                PaymentCycle = "10012018",
                PaymentType = "Check"
            },
            PharmacyInfo = new PharmacyInfoModel {
                ChainCode = "039",
                ChainName = "CVS",
                Name = "CVC #45887",
                NCPDP = "1524677",
                PaymentCenterId = "0522212",
                PaymentCenterName = "CVS Master Payment Center"
            }
        };
        public List<BillingCycleRecord> BillingCycleRecords { get; set; } = new List<BillingCycleRecord>();
        public List<InvoiceDetailRecord> InvoiceDetailRecords { get; set; } = new List<InvoiceDetailRecord>();
    }

    public class ClientPaymentModel {
        public int? CycleId { get; set; }
        public string PaymentCycle { get; set; }
        public DateTime? Date { get; set; }
        public decimal? ClientBilled { get; set; }
        public int? UniqueInvoices { get; set; }
        public int? ClaimCount { get; set; }
    }

    public class ARTemplateModel
    {
        public string Name { get; set; }
    }
}