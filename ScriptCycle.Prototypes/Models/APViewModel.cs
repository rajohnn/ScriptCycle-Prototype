using System;
using System.Collections.Generic;

namespace ScriptCycle.Prototypes.Models {

    public class APViewModel {
        public decimal? AnnualTotal { get; set; }
        public decimal? AvgMonth { get; set; }
        public decimal? AvgPaymentCount { get; set; }
        public decimal? AvgClaimCount { get; set; }
        public bool? ShowDetails { get; set; } = false;
        public List<BillingCycleRecord> BillingCycleRecords { get; set; } = new List<BillingCycleRecord>();
    }

    public class BillingCycleRecord {
        public string CycleStatus { get; set; }
        public DateTime? Date { get; set; }
        public decimal? PharmacyPaid { get; set; }
        public int? UniquePayments { get; set; }
        public int? ClaimCount { get; set; }
        public int? ClaimId { get; set; }
    }
}