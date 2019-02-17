using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptCycle.Prototypes.Models {

    public class StepTherapyViewModel {
        public List<Program> Programs { get; set; } = new List<Program>();
        public List<DrugFill> DrugFills { get; set; } = new List<DrugFill>();

        public List<Program> ProgramsColumn1 { get; set; } = new List<Program>();
        public List<Program> ProgramsColumn2 { get; set; } = new List<Program>();
        public List<Program> ProgramsColumn3 { get; set; } = new List<Program>();

        public List<DrugFill> DrugsColumn1 { get; set; } = new List<DrugFill>();
        public List<DrugFill> DrugsColumn2 { get; set; } = new List<DrugFill>();
        public List<DrugFill> DrugsColumn3 { get; set; } = new List<DrugFill>();

        public Program SelectedProgram { get; set; }
        public Tier SelectedTier { get; set; }
        public StepTherapyLine SelectedStepTherapyLine { get; set; }
        public FillLine SelectedFillLine { get; set; }

        public bool ShowStepTherapy { get; set; } = true;
        public string Filter { get; set; } = string.Empty;
        public List<Rule> Rules { get; set; } = new List<Rule>();
        public string NewProgramName { get; set; }
        public string NewFillRuleName { get; set; }
        public DrugSelectionViewModel DrugSelection { get; set; } = new DrugSelectionViewModel { DrugSelectionOption = DrugSelectionOption.All };

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
                        MONY = "Y",
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
                    new StepTherapyLine { Order = 1, DrugID = DrugID.NDC, Value = "12334", DisplayValue = "ADOXA", MONY = "MON" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.NDC, Value = "12344", DisplayValue = "DORYX", MONY = "MON"},
                    new StepTherapyLine { Order = 3, DrugID = DrugID.NDC, Value = "12345", DisplayValue = "MORGIDOX", MONY = "MON" }
                }
            });

            var program2 = new Program { Name = "Acne Products - Topical" };
            program2.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID = DrugID.GPI, DisplayValue = "All generic topical antibiotics", MONY = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "All generic topical benzoyl peroxide", MONY = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "All generic topical salicylic acid", MONY = "MON", Value = "34234" }
                }
            });
            program2.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "DIFFERIN", MONY = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "TAZORAC", MONY = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "Combination topical acne products", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "Topical retinoic acid", MONY = "MON", Value = "5234234"}
                }
            });

            var program3 = new Program { Name = "Asthma" };
            program3.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID = DrugID.GPI, DisplayValue = "Aerospan", MONY = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Asmanex HFA", MONY = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "AZMACORT", MONY = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "budesonide respules", MONY = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 5, DrugID = DrugID.GPI, DisplayValue = "FLOVENT DISKUS/FLOVENT HFA", MONY = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 6, DrugID = DrugID.GPI, DisplayValue = "PULMICORT", MONY = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 7, DrugID = DrugID.GPI, DisplayValue = "QVAR", MONY = "MON", Value = "34234" },
                }
            });
            program3.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "ADVAIR DISKUS", MONY = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "ADVAIR HFA", MONY = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "BREO ELLIPTA", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "DULERA", MONY = "MON", Value = "5234234"},
                    new StepTherapyLine { Order = 5, DrugID = DrugID.GPI, DisplayValue = "SYMBICORT", MONY = "MON", Value = "34234" },
                }
            });

            var program4 = new Program { Name = "Antihypertensives (High Blood Pressure)" };
            program4.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID = DrugID.GPI, DisplayValue = "Any generic ACE inhibitor", MONY = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Any generic ACE inhibitor HCTZ", MONY = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "lostartan/lostartan HCTZ", MONY = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "valsartan/valsartan HCTZ", MONY = "MON", Value = "34234" }
                }
            });
            program4.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "candesartan HCTZ", MONY = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "irbesartan/irbesartan HCTZ", MONY = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "telmisartan/telmisartan HCTZ", MONY="MON", Value = "232344" }
                }
            });
            program4.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousTwoLevels,
                Level = 3,
                Name = "Category C",
                Description = "Only after failure with Category A and one B medication",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "Azor", MONY = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Benicar/Benicar HCT", MONY = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "MICARDIS/MICARDIS HCT", MONY="MON", Value = "232344" }
                }
            });
            program4.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousTwoLevels,
                Level = 4,
                Name = "Category D",
                Description = "Only after failure with Category A, B, and one C medication",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "Atacand/Atacand HCT", MONY = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "AVAPRO/AVALIDE", MONY = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "COZAAR", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "DIOVAN/DIOVAN HCT", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 5, DrugID = DrugID.GPI, DisplayValue = "EDARBI/EDARBYCLOR", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 6, DrugID = DrugID.GPI, DisplayValue = "HYZAAR", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 7, DrugID = DrugID.GPI, DisplayValue = "TEVETEN/TEVETEN HCT", MONY="MON", Value = "232344" }
                }
            });

            var program5 = new Program { Name = "Antihypertensives (High Blood Pressure)" };
            program5.Tiers.Add(new Tier {
                Action = StepTherapyAction.NoRule,
                Level = 1,               
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, IsInheriting=false, DrugID = DrugID.GPI, DisplayValue = "Any generic ACE inhibitor", MONY = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Any generic ACE inhibitor HCTZ", MONY = "MON", Value = "234234" },
                    new StepTherapyLine { Order = 3, IsInheriting = false, DrugID = DrugID.GPI, DisplayValue = "lostartan/lostartan HCTZ", MONY = "MON", Value = "34234" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "valsartan/valsartan HCTZ", MONY = "MON", Value = "34234" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "candesartan HCTZ", MONY = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "irbesartan/irbesartan HCTZ", MONY = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "telmisartan/telmisartan HCTZ", MONY="MON", Value = "232344" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousTwoLevels,
                Level = 3,
                Name = "Category C",
                Description = "Only after failure with Category A and one B medication",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "Azor", MONY = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "Benicar/Benicar HCT", MONY = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "MICARDIS/MICARDIS HCT", MONY="MON", Value = "232344" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = StepTherapyAction.PreviousTwoLevels,
                Level = 4,
                Name = "Category D",
                Description = "Only after failure with Category A, B, and one C medication",
                Lines = new List<StepTherapyLine>() {
                    new StepTherapyLine { Order = 1, DrugID= DrugID.GPI, DisplayValue = "Atacand/Atacand HCT", MONY = "MON", Value = "13423" },
                    new StepTherapyLine { Order = 2, DrugID = DrugID.GPI, DisplayValue = "AVAPRO/AVALIDE", MONY = "MON", Value = "32342" },
                    new StepTherapyLine { Order = 3, DrugID = DrugID.GPI, DisplayValue = "COZAAR", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 4, DrugID = DrugID.GPI, DisplayValue = "DIOVAN/DIOVAN HCT", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 5, DrugID = DrugID.GPI, DisplayValue = "EDARBI/EDARBYCLOR", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 6, DrugID = DrugID.GPI, DisplayValue = "HYZAAR", MONY="MON", Value = "232344" },
                    new StepTherapyLine { Order = 7, DrugID = DrugID.GPI, DisplayValue = "TEVETEN/TEVETEN HCT", MONY="MON", Value = "232344" }
                }
            });

            model.Programs.Add(program1);
            model.Programs.Add(program2);
            model.Programs.Add(program3);
            model.Programs.Add(program4);
            model.Programs.Add(program5);

            var fillRule = new DrugFill { Id = 1, Name = "0052 1RX MO $0 COPAY" };
            fillRule.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "ALLOWS 1ST DRUG TO PROCESS X1 AT $0 COPAY",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });

            var fillRule1 = new DrugFill { Id = 1, Name = "0065-CENTER PHARM 1X" };
            fillRule1.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "RETAIL ALLOWACE 1 FILL-CENTER PHARMACY",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule1.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "REJECT AFTER 1 FILL",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 2,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 2,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });

            var fillRule2 = new DrugFill { Id = 1, Name = "0065-MANDATORY MAINT" };
            fillRule2.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "CENTER PHARMACY ALLOWANCE",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });

            var fillRule3 = new DrugFill { Id = 1, Name = "HCR BOWEL 1 FREE/YR" };
            fillRule3.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Saline Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule3.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Stimulant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule3.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Lubricant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule3.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Surfactant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule3.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Laxatives - Miscellaneous**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule3.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Bowel Evacuant Combinations***",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });

            var fillRule4 = new DrugFill { Id = 1, Name = "HCR BOWEL 1/YR 50-75" };
            fillRule4.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Saline Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule4.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Stimulant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule4.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Lubricant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule4.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Surfactant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule4.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Laxatives - Miscellaneous**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule4.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Bowel Evacuant Combinations***",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });


            var fillRule5 = new DrugFill { Id = 1, Name = "HCR BOWEL 1/YR >18YO" };
            fillRule5.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Saline Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule5.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Stimulant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule5.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Lubricant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule5.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Surfactant Laxatives**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule5.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Laxatives - Miscellaneous**",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule5.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "*Bowel Evacuant Combinations***",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });

            var fillRule6 = new DrugFill { Id = 1, Name = "MAIL REQ-X2 APR 18" };
            fillRule6.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "MANDATORY MAIL RETAIL ALLOWACE X 2 FILLS",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule6.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "Reject after 2 fills",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });

            var fillRule7 = new DrugFill { Id = 1, Name = "MAIL REQ-X2 JAN 18" };
            fillRule7.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "MANDATORY MAIL RETAIL ALLOWACE X 2 FILLS",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule7.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "Reject after 2 fills",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });

            var fillRule8 = new DrugFill { Id = 1, Name = "MAIL REQ-X2 JULY17" };
            fillRule8.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "MANDATORY MAIL RETAIL ALLOWACE X 2 FILLS",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });
            fillRule8.FillLines.Add(new FillLine {
                Action = StepTherapyAction.NoRule,
                CountInHandAsDaysUsed = true,
                DaysUsed = 2,
                DaysUsedMustBeConcurrent = true,
                Description = "Some Description",
                DisplayValue = "Reject after 2 fills",
                DistinctDrugCount = 1,
                DontApplyBeforeDate = new DateTimeOffset(2019, 12, 01, 0, 0, 0, new TimeSpan(0)),
                DrugID = DrugID.All,
                FillAction = FillAction.Quantity,
                HistoricalScriptTagMatch = false,
                HxClaimsQuantityLessOrEqual = null,
                Id = 1,
                Level = 1,
                MONY = "MON",
                MustHaveDaysUsedForSameLevel = false,
                NoRule = null,
                NotApplicationRxLevelPaidDuringPeriod = false,
                NotBeforeDays = null,
                Order = 1,
                PeriodAmount = 0.00M,
                PeriodType = PeriodType.Script,
                RxOtc = RxOtc.Both,
                ScriptTagValue = "",
                StartDate = null,
                TermDate = null,
                Value = "Some Value",
                YesRule = null
            });

            model.DrugFills.AddRange(new DrugFill[] { fillRule, fillRule1, fillRule2, fillRule3,
                fillRule4, fillRule5, fillRule6, fillRule7, fillRule8 });

            model.Programs = model.Programs.OrderBy(c => c.Name).ToList();
            model.DrugFills = model.DrugFills.OrderBy(c => c.Name).ToList();
            return model;
        }
    }

   

    

    public class Program {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<Tier> Tiers { get; set; } = new List<Tier>();
        public List<FillLine> Lines { get; set; } = new List<FillLine>();
    }

    public class DrugFill {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<FillLine> FillLines { get; set; } = new List<FillLine>();
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
        public bool IsInheriting { get; set; } = true;
        public StepTherapyAction StepAction { get; set; } = StepTherapyAction.NoRule;
    }

    public class FillLine : Dependency {
        public int? Id { get; set; }
        public int? Order { get; set; }
        public DrugID DrugID { get; set; } = DrugID.All;
        public string Value { get; set; }
        public string DisplayValue { get; set; }       
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