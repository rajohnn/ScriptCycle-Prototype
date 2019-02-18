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
        public List<string> NDCs { get; set; } = new List<string>();
        public List<string> FilteredNDCs { get; set; } = new List<string>();
        public List<string> GPIs { get; set; } = new List<string>();
        public List<string> FilteredGPIs { get; set; } = new List<string>();
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
                this.DisplayAs = results[0].DisplayName;
                var uniqueDoages = results.GroupBy(d => d.dosage_form).Select(d => d.First()).ToList();
                var uniqueStrengths = results.GroupBy(d => d.strength).Select(d => d.First()).ToList();
                var resultGPIs = new List<string>();

                results.ForEach(r => {

                    var exists = this.NDCs.SingleOrDefault(n => n == r.ndc_upc_hri);
                    if (string.IsNullOrEmpty(exists))
                        this.NDCs.Add(r.ndc_upc_hri);

                    exists = resultGPIs.SingleOrDefault(n => n == r.generic_product_identifier);
                    if (string.IsNullOrEmpty(exists))
                        resultGPIs.Add(r.generic_product_identifier);

                    exists = this.DosageOptions.SingleOrDefault(n => n == r.dosage_form);
                    if (string.IsNullOrEmpty(exists))
                        this.DosageOptions.Add(r.dosage_form);

                    exists = this.Strengths.SingleOrDefault(n => n == r.strength + r.strength_unit_of_measure);
                    if (string.IsNullOrEmpty(exists))
                        this.Strengths.Add(r.strength + r.strength_unit_of_measure);

                });
                resultGPIs.Sort();
                int length = drugId.Length;
                var partialGPIs = new List<string>();

                // make sure we have a proper partial GPI
                if ( length % 2 == 0 && length < 13) {
                    for(int i = drugId.Length + 2; i < 13; i = i + 2) {
                        partialGPIs.AddRange(GeneratePartialGPIs(results, i));                        
                    }
                }
                this.GPIs.AddRange(partialGPIs);
                this.GPIs.AddRange(resultGPIs);

                this.Strengths.Sort();
                this.DosageOptions.Sort();
                this.NDCs.Sort();
                
            }
            else {
                this.DisplayAs = string.Empty;
                this.DosageOptions = new List<string>();
                this.Strengths = new List<string>();
                this.NDCs = new List<string>();
                this.GPIs = new List<string>();
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

    public class DrugSearchResultDto {
        public string DisplayName { get; set; }
        public List<DrugSearchResult> SearchResults { get; set; } = new List<DrugSearchResult>();
        public List<string> DosageOptions { get; set; } = new List<string>();
        public List<string> Strengths { get; set; } = new List<string>();
        public List<string> NDCs { get; set; } = new List<string>();
        public List<string> GPIs { get; set; } = new List<string>();
    }

    public class DrugSearchResult {
        public string drug_name { get; set; }
        public string DisplayName { get; set; }
        public string dosage_form { get; set; }
        public string strength { get; set; }
        public string strength_unit_of_measure { get; set; }
        public string generic_product_identifier { get; set; }
        public string ndc_upc_hri { get; set; }
    }
}