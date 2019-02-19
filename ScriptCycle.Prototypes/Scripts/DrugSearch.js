Declare("drugsearch", {
    serverModel: null,
    model: null,
    vm: null,   
    haveDrugSource: false,
    // contains an init method so we can test the control independently 
    // with the drugsearch namespace
    init: function () {
        if (drugsearch.serverModel) {
            drugsearch.model = ko.observable(ko.mapping.fromJS(drugsearch.serverModel));
        }
        drugsearch.vm = drugsearch.model();
        drugsearch.initSubscriptions();
        ko.applyBindings(drugsearch.model);
    },
    // called by external view to initialize the control subscriptions
    initSubscriptions: function () {
        // invoked when the drug Id value changes
        drugsearch.vm.DrugSelection.DrugId.subscribe(function (value) {
            var isNumeric = drugsearch.isSearchNumeric(value);
            drugsearch.vm.DrugSelection.IsSearchNumeric(isNumeric);            
        });

        // invoked when the selected dosage value changes
        drugsearch.vm.DrugSelection.SelectedDosage.subscribe(function (value) {
            var dvm = drugsearch.vm.DrugSelection;   
            if (value) {
                var strength = dvm.SelectedStrength();
                drugsearch.filterDrugResults(value, strength);                
            }          
        });

        // invoked when the selected strength value changes
        drugsearch.vm.DrugSelection.SelectedStrength.subscribe(function (value) {
            var dvm = drugsearch.vm.DrugSelection;
            if (value) {
                var dosage = dvm.SelectedDosage();
                drugsearch.filterDrugResults(dosage, value);                
            }          
        });

        // invoked when the selected NDC changes
        drugsearch.vm.DrugSelection.SelectedNDC.subscribe(function (value) {
            console.log("NDC changed: " + value);
            var drugType = drugsearch.vm.DrugSelection.SelectedDrugType();
            if (value) {
                if (drugType === 2) {
                    drugsearch.vm.DrugSelection.SelectedDrugType(3);
                }
                drugsearch.vm.DrugSelection.DrugId(value);
                drugsearch.findDrugByNDC(value);
            }            
        });

        // invoked when the selected GPI changes
        drugsearch.vm.DrugSelection.SelectedGPI.subscribe(function (value) {
            console.log("GPI changed: " + value);
            var drugType = drugsearch.vm.DrugSelection.SelectedDrugType();

            if (value) {
                if (drugType === 3) {
                    drugsearch.vm.DrugSelection.SelectedDrugType(2);
                }
                drugsearch.vm.DrugSelection.DrugId(value);
                drugsearch.findDrugByGPI(value);
            }           
        });

        // invoked when the selected drug type changes
        drugsearch.vm.DrugSelection.SelectedDrugType.subscribe(function (value) {            
            if (value === 0 || value === 1 || value === 4) {
                drugsearch.vm.DrugSelection.ShowPanel(false);
                if (value === 0) {
                    drugsearch.vm.DrugSelection.DisplayAs("All Drugs");
                }
                if (value === 1) {
                    drugsearch.vm.DrugSelection.DisplayAs("Maintenance");
                }
            }
            else {
                if (!drugsearch.haveDrugSource)
                    drugsearch.initDrugSource();
            }
        });
    },
    // retrieves the drug name list which we'll use for the typeahead control
    initDrugSource: function () {
        $.get("/sharedcontrols/GetDrugList", function (data) {
            $("#drugid").typeahead({ source: data });
        }, 'json');
        drugsearch.haveDrugSource = true;
    },
    // simple function that returns true if the search is numeric
    // used to determine if the search is a GPI/NDC or a drug name search
    isSearchNumeric: function (value) {
        return !isNaN(parseFloat(value)) && isFinite(value);
    },
    // invoked when the user clicks the search button of the drug id control
    onSearchClicked: function () {
        drugsearch.getDrugs();
    },
    // invoked when the user clicks the apply button
    onDrugSelectApply: function () {
        drugsearch.vm.DrugSelection.ShowPanel(false);
    },   
    // used to reset the filters 
    onResetClicked: function () {
        drugsearch.getDrugs();
    },
    onClearClicked: function () {
        drugsearch.clear();
        drugsearch.vm.DrugSelection.DrugId("");
        $("#drugid").focus();
    },
    // when the user clicks a row in the NDC table
    onNDCRowClicked: function (item) {
        // set the selected NDC, and let the subscription handle the rest
        drugsearch.vm.DrugSelection.SelectedNDC(item.NDC);
    },
    onGPIRowClicked: function (item) {
        drugsearch.vm.DrugSelection.SelectedGPI(item.GPI);
    },
    // retrieves the drug results based on the drug type and drug id entered by the user
    getDrugs: function () {
        var drugId = drugsearch.vm.DrugSelection.DrugId();
        if (drugId.length < 1)
            return;

        drugId = drugId.trim();        
        var isNumeric = drugsearch.vm.DrugSelection.IsSearchNumeric();
        var selectedDrugType = drugsearch.vm.DrugSelection.SelectedDrugType();
        console.log(selectedDrugType);

        if (isNumeric) {
            if (selectedDrugType === 2) {
                drugsearch.findDrugByGPI(drugId);
            }
            else if (selectedDrugType === 3) {
                drugsearch.findDrugByNDC(drugId);
            }
        }
        else {
            drugsearch.findDrugByName(drugId);
        }        
    },
    // finds the drug by name
    // (we already have the name, so it's searching for GPI, NDC, etc.)
    findDrugByName: function (drugId) {
        var url = "/sharedcontrols/FindDrugsByName";
        var drugSearch = { drugId: drugId };
        var payload = JSON.stringify(drugSearch);
        drugsearch.vm.DrugSelection.IsSearching(true);

        $("#drug-panel").block({
            message: '<i class="fa fa-circle-o-notch text-primary fa-pulse fa-2x fa-spin" style="font-size: 40px;padding:12px;background-color: transparent"></i>'
        });

        $.ajax({
            url: url,
            data: payload,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8"
        })
        .done(function (response) {
            if (response) {
                drugsearch.updateViewModel(response);                
            }
            else {
                console.log("There was a problem retrieving the drug results!");
            }
        })
        .fail(function (errorMessage) {
            console.log("Request failure");
        })
        .always(function () {
            drugsearch.vm.DrugSelection.IsSearching(false);
            $("#drug-panel").unblock();
            drugsearch.vm.DrugSelection.ShowPanel(true);
        });
    },
    // finds the drug by GPI
    findDrugByGPI: function (drugId) {
        var url = "/sharedcontrols/FindDrugsByGPI";   
        var drugSearch = { drugId: drugId };
        var payload = JSON.stringify(drugSearch);
        drugsearch.vm.DrugSelection.IsSearching(true);
        $("#drug-panel").block({
            message: '<i class="fa fa-circle-o-notch text-primary fa-pulse fa-2x fa-spin" style="font-size: 40px;padding:12px;background-color: transparent"></i>'
        });
        
        $.ajax({
            url: url,
            data: payload,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8"
        })
        .done(function (response) {
            if (response) {
                drugsearch.updateViewModel(response);
            }            
            else {
                console.log("There was a problem retrieving the drug results!");
            }
        })
        .fail(function (errorMessage) {
            console.log("Request failure");
        })
        .always(function () {
            drugsearch.vm.DrugSelection.IsSearching(false);
            $("#drug-panel").unblock();
            drugsearch.vm.DrugSelection.ShowPanel(true);
        });
    },
    // finds the drug by NDC
    findDrugByNDC: function (drugId) {
        var url = "/sharedcontrols/FindDrugsByNDC";
        var drugSearch = { drugId: drugId };
        var payload = JSON.stringify(drugSearch);
        drugsearch.vm.DrugSelection.IsSearching(true);
        $("#drug-panel").block({
            message: '<i class="fa fa-circle-o-notch text-primary fa-pulse fa-2x fa-spin" style="font-size: 40px;padding:12px;background-color: transparent"></i>'
        });
        $.ajax({
            url: url,
            data: payload,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8"
        })
        .done(function (response) {            
            if (response) {
                drugsearch.updateViewModel(response);            
            }
            else {
                console.log("There was a problem retrieving the drug results!");
            }
        })
        .fail(function (errorMessage) {
            console.log("Request failure");
        })
        .always(function () {
            drugsearch.vm.DrugSelection.IsSearching(false);
            $("#drug-panel").unblock();
            drugsearch.vm.DrugSelection.ShowPanel(true);
        });
    },
    // filter the drug results 
    filterDrugResults: function (dosage, strength) {
        var dvm = drugsearch.vm.DrugSelection;
        var filteredSearchResults = null;

        if (dosage && strength) {
            filteredSearchResults = _.filter(dvm.SearchResults(), function (searchResult) {
                return searchResult.dosage_form === dosage &&
                    (searchResult.strength + searchResult.strength_unit_of_measure) === strength;
            });
        }
        else if (dosage) {
            filteredSearchResults = _.filter(dvm.SearchResults(), function (searchResult) {
                return searchResult.dosage_form === dosage;
            });
        }
        else if (strength) {
            filteredSearchResults = _.filter(dvm.SearchResults(), function (searchResult) {
                return searchResult.strength + searchResult.strength_unit_of_measure === strength;
            });
        }        

        console.log("search results: " + dvm.SearchResults().length);
        console.log("filtered search results: " + filteredSearchResults.length);

        dvm.FilteredGPIs.removeAll();
        dvm.FilteredNDCs.removeAll();
        dvm.FilteredStrengths.removeAll();
        dvm.FilteredDosageOptions.removeAll();

        var uniqueGPIs = _.uniq(filteredSearchResults, function (item) {
            return item.generic_product_identifier;
        });

        var uniqueDosages = _.uniq(filteredSearchResults, function (item) { return item.dosage_form; });
        var uniqueStrengths = _.uniq(filteredSearchResults, function (item) {
            return [item.strength, item.strength_unit_of_measure].join();
        });

        _.forEach(uniqueDosages, function (item) { dvm.FilteredDosageOptions.push(item.dosage_form); });
        _.forEach(uniqueStrengths, function (item) { dvm.FilteredStrengths.push(item.strength + item.strength_unit_of_measure); });
       
        _.forEach(filteredSearchResults, function (item) {
            dvm.FilteredNDCs.push({
                DisplayName: drugsearch.getDrugName(item),
                MONY: item.multi_source_code,
                // had to convert maintenance code values to yes, no, or unknown. 
                // this is done in the C# viewmodel as well
                MaintenanceCode: drugsearch.getMaintenanceCode(item.maintenance_drug_code),
                NDC: item.ndc_upc_hri
            });
        });

        _.forEach(uniqueGPIs, function (item) {
            dvm.FilteredGPIs.push({
                GPI: item.generic_product_identifier,
                DisplayName: item.DisplayName
            });
        });
    },
    // clears the filtered lists 
    updateViewModel: function (response) {
        drugsearch.clear();
        var dvm = drugsearch.vm.DrugSelection;
        dvm.SearchResults(response.SearchResults);
        dvm.DosageOptions(response.DosageOptions);
        dvm.Strengths(response.Strengths);
        dvm.NDCs(response.NDCs);
        dvm.GPIs(response.GPIs);
        dvm.FilteredNDCs(response.NDCs);
        dvm.FilteredGPIs(response.GPIs);
        dvm.FilteredDosageOptions(response.DosageOptions);
        dvm.FilteredStrengths(response.Strengths);
        dvm.DisplayAs(response.DisplayName);        
    },
    // as the name implies, it clears the current drug search control
    clear: function () {
        var dvm = drugsearch.vm.DrugSelection;
        dvm.DisplayAs("");
        dvm.SearchResults.removeAll();
        dvm.DosageOptions.removeAll();
        dvm.Strengths.removeAll();
        dvm.NDCs.removeAll();
        dvm.GPIs.removeAll();
        dvm.FilteredNDCs.removeAll();
        dvm.FilteredGPIs.removeAll();
        dvm.FilteredStrengths.removeAll();
        dvm.FilteredDosageOptions.removeAll();
    },
    // returns a code 
    getMaintenanceCode: function (value) {
        if (value === "1")
            return "No";
        if (value === "2")
            return "Yes";
        else
            return "Unknown";
    },
    // retrieves the name of the drug
    getDrugName: function (item) {
        return item.drug_name + " "
            + item.dosage_form + " "
            + item.strength
            + item.strength_unit_of_measure;
    }
});