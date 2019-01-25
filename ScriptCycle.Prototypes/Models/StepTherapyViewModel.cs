using System.Collections.Generic;

namespace ScriptCycle.Prototypes.Models {

    public class StepTherapyViewModel {
        public List<Program> Programs { get; set; } = new List<Program>();
        public static StepTherapyViewModel GetTestModel() {
            var model = new StepTherapyViewModel();
            var program1 = new Program {
                Name = "Acne Products - Oral"
            };
            program1.Tiers.Add(new Tier {
                Action = Action.NoRule,
                Description = "Approved all members",
                Name = "Category A",
                Level = 1,
                Lines = new List<Line>() {
                    new Line{
                        Order = 1,
                        DependencyType = DependencyType.GPI,
                        MonyCode = "Y",
                        Value = "12345",
                        DisplayValue = "generic doxycycline"
                    },
                }
            });
            program1.Tiers.Add(new Tier {
                Action = Action.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with Category A medication.",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType = DependencyType.NDC, Value = "12334", DisplayValue = "ADOXA", MonyCode = "MON" },
                    new Line { Order = 2, DependencyType = DependencyType.NDC, Value = "12344", DisplayValue = "DORYX", MonyCode = "MON"},
                    new Line { Order = 3, DependencyType = DependencyType.NDC, Value = "12345", DisplayValue = "MORGIDOX", MonyCode = "MON" }

                }
            });

