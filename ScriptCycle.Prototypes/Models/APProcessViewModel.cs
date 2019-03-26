using System;
using System.Collections.Generic;

namespace ScriptCycle.Prototypes.Models {

    public class APProcessViewModel {
        public int Progress { get; set; } = 0;
        public int Step { get; set; } = 1;
        public int FileProgress { get; set; } = 0;
        public int PostProgress { get; set; } = 0;
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
        public ClaimDetailDto SelectedClaim { get; set; }
        public List<ProcessRecord> ProcessRecords = new List<ProcessRecord>();
    }

    public class ProcessRecord {
        public string ClaimCycleDate { get; set; }
        public string RxNumber { get; set; }
        public string RxDate { get; set; }
        public string NCPDP { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyChainCode { get; set; }
        public string PharmacyChainCodeLabel { get; set; }
        public string NDC { get; set; }
        public string DrugName { get; set; }
        public int Qty { get; set; } = 0;
        public decimal? PaidIngredientCost { get; set; } = 0.00m;
        public decimal? PaidDispenseFee { get; set; } = 0.00m;
        public decimal? PaidTax { get; set; } = 0.00m;
        public decimal? TotalPharmacyPaid { get; set; } = 0.00m;
    }

    public class ProcessSampleRecord {
        public int Yrmth { get; set; }
        public string Bin { get; set; }
        public string Cust { get; set; }
        public string Client { get; set; }
        public string Grp { get; set; }
        public int Nabp { get; set; }
        public int Rxnbr { get; set; }
        public string Dt_Fill { get; set; }
        public string Mbr { get; set; }
        public int Per_Cd { get; set; }
        public string Mbr_Fir_Name { get; set; }
        public string Mbr_Last_Name { get; set; }
        public string Dob { get; set; }
        public int Sex { get; set; }
        public double Tot_Amtdue { get; set; }
        public double Grs_Amtdue { get; set; }
        public double App_Ing_Cst { get; set; }
        public double Sub_Ing_Cst { get; set; }
        public double App_Cop { get; set; }
        public double App_Sl_Tax { get; set; }
        public double App_Fee { get; set; }
        public double Pt_Pd_Dif { get; set; }
        public int Amt_App_Ded { get; set; }
        public string Prc_Typ { get; set; }
        public int? Oth_Cov_Cd { get; set; }
        public object Ndc { get; set; }
        public string Lbl_Nme { get; set; }
        public string Gen_Cd { get; set; }
        public int New_Ref { get; set; }
        public int Max_Ref { get; set; }
        public int Comp_Cd { get; set; }
        public int Sub_Dy_Sup { get; set; }
        public double Sub_Qy { get; set; }
        public int Daw { get; set; }
        public string Lvl_Ser { get; set; }
        public int Rx_Org { get; set; }
        public string Pres_Lst_Nme { get; set; }
        public string Name { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Cty { get; set; }
        public string St { get; set; }
        public int Zip { get; set; }
        public string Rejcd1 { get; set; }
        public string Rejcd2 { get; set; }
        public string Rejcd3 { get; set; }
        public string Rejcd4 { get; set; }
        public string Rejcd5 { get; set; }
        public string Rejcd6 { get; set; }
        public string Tme_Sub { get; set; }
        public string Dt_Sub { get; set; }
        public string Dur_Cf { get; set; }
        public string Dur_Intr { get; set; }
        public string Dur_Out { get; set; }
        public string Pres_Stat { get; set; }
        public int Pres_Id { get; set; }
        public string Sub_Sls_Tx { get; set; }
        public double? Sub_Fee { get; set; }
        public double Uandc { get; set; }
        public int? Phr_Chn { get; set; }
        public int Ther_Cls { get; set; }
        public string Gpi { get; set; }
        public string Gen_Nme { get; set; }
        public string Cf_Cd1 { get; set; }
        public string Cf_Cd2 { get; set; }
        public string Cf_Cd3 { get; set; }
        public string Cf_Cd4 { get; set; }
        public string Cf_Cd5 { get; set; }
        public string Cf_Cd6 { get; set; }
        public string Cf_Cd7 { get; set; }
        public string Cf_Cd8 { get; set; }
        public string Cf_Cd9 { get; set; }
        public string Cf_Cd10 { get; set; }
        public string Cust_Nme { get; set; }
        public string Cli_Nme { get; set; }
        public string Grp_Nme { get; set; }
        public string Mt_Drg { get; set; }
        public int Mail_Ord { get; set; }
        public double Awp_Cst { get; set; }
        public string Dt_Rx_Wrt { get; set; }
        public string Rx_Otc { get; set; }
        public double Acq_Cst { get; set; }
        public int Pat_Age { get; set; }
        public int Pharm_Npi { get; set; }
        public int Phys_Npi { get; set; }
        public int Phys_Dea { get; set; }
        public string Alt_Mbr_Id { get; set; }
        public string Therapeutic_Class_Name { get; set; }
        public double Amt_App_Oop { get; set; }
        public string Clm_Ref_Nr { get; set; }
    }
}