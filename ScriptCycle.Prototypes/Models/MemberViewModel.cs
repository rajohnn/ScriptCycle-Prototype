using System;
using System.Collections.Generic;

namespace ScriptCycle.Prototypes.Models {

    public class MemberViewModel {
        public MemberSearchModel MemberSearchModel { get; set; } = new MemberSearchModel();
        public List<MemberSearchResultModel> MemberSearchResults { get; set; } = new List<MemberSearchResultModel>();
        public MemberModel MemberModel { get; set; } = new MemberModel();
        public List<MemberEligibilityModel> MemberEligibilities { get; set; } = new List<MemberEligibilityModel>();
        public List<MemberGroup> MemberGroups { get; set; } = new List<MemberGroup>();
        public List<MemberSubgroup> MemberSubgroups { get; set; } = new List<MemberSubgroup>();
        public MemberBenefitSummaryModel MemberBenefitSummaryModel { get; set; } = new MemberBenefitSummaryModel();
        public bool ShowSearch { get; set; } = true;

    }

    public class MemberSearchModel {
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string DateOfBirth { get; set; }
        public bool ActiveIndicator { get; set; } = true;
    }

    public class MemberSearchResultModel {
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string SSN { get; set; }
        public bool ActiveFlag { get; set; }
        public string CurrentActiveGroup { get; set; }
        public string PersonCode { get; set; }
    }

    public class MemberBenefitSummaryModel {
        public int? Id { get; set; }
        public string ActiveGroup { get; set; }
        public DateTime? BenefitStartDate { get; set; }
        public decimal? IndividualBenefit { get; set; }
        public decimal? IndividualCopay { get; set; }
        public decimal? IndividualDeductible { get; set; }
        public decimal? FamilyBenefit { get; set; }
        public decimal? FamilyCopay { get; set; }
        public decimal? FamilyDeducatible { get; set; }
    }

    public class MemberModel {
        public string MemberId { get; set; }
        public string PC { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool? ActiveIndicator { get; set; }
        public string CarrierCode { get; set; }
        public string CarrierName { get; set; }
        public string AlternateId { get; set; }
        public string PreviousId { get; set; }
        public string SSN { get; set; }
        public int? SelectedGender { get; set; }
        public List<SelectionModel> Genders { get; set; } = new List<SelectionModel>();
        public DateTime? DateOfBirth { get; set; }
        public int? SelectedEnrollment { get; set; }
        public List<SelectionModel> Enrollments { get; set; } = new List<SelectionModel>();
        public string CaseManager { get; set; }
        public int? SelectedLanguage { get; set; }
        public List<SelectionModel> Languages { get; set; } = new List<SelectionModel>();
        public DateTime? DateCreated { get; set; }
        public DateTime? CardPrinted { get; set; }
        public List<MembershipAdjustmentOption> MembershipAdjustmentOptions { get; set; } = new List<MembershipAdjustmentOption>();
        public AddressModel Address { get; set; } = new AddressModel();
        public string HomePhone { get; set; } 
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; } 
        public string EmailAddress { get; set; }
        public string RelationshipCode { get; set; }
        public PrimacyCarePhysician Physician { get; set; } = new PrimacyCarePhysician();
        public List<PrimacyCarePhysician> PhysicianResults { get; set; } = new List<PrimacyCarePhysician>();
        public PharmacyModel Pharmacy { get; set; } = new PharmacyModel();
        public List<PharmacyModel> PharmacyResults { get; set; } = new List<PharmacyModel>();
    }

    public class MemberSubgroup {
        public int? Id { get; set; }
        public string Number { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class MemberGroup {
        public int? Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public SelectionModel CoverageType { get; set; }
    }

    public class PharmacyModel {
        public int Id { get; set; }
        public string NCPDP { get; set; }
        public PhoneModel MainPhone { get; set; } = new PhoneModel();
        public PhoneModel Fax { get; set; } = new PhoneModel();
    }

    public class PrimacyCarePhysician {
        public int Id { get; set; }
        public string NPI { get; set; }
        public PhoneModel MainPhone { get; set; } = new PhoneModel();
        public PhoneModel Fax { get; set; } = new PhoneModel();
    }

    public class MemberEligibilityModel {
        public int Id { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    public class SelectionModel {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class MembershipAdjustmentOption {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class AddressModel {
        public AddressType AddressType { get; set; } = AddressType.Unknown;
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string Zip;
    }

    public class PhoneModel {
        public PhoneType PhoneType { get; set; } = PhoneType.Unknown;
        public string AreaCode { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
    }

    public class EmailAddressModel {
        public EmailAddressType EmailAddressType { get; set; } = EmailAddressType.Unknown;
        public string LocalPart { get; set; }
        public string Domain { get; set; }

    }

    public enum AddressType {
        Unknown,
        Home,
        Mail,
        Work,        
        Billing,
        Other
    }

    public enum PhoneType {
        Unknown,
        Home,
        Business,
        Work,
        Mobile,
        Fax
    }

    public enum EmailAddressType {
        Unknown,
        Primary,
        Personal,
        Business,
        Billing
    }

    public class State {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
    }
}