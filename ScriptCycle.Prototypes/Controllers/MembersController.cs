﻿using ScriptCycle.Prototypes.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class MembersController : Controller {
       
        public ActionResult Index() {
            var vm = new MemberViewModel {
                MemberModel = new MemberModel {
                    MemberId = "12345",
                    FirstName = "Francisco",
                    PC = "98765",
                    MiddleName = "Franco",
                    LastName = "Bahamonde",
                    ActiveIndicator = true,
                    AlternateId = "21322",
                    CarrierCode = "CC-1232",
                    SSN = "555-55-1212",
                    DateOfBirth = new DateTime(1975, 02, 01),
                    CarrierName = "Foobar Carrier",
                    CaseManager = "Michael Enright",
                    DateCreated = DateTime.Now.AddYears(-4),
                    PreviousId = "",
                    CardPrinted = DateTime.Now.AddYears(-1),
                    Address = new AddressModel {
                        AddressType = AddressType.Home,
                        Street1 = "10525 Testing Lane",
                        Street2 = "",
                        City = "Tampa",
                        Zip = "33674"
                    },
                    EmailAddress = "testme@google.com",
                    HomePhone = "813-555-1212",
                    WorkPhone = "813-555-1213",
                    MobilePhone = "727-555-1212",
                    Fax = "813-555-5555",
                    DiagnosisCodes = new List<DiagnosisCode> {
                        new DiagnosisCode { Id = 1, Value = "Z32.0", Description = "", Count = 1}
                    }
                },
                MemberSearchResults = new List<MemberSearchResultModel> {
                    new MemberSearchResultModel {
                        ActiveFlag = true,
                        CurrentActiveGroup = "Test Group 1",
                        DOB = new DateTime(1975,02,01),
                        FirstName = "Michael",
                        LastName = "Arnold",
                        MemberId = "12345",
                        PersonCode = "342343",
                        SSN = "555-55-1212"
                    },
                    new MemberSearchResultModel {
                        ActiveFlag = true,
                        CurrentActiveGroup = "Test Group 1",
                        DOB = new DateTime(1970,04,22),
                        FirstName = "Dianne",
                        LastName = "Baumhauer",
                        MemberId = "2352",
                        PersonCode = "35353",
                        SSN = "555-55-1212"
                    }
                },
                MemberBenefitSummaryModel = new MemberBenefitSummaryModel {
                    ActiveGroup = "Plan Beta 2",
                    BenefitStartDate = DateTime.Now.AddYears(-1).AddMonths(3),
                    FamilyBenefit = 1000,
                    FamilyCopay = 5000,
                    FamilyDeducatible = 2000,
                    IndividualBenefit = 0,
                    IndividualCopay = 0,
                    IndividualDeductible = 0,
                    Id = 1
                },
               
            };
            vm.ShowSearch = true;
            return View(vm);
        }
    }
}