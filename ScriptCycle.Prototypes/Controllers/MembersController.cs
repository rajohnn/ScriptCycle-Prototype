using ScriptCycle.Prototypes.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ScriptCycle.Prototypes.Controllers {

    public class MembersController : Controller {
       
        public ActionResult Index() {
            var vm = new MemberViewModel {
                MemberModel = new MemberModel {
                    MemberId = "12345",
                    FirstName = "Fred",
                    PC = "98765",
                    MiddleName = "Haas",
                    LastName = "Steffen",
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
                    EmailAddress = new EmailAddressModel {
                        Domain = "google.com",
                        EmailAddressType = EmailAddressType.Personal,
                        LocalPart = "testor"
                    }  ,
                    HomePhone = new PhoneModel {
                        AreaCode = "813",
                        Number = "555-1212",
                        PhoneType = PhoneType.Home
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
                }
            };
            vm.ShowSearch = true;
            return View(vm);
        }
    }
}