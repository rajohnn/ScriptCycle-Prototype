using ScriptCycle.Prototypes.Data;
using ScriptCycle.Prototypes.Repo;
using System.Collections.Generic;
using System.Linq;

namespace ScriptCycle.Prototypes.Models {

    public class DrugSelectionViewModel {
        private DrugSelectionOption _selectionOption;
        public int? SelectedDrugType { get; set; }
        public int? SelectedFormulary { get; set; }
        public string DisplayAs { get; set; }
        public bool ShowPanel { get; set; } = false;
        public bool? IsSearchNumeric { get; set; }
        public bool IsSearching { get; set; } = false;
        public string DrugId { get; set; }
        public string SelectedDosage { get; set; }
        public string SelectedStrength { get; set; }
        public string SelectedNDC { get; set; }
        public string SelectedGPI { get; set; }

        public DrugSelectionOption DrugSelectionOption {
            get { return _selectionOption; }
            set {
                _selectionOption = value;
                if (value == DrugSelectionOption.All) {
                    DrugOptions = new List<SelectionModel>() {
                        new SelectionModel { Id = 0, Value = "All Drugs" },
                        new SelectionModel { Id = 1, Value = "Maintenance" },
                        new SelectionModel { Id = 2, Value = "GPI" },
                        new SelectionModel { Id = 3, Value = "NDC" },
                        new SelectionModel { Id = 4, Value = "Formulary" }
                    };
                }
                else {
                    DrugOptions = new List<SelectionModel>() {
                        new SelectionModel { Id = 2, Value = "GPI" },
                        new SelectionModel { Id = 3, Value = "NDC" }
                    };
                }
            }
        }

        public List<SelectionModel> DrugOptions { get; set; } = new List<SelectionModel>();
        public List<string> FilteredDosageOptions { get; set; } = new List<string>();
        public List<string> FilteredStrengths { get; set; } = new List<string>();
        public List<string> DosageOptions { get; set; } = new List<string>();
        public List<string> Strengths { get; set; } = new List<string>();
        public List<NDCDto> NDCs { get; set; } = new List<NDCDto>();
        public List<NDCDto> FilteredNDCs { get; set; } = new List<NDCDto>();
        public List<GPIDto> GPIs { get; set; } = new List<GPIDto>();
        public List<GPIDto> FilteredGPIs { get; set; } = new List<GPIDto>();
        public List<DrugSearchResult> SearchResults { get; set; } = new List<DrugSearchResult>();

        /// <summary>
        /// TODO: Placeholder until formularies are stored in the application.
        /// </summary>
        public List<SelectionModel> Formularies { get; set; } = new List<SelectionModel> {
            new SelectionModel { Id = 1, Value = "Formulary 1" },
            new SelectionModel { Id = 1, Value = "Formulary 2" },
            new SelectionModel { Id = 1, Value = "Formulary 3" },
            new SelectionModel { Id = 1, Value = "Formulary 4" },
            new SelectionModel { Id = 1, Value = "Formulary 5" },
            new SelectionModel { Id = 1, Value = "Formulary 6" },
            new SelectionModel { Id = 1, Value = "Formulary 7" },
            new SelectionModel { Id = 1, Value = "Formulary 8" },
            new SelectionModel { Id = 1, Value = "Formulary 9" },
            new SelectionModel { Id = 1, Value = "Formulary 10" },
            new SelectionModel { Id = 1, Value = "Formulary 11" }
        };

