using System;
using System.Collections.Generic;

namespace ScriptCycle.Prototypes.Models {

    public class APViewModel {
        public decimal? AnnualTotal { get; set; }
        public decimal? AvgMonth { get; set; }
        public decimal? AvgPaymentCount { get; set; }
        public decimal? AvgClaimCount { get; set; }
        public bool? ShowDashboard { get; set; } = true;
        public bool? ShowDetails { get; set; } = false;
        public bool? ShowCheckResults { get; set; } = false;
        public List<BillingCycleRecord> BillingCycleRecords { get; set; } = new List<BillingCycleRecord>();
        public List<PayeeDetailRecord> PayeeDetailRecords { get; set; } = new List<PayeeDetailRecord>();
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
    }

    public class ClaimDetailModel {
        public PharmacyInfoModel PharmacyInfo { get; set; }
        public PaymentInfoModel PaymentInfo { get; set; }
    }

    public class PharmacyInfoModel {
        public string NCPDP { get; set; }
        public string Name { get; set; }
        public string ChainCode { get; set; }
        public string ChainName { get; set; }
        public string PaymentCenterId { get; set; }
        public string PaymentCenterName { get; set; }
    }

    public class PaymentInfoModel {
        public string PaymentCycle { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal? ClaimAmount { get; set; }
        public int? CheckNumber { get; set; }
        public decimal? CheckTotal { get; set; }
        public string PaymentType { get; set; }
        public string PaidToChain { get; set; }
    }

    public class BillingCycleRecord {
        public string CycleStatus { get; set; }
        public DateTime? Date { get; set; }
        public decimal? PharmacyPaid { get; set; }
        public int? UniquePayments { get; set; }
        public int? ClaimCount { get; set; }
        public int? ClaimId { get; set; }
    }

    public class PayeeDetailRecord {
        public DateTime? BillingCycleDate { get; set; }
        public string APCycleName { get; set; }
        public string PaymentCenterId { get; set; }
        public string PaymentCenterName { get; set; }
        public string CheckNumber { get; set; }
        public decimal? TotalPharmacyPaid { get; set; }
        public int? TotalClaims { get; set; }
    }
}