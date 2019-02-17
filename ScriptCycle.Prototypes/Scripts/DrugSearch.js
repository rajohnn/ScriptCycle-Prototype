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
        drugsearch.vm.DrugSelection.DrugId.subscribe(function (value) {
            var isNumeric = drugsearch.isSearchNumeric(value);
            drugsearch.vm.DrugSelection.IsSearchNumeric(isNumeric);
            console.log("IsNumeric: " + isNumeric);
        });

        drugsearch.vm.DrugSelection.SelectedDosage.subscribe(function (value) {
            console.log("Dosage changed: " + value);
        });
        drugsearch.vm.DrugSelection.SelectedStrength.subscribe(function (value) {
            console.log("Strength changed: " + value);
        });
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
        var drugId = drugsearch.vm.DrugSelection.DrugId();
        if (drugId.length < 1)
            return;

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
        drugsearch.vm.DrugSelection.ShowPanel(true);
    },
    // invoked when the user clicks the apply button
    onDrugSelectApply: function () {
        drugsearch.vm.DrugSelection.ShowPanel(false);
    },   
    // finds the drug by name
    // (we already have the name, so it's searching for GPI, NDC, etc.)
    findDrugByName: function (drugId) {
        var url = "/sharedcontrols/FindDrugsByName";
        var drugSearch = { drugId: drugId };
        var payload = JSON.stringify(drugSearch);
        drugsearch.vm.DrugSelection.IsSearching(true);

        $.ajax({
            url: url,
            data: payload,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8"
        })
        .done(function (response) {
            var dvm = drugsearch.vm.DrugSelection;
            dvm.DisplayAs("");
            dvm.SearchResults.removeAll();
            dvm.DosageOptions.removeAll();
            dvm.Strengths.removeAll();
            dvm.NDCs.removeAll();
            dvm.GPIs.removeAll();

            if (response) {
                dvm.SearchResults(response.SearchResults);
                dvm.DosageOptions(response.DosageOptions);
                dvm.Strengths(response.Strengths);
                dvm.NDCs(response.NDCs);
                dvm.GPIs(response.GPIs);
                dvm.DisplayAs(drugId);
                console.log(response);
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
        });
    },
    // finds the drug by GPI
    findDrugByGPI: function (drugId) {
        var url = "/sharedcontrols/FindDrugsByGPI";   
        var drugSearch = { drugId: drugId };
        var payload = JSON.stringify(drugSearch);
        drugsearch.vm.DrugSelection.IsSearching(true);
        

        $.ajax({
            url: url,
            data: payload,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8"
        })
        .done(function (response){
            var dvm = drugsearch.vm.DrugSelection;
            dvm.DisplayAs("");
            dvm.SearchResults.removeAll();
            dvm.DosageOptions.removeAll();
            dvm.Strengths.removeAll();
            dvm.NDCs.removeAll();
            dvm.GPIs.removeAll();

            if (response) {
                dvm.SearchResults(response.SearchResults);
                dvm.DosageOptions(response.DosageOptions);
                dvm.Strengths(response.Strengths);
                dvm.NDCs(response.NDCs);
                dvm.GPIs(response.GPIs);
                dvm.DisplayAs(response.DisplayName);
                console.log(response);
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
        });
    },
    // finds the drug by NDC
    findDrugByNDC: function (drugId) {
        var url = "/sharedcontrols/FindDrugsByNDC";
        var drugSearch = { drugId: drugId };
        var payload = JSON.stringify(drugSearch);
        drugsearch.vm.DrugSelection.IsSearching(true);


        $.ajax({
            url: url,
            data: payload,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8"
        })
        .done(function (response) {
            var dvm = drugsearch.vm.DrugSelection;
            dvm.SearchResults.removeAll();
            dvm.DosageOptions.removeAll();
            dvm.Strengths.removeAll();
            dvm.NDCs.removeAll();
            dvm.GPIs.removeAll();
            dvm.DisplayAs("");

            if (response) {
                dvm.SearchResults(response.SearchResults);
                dvm.DosageOptions(response.DosageOptions);
                dvm.Strengths(response.Strengths);
                dvm.NDCs(response.NDCs);
                dvm.GPIs(response.GPIs);
                dvm.DisplayAs(response.DisplayName);
                console.log(response);
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
        });
    }
});