        public void MapResultsToViewModel(List<DrugSearchResult> results, string drugId) {
            this.SearchResults = results;
            if (results.Count > 0) {
                
                var uniqueDoages = results.GroupBy(d => d.dosage_form).Select(d => d.First()).ToList();
                var uniqueStrengths = results.GroupBy(d => d.strength).Select(d => d.First()).ToList();
                var resultGPIs = new List<GPIDto>();

                results.ForEach(r => {
                    var hasNDC = this.NDCs.FirstOrDefault(n => n.NDC == r.ndc_upc_hri);
                    if (hasNDC == null) {
                        this.NDCs.Add(
                            new NDCDto {
                                DisplayName = string.Format("{0} {1} {2}{3}", r.drug_name, r.dosage_form, r.strength, r.strength_unit_of_measure),
                                MaintenanceCode = GetMaintenanceCode(r.maintenance_drug_code),
                                MONY = r.multi_source_code,
                                NDC = r.ndc_upc_hri
                            });
                    }
                    var gpiExists = resultGPIs.FirstOrDefault(n => n.GPI == r.generic_product_identifier);
                    if (gpiExists == null) {
                        resultGPIs.Add(new GPIDto { DisplayName = r.DisplayName, GPI = r.generic_product_identifier });
                    }                       

                    var exists = this.DosageOptions.FirstOrDefault(n => n == r.dosage_form);
                    if (string.IsNullOrEmpty(exists))
                        this.DosageOptions.Add(r.dosage_form);

                    exists = this.Strengths.FirstOrDefault(n => n == r.strength + r.strength_unit_of_measure);
                    if (string.IsNullOrEmpty(exists)) {
                        if (!string.IsNullOrEmpty(r.strength))
                            this.Strengths.Add(r.strength + r.strength_unit_of_measure);
                    }
                        
                });
                resultGPIs = resultGPIs.OrderBy(c => c.GPI).ToList();
                int length = drugId.Length;
                var partialGPIs = new List<string>();

                // make sure we have a proper partial GPI
                if (length % 2 == 0 && length < 13) {
                    for (int i = drugId.Length; i < 13; i = i + 2) {
                        partialGPIs.AddRange(GeneratePartialGPIs(results, i));
                    }
                }
                var sctx = new ScriptCycleContext();
                var repo = new DrugRepo(sctx);

                var namedPartials = repo.GetPartialGPINames(partialGPIs);
                this.GPIs.AddRange(namedPartials);
                this.GPIs.AddRange(resultGPIs);

                var selectedGPI = this.GPIs.SingleOrDefault(g => g.GPI == drugId);
                if (selectedGPI != null) {
                    this.DisplayAs = selectedGPI.DisplayName;
                    this.GPIs.Remove(selectedGPI);
                }
                else {
                    this.DisplayAs = results[0].DisplayName;
                }                    
                this.Strengths.Sort();
                this.DosageOptions.Sort();
                this.NDCs = NDCs.OrderBy(c => c.DisplayName).ThenBy(c => c.NDC).ToList();
            }
            else {
                this.DisplayAs = string.Empty;
                this.DosageOptions = new List<string>();
                this.Strengths = new List<string>();
                this.NDCs = new List<NDCDto>();
                this.GPIs = new List<GPIDto>();
            }
        }

        private List<string> GeneratePartialGPIs(List<DrugSearchResult> results, int length) {
            var partialGPIs = new List<string>();
            results.ForEach(r => {
                var gpi = r.generic_product_identifier.Substring(0, length);
                var exists = partialGPIs.SingleOrDefault(g => g == gpi);
                if (exists == null)
                    partialGPIs.Add(gpi);
            });
            return partialGPIs;
        }

        private string GetMaintenanceCode(string value) {
            if (value == "1")
                return "No";
            if (value == "2")
                return "Yes";
            return "Unknown";
        }
    }

    /// <summary>
    /// TODO: Can be expanded to support more options.
    /// All shows all drug options.
    /// Standard displays NDC and GPI options.
    /// </summary>
    public enum DrugSelectionOption {
        All,
        Standard
    }

    public class NDCDto {
        public string NDC { get; set; }
        public string DisplayName { get; set; }
        public string MONY { get; set; }
        public string MaintenanceCode { get; set; }
    }

    public class GPIDto {
        public string GPI { get; set; }
        public string DisplayName { get; set; }
    }

    public class DrugSearchResultDto {
        public string DisplayName { get; set; }
        public List<DrugSearchResult> SearchResults { get; set; } = new List<DrugSearchResult>();
        public List<string> DosageOptions { get; set; } = new List<string>();
        public List<string> Strengths { get; set; } = new List<string>();
        public List<NDCDto> NDCs { get; set; } = new List<NDCDto>();
        public List<GPIDto> GPIs { get; set; } = new List<GPIDto>();
    }

    public class DrugSearchResult {
        public string drug_name { get; set; }
        public string DisplayName { get; set; }
        public string dosage_form { get; set; }
        public string strength { get; set; }
        public string strength_unit_of_measure { get; set; }
        public string generic_product_identifier { get; set; }
        public string ndc_upc_hri { get; set; }
        public string multi_source_code { get; set; }
        public string maintenance_drug_code { get; set; }
    }
}