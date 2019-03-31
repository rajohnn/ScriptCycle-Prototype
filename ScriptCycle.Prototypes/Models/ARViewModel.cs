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
    }

    public class ClientPaymentModel {
        public int? CycleId { get; set; }
        public string PaymentCycle { get; set; }
        public DateTime? Date { get; set; }
        public decimal? ClientBilled { get; set; }
        public int? UniqueInvoices { get; set; }
        public int? ClaimCount { get; set; }
    }
}