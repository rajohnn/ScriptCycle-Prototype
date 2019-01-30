﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptCycle.Prototypes.Models {

    public class StepTherapyViewModel {
        public List<Program> Programs { get; set; } = new List<Program>();
        public List<Program> ProgramsColumn1 { get; set; } = new List<Program>();
        public List<Program> ProgramsColumn2 { get; set; } = new List<Program>();
        public List<Program> ProgramsColumn3 { get; set; } = new List<Program>();
        public Program SelectedProgram { get; set; }
        public bool ShowStepTherapy { get; set; } = true;
        public string Filter { get; set; } = string.Empty;
        public List<Rule> Rules { get; set; } = new List<Rule>();
        public static StepTherapyViewModel GetTestModel() {
            var model = new StepTherapyViewModel();
            var program1 = new Program {
                Name = "Acne Products - Oral"
            };
            program1.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Description = "Approved all members",
                Name = "Category A",
                Level = 1,
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine{
                        Order = 1,
                        DrugID = DrugID.GPI,
                        MonyCode = "Y",
                        Value = "12345",
                        DisplayValue = "generic doxycycline"
                    },
                }
            });
            program1.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with Category A medication.",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID = DrugID.NDC, Value = "12334", DisplayValue = "ADOXA", MonyCode = "MON" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.NDC, Value = "12344", DisplayValue = "DORYX", MonyCode = "MON"},
                    new StepTherapyLine { Order = 3, DrugID = DrugID.NDC, Value = "12345", DisplayValue = "MORGIDOX", MonyCode = "MON" }
                }
            });

            var program2 = new Program { Name = "Acne Products - Topical" };
            program2.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID = DrugID.GPI, DisplayValue = "All generic topical antibiotics", MonyCode = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "All generic topical benzoyl peroxide", MonyCode = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "All generic topical salicylic acid", MonyCode = "MON", Value = "34234" }
                }
            });
            program2.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "DIFFERIN", MonyCode = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "TAZORAC", MonyCode = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "Combination topical acne products", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "Topical retinoic acid", MonyCode = "MON", Value = "5234234"}
                }
            });

            var program3 = new Program { Name = "Asthma" };
            program3.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID = DrugID.GPI, DisplayValue = "Aerospan", MonyCode = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Asmanex HFA", MonyCode = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "AZMACORT", MonyCode = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "budesonide respules", MonyCode = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 5, DrugID = DrugID.GPI, DisplayValue = "FLOVENT DISKUS/FLOVENT HFA", MonyCode = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 6, DrugID = DrugID.GPI, DisplayValue = "PULMICORT", MonyCode = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 7, DrugID = DrugID.GPI, DisplayValue = "QVAR", MonyCode = "MON", Value = "34234" },
                }
            });
            program3.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "ADVAIR DISKUS", MonyCode = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "ADVAIR HFA", MonyCode = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "BREO ELLIPTA", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "DULERA", MonyCode = "MON", Value = "5234234"},
                    new StepTherapyLine { Order = 5, DrugID = DrugID.GPI, DisplayValue = "SYMBICORT", MonyCode = "MON", Value = "34234" },
                }
            });

            var program4 = new Program { Name = "Antihypertensives (High Blood Pressure)" };
            program4.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID = DrugID.GPI, DisplayValue = "Any generic ACE inhibitor", MonyCode = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Any generic ACE inhibitor HCTZ", MonyCode = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "lostartan/lostartan HCTZ", MonyCode = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "valsartan/valsartan HCTZ", MonyCode = "MON", Value = "34234" }
                }
            });
            program4.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "candesartan HCTZ", MonyCode = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "irbesartan/irbesartan HCTZ", MonyCode = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "telmisartan/telmisartan HCTZ", MonyCode="MON", Value = "232344" }
                }
            });
            program4.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousTwoLevels,
                Level = 3,
                Name = "Category C",
                Description = "Only after failure with Category A and one B medication",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "Azor", MonyCode = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Benicar/Benicar HCT", MonyCode = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "MICARDIS/MICARDIS HCT", MonyCode="MON", Value = "232344" }
                }
            });
            program4.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousTwoLevels,
                Level = 4,
                Name = "Category D",
                Description = "Only after failure with Category A, B, and one C medication",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "Atacand/Atacand HCT", MonyCode = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "AVAPRO/AVALIDE", MonyCode = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "COZAAR", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "DIOVAN/DIOVAN HCT", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 5, DrugID = DrugID.GPI, DisplayValue = "EDARBI/EDARBYCLOR", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 6, DrugID = DrugID.GPI, DisplayValue = "HYZAAR", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 7, DrugID = DrugID.GPI, DisplayValue = "TEVETEN/TEVETEN HCT", MonyCode="MON", Value = "232344" }
                }
            });

            var program5 = new Program { Name = "Antihypertensives (High Blood Pressure)" };
            program5.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID = DrugID.GPI, DisplayValue = "Any generic ACE inhibitor", MonyCode = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Any generic ACE inhibitor HCTZ", MonyCode = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "lostartan/lostartan HCTZ", MonyCode = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "valsartan/valsartan HCTZ", MonyCode = "MON", Value = "34234" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "candesartan HCTZ", MonyCode = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "irbesartan/irbesartan HCTZ", MonyCode = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "telmisartan/telmisartan HCTZ", MonyCode="MON", Value = "232344" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousTwoLevels,
                Level = 3,
                Name = "Category C",
                Description = "Only after failure with Category A and one B medication",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "Azor", MonyCode = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Benicar/Benicar HCT", MonyCode = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "MICARDIS/MICARDIS HCT", MonyCode="MON", Value = "232344" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousTwoLevels,
                Level = 4,
                Name = "Category D",
                Description = "Only after failure with Category A, B, and one C medication",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "Atacand/Atacand HCT", MonyCode = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "AVAPRO/AVALIDE", MonyCode = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "COZAAR", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "DIOVAN/DIOVAN HCT", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 5, DrugID = DrugID.GPI, DisplayValue = "EDARBI/EDARBYCLOR", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 6, DrugID = DrugID.GPI, DisplayValue = "HYZAAR", MonyCode="MON", Value = "232344" },
                    new StepTherapyLine { Order = 7, DrugID = DrugID.GPI, DisplayValue = "TEVETEN/TEVETEN HCT", MonyCode="MON", Value = "232344" }
                }
            });

            model.Programs.Add(program1);
            model.Programs.Add(program2);
            model.Programs.Add(program3);
            model.Programs.Add(program4);
            model.Programs.Add(program5);

            model.Programs = model.Programs.OrderBy(c => c.Name).ToList();

            return model;
        }
    }

    public class Program {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<Tier> Tiers { get; set; } = new List<Tier>();
        public List<FillLine> Lines { get; set; } = new List<FillLine>();
    }

    public abstract class Line {
        public int? Id { get; set; }
        public int? Order { get; set; }
        public DrugID DrugID { get; set; } = DrugID.All;
        public string Value { get; set; }
        public string DisplayValue { get; set; }
        public string MonyCode { get; set; }
    }

    public abstract class Dependency {
        public int? Level { get; set; }
        public StepTherapyAction Action { get; set; } = StepTherapyAction.NoRule;
        public string Description { get; set; }
        public string MONY { get; set; }
        public RxOtc RxOtc { get; set; } = RxOtc.Both;
        public PeriodType PeriodType = PeriodType.NotActive;
        public decimal? PeriodAmount { get; set; }
        public Rule YesRule { get; set; }
        public Rule NoRule { get; set; }
        public int? DaysUsed { get; set; }
        public int? DistinctDrugCount { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? TermDate { get; set; }
        public DateTimeOffset? DontApplyBeforeDate { get; set; }
        public bool? MustHaveDaysUsedForSameLevel { get; set; }
        public bool? CountInHandAsDaysUsed { get; set; }
        public bool? DaysUsedMustBeConcurrent { get; set; }
        public int? HxClaimsQuantityLessOrEqual { get; set; }
        public int? NotBeforeDays { get; set; }
        public bool? NotApplicationRxLevelPaidDuringPeriod { get; set; }
        public bool? HistoricalScriptTagMatch { get; set; }
        public string ScriptTagValue { get; set; }
    }

    public abstract class DrugFill {
    }

    public class Tier : Dependency {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<StepTherapyLine> Lines { get; set; } = new List<StepTherapyLine>();
    }

    public class StepTherapyLine : Dependency {
        public int? Id { get; set; }
        public int? Order { get; set; }
        public DrugID DrugID { get; set; } = DrugID.All;
        public string Value { get; set; }
        public string DisplayValue { get; set; }
        public string MonyCode { get; set; }
        public StepTherapyAction StepAction { get; set; } = StepTherapyAction.NoRule;
    }

    public class FillLine : Line {
        public FillAction FillAction { get; set; } = FillAction.LastScriptDaySupply;
    }

    public class Rule {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum RxOtc {
        Both,
        RX,
        OTC
    }

    public enum DrugID {
        All,
        Maintenance,
        GPI,
        NDC,
        List
    }

    public enum DrugType {
        All,
        CUI,
        XTRule,
        FormularyList,
        GPI,
        NDC,
        List
    }

    public enum StepTherapyAction {
        NoRule,
        PreviousLevel,
        SameLevel,
        PreviousTwoLevels,
        AllPreviousLevels
    }

    public enum FillAction {
        NumberOfScriptsFilled,
        MaxDaySupplyFilled,
        LastScriptDaySupply,
        Quantity,
        UniqueFillDates
    }

    public enum PeriodType {
        NotActive,
        Script,
        XDays,
        CalendarMonths,
        XMonths,
        CalendarYear,
        BenefitYear,
        XYears,
        Lifetime,
        CalendarQuarter
    }
}