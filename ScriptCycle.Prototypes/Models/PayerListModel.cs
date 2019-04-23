using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScriptCycle.Prototypes.Models
{
    public class PayerListViewModel
    {
        public List<PayerListModel> Payers { get; set; } = new List<PayerListModel>();
        public bool ShowDashboard { get; set; } = true;
        public bool ShowConfig { get; set; } = false;
    }
    public class PayerListModel
    {
        public string OrgID { get; set; } = "999";
        public string OrgName { get; set; } = "Hartig Drug";
        public string CarrierCode { get; set; } = "9999";
        public string CarrierName { get; set; } = "Hartig Drug Disc. Card";
        public string GroupNumber { get; set; } = "998-HD Retail";
        public string GroupName { get; set; } = "Hartig Drug Discount Hospice";
        public string NetTerms { get; set; } = "30 Days";
    }
}