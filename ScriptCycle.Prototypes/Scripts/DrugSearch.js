Declare("drugsearch", {
    serverModel: null,
    model: null,
    vm: null,   
    haveDrugSource: false,
    init: function () {
        if (drugsearch.serverModel) {
            drugsearch.model = ko.observable(ko.mapping.fromJS(drugsearch.serverModel));
        }
        drugsearch.vm = drugsearch.model();
        drugsearch.initSubscriptions();
        ko.applyBindings(drugsearch.model);
    },
    initSubscriptions: function () {
        drugsearch.vm.DrugSelection.SelectedDrugType.subscribe(function (value) {
            drugsearch.vm.DrugSelection.DisplayAs("");
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
    showPanel: function () {
        drugsearch.vm.DrugSelection.ShowPanel(!drugsearch.vm.DrugSelection.ShowPanel());
    },
    onDrugSelectApply: function () {
        drugsearch.vm.DrugSelection.ShowPanel(false);
    },
    initDrugSource: function () {
        $.get("https://next.json-generator.com/api/json/get/V1cGoKmDV", function (data) {
            console.log(data);
            $("#drugid").typeahead({ source: data });
        }, 'json');
        drugsearch.haveDrugSource = true;
    }
});