            var program2 = new Program { Name = "Acne Products - Topical" };
            program2.Tiers.Add(new Tier {
                Action = Action.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType = DependencyType.GPI, DisplayValue = "All generic topical antibiotics", MonyCode = "MON", Value = "234234" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "All generic topical benzoyl peroxide", MonyCode = "MON", Value = "234234" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "All generic topical salicylic acid", MonyCode = "MON", Value = "34234" }
                }
            });
            program2.Tiers.Add(new Tier {
                Action = Action.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType= DependencyType.GPI, DisplayValue = "DIFFERIN", MonyCode = "MON", Value = "13423" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "TAZORAC", MonyCode = "MON", Value = "32342" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "Combination topical acne products", MonyCode="MON", Value = "232344" },
                    new Line { Order = 4, DependencyType = DependencyType.GPI, DisplayValue = "Topical retinoic acid", MonyCode = "MON", Value = "5234234"}
                }
            });


            var program3 = new Program { Name = "Asthma" };
            program3.Tiers.Add(new Tier {
                Action = Action.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType = DependencyType.GPI, DisplayValue = "Aerospan", MonyCode = "MON", Value = "234234" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "Asmanex HFA", MonyCode = "MON", Value = "234234" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "AZMACORT", MonyCode = "MON", Value = "34234" },
                    new Line { Order = 4, DependencyType = DependencyType.GPI, DisplayValue = "budesonide respules", MonyCode = "MON", Value = "34234" },
                    new Line { Order = 5, DependencyType = DependencyType.GPI, DisplayValue = "FLOVENT DISKUS/FLOVENT HFA", MonyCode = "MON", Value = "34234" },
                    new Line { Order = 6, DependencyType = DependencyType.GPI, DisplayValue = "PULMICORT", MonyCode = "MON", Value = "34234" },
                    new Line { Order = 7, DependencyType = DependencyType.GPI, DisplayValue = "QVAR", MonyCode = "MON", Value = "34234" },
                }
            });
            program3.Tiers.Add(new Tier {
                Action = Action.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType= DependencyType.GPI, DisplayValue = "ADVAIR DISKUS", MonyCode = "MON", Value = "13423" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "ADVAIR HFA", MonyCode = "MON", Value = "32342" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "BREO ELLIPTA", MonyCode="MON", Value = "232344" },
                    new Line { Order = 4, DependencyType = DependencyType.GPI, DisplayValue = "DULERA", MonyCode = "MON", Value = "5234234"},
                    new Line { Order = 5, DependencyType = DependencyType.GPI, DisplayValue = "SYMBICORT", MonyCode = "MON", Value = "34234" },
                }
            });

            var program4 = new Program { Name = "Antihypertensives (High Blood Pressure)" };
            program4.Tiers.Add(new Tier {
                Action = Action.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType = DependencyType.GPI, DisplayValue = "Any generic ACE inhibitor", MonyCode = "MON", Value = "234234" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "Any generic ACE inhibitor HCTZ", MonyCode = "MON", Value = "234234" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "lostartan/lostartan HCTZ", MonyCode = "MON", Value = "34234" },
                    new Line { Order = 4, DependencyType = DependencyType.GPI, DisplayValue = "valsartan/valsartan HCTZ", MonyCode = "MON", Value = "34234" }                   
                }
            });
            program4.Tiers.Add(new Tier {
                Action = Action.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType= DependencyType.GPI, DisplayValue = "candesartan HCTZ", MonyCode = "MON", Value = "13423" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "irbesartan/irbesartan HCTZ", MonyCode = "MON", Value = "32342" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "telmisartan/telmisartan HCTZ", MonyCode="MON", Value = "232344" }
                }
            });
            program4.Tiers.Add(new Tier {
                Action = Action.PreviousTwoLevels,
                Level = 3,
                Name = "Category C",
                Description = "Only after failure with Category A and one B medication",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType= DependencyType.GPI, DisplayValue = "Azor", MonyCode = "MON", Value = "13423" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "Benicar/Benicar HCT", MonyCode = "MON", Value = "32342" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "MICARDIS/MICARDIS HCT", MonyCode="MON", Value = "232344" }
                }
            });
            program4.Tiers.Add(new Tier {
                Action = Action.PreviousTwoLevels,
                Level = 4,
                Name = "Category D",
                Description = "Only after failure with Category A, B, and one C medication",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType= DependencyType.GPI, DisplayValue = "Atacand/Atacand HCT", MonyCode = "MON", Value = "13423" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "AVAPRO/AVALIDE", MonyCode = "MON", Value = "32342" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "COZAAR", MonyCode="MON", Value = "232344" },
                    new Line { Order = 4, DependencyType = DependencyType.GPI, DisplayValue = "DIOVAN/DIOVAN HCT", MonyCode="MON", Value = "232344" },
                    new Line { Order = 5, DependencyType = DependencyType.GPI, DisplayValue = "EDARBI/EDARBYCLOR", MonyCode="MON", Value = "232344" },
                    new Line { Order = 6, DependencyType = DependencyType.GPI, DisplayValue = "HYZAAR", MonyCode="MON", Value = "232344" },
                    new Line { Order = 7, DependencyType = DependencyType.GPI, DisplayValue = "TEVETEN/TEVETEN HCT", MonyCode="MON", Value = "232344" }
                }
            });

            var program5 = new Program { Name = "Antihypertensives (High Blood Pressure)" };
            program5.Tiers.Add(new Tier {
                Action = Action.NoRule,
                Level = 1,
                Name = "Category A",
                Description = "Approved all members",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType = DependencyType.GPI, DisplayValue = "Any generic ACE inhibitor", MonyCode = "MON", Value = "234234" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "Any generic ACE inhibitor HCTZ", MonyCode = "MON", Value = "234234" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "lostartan/lostartan HCTZ", MonyCode = "MON", Value = "34234" },
                    new Line { Order = 4, DependencyType = DependencyType.GPI, DisplayValue = "valsartan/valsartan HCTZ", MonyCode = "MON", Value = "34234" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = Action.PreviousLevel,
                Level = 2,
                Name = "Category B",
                Description = "Only after failure with two Category A medications",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType= DependencyType.GPI, DisplayValue = "candesartan HCTZ", MonyCode = "MON", Value = "13423" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "irbesartan/irbesartan HCTZ", MonyCode = "MON", Value = "32342" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "telmisartan/telmisartan HCTZ", MonyCode="MON", Value = "232344" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = Action.PreviousTwoLevels,
                Level = 3,
                Name = "Category C",
                Description = "Only after failure with Category A and one B medication",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType= DependencyType.GPI, DisplayValue = "Azor", MonyCode = "MON", Value = "13423" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "Benicar/Benicar HCT", MonyCode = "MON", Value = "32342" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "MICARDIS/MICARDIS HCT", MonyCode="MON", Value = "232344" }
                }
            });
            program5.Tiers.Add(new Tier {
                Action = Action.PreviousTwoLevels,
                Level = 4,
                Name = "Category D",
                Description = "Only after failure with Category A, B, and one C medication",
                Lines = new List<Line>() {
                    new Line { Order = 1, DependencyType= DependencyType.GPI, DisplayValue = "Atacand/Atacand HCT", MonyCode = "MON", Value = "13423" },
                    new Line { Order = 2, DependencyType = DependencyType.GPI, DisplayValue = "AVAPRO/AVALIDE", MonyCode = "MON", Value = "32342" },
                    new Line { Order = 3, DependencyType = DependencyType.GPI, DisplayValue = "COZAAR", MonyCode="MON", Value = "232344" },
                    new Line { Order = 4, DependencyType = DependencyType.GPI, DisplayValue = "DIOVAN/DIOVAN HCT", MonyCode="MON", Value = "232344" },
                    new Line { Order = 5, DependencyType = DependencyType.GPI, DisplayValue = "EDARBI/EDARBYCLOR", MonyCode="MON", Value = "232344" },
                    new Line { Order = 6, DependencyType = DependencyType.GPI, DisplayValue = "HYZAAR", MonyCode="MON", Value = "232344" },
                    new Line { Order = 7, DependencyType = DependencyType.GPI, DisplayValue = "TEVETEN/TEVETEN HCT", MonyCode="MON", Value = "232344" }
                }
            });

            model.Programs.Add(program1);
            model.Programs.Add(program2);
            model.Programs.Add(program3);
            model.Programs.Add(program4);
            model.Programs.Add(program5);

            return model;
        }
    }

    public class Program {
        public string Name { get; set; }
        public List<Tier> Tiers { get; set; } = new List<Tier>();
    }

    public class Tier {
        public string Name { get; set; }
        public Action Action { get; set; } = Action.NoRule;
        public string Description { get; set; }
        public int? Level { get; set; }
        public List<Line> Lines { get; set; } = new List<Line>();
    }

    public class Line {
        public int? Order { get; set; }
        public DependencyType DependencyType { get; set; } = DependencyType.All;
        public string Value { get; set; }
        public string DisplayValue { get; set; }
        public string MonyCode { get; set; }
    }

    public enum DependencyType {
        All,
        Maintenance,
        GPI,
        NDC,
        List
    }

    public enum Action {
        NoRule,
        PreviousLevel,
        SameLevel,
        PreviousTwoLevels,
        AllPreviousLevels
    }
}