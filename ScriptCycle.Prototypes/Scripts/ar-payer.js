Declare("arPayer", {
    serverModel: null,
    model: null,
    vm: null,
    init: function () {
        if (arPayer.serverModel) {
            arPayer.model = ko.observable(ko.mapping.fromJS(arPayer.serverModel));
        }
        arPayer.vm = arPayer.model();
        ko.applyBindings(arPayer.model);

        $("#grid-payers").dxDataGrid({
            dataSource: arPayer.vm.Payers,
            selection: { mode: 'single' },
            grouping: {
                contextMenuEnabled: true
            },
            paging: {
                pageSize: 15
            },
            columns: [
                "OrgID",
                "OrgName",
                "CarrierCode",
                "CarrierName",
                "GroupNumber",
                "GroupName",
                "NetTerms"
            ],
            groupPanel: { visible: true },
            onSelectionChanged: function (selectedItem) {
                console.log(selectedItem);
            }
        });
    },
    onUpload: function () {

    },
    onConfigure: function () {
        var isConfig = arPayer.vm.ShowConfig();
        arPayer.vm.ShowConfig(!isConfig);
        arPayer.vm.ShowDashboard(isConfig);
    },
    onDismissConfig: function () {
        var isConfig = arPayer.vm.ShowConfig();
        arPayer.vm.ShowConfig(!isConfig);
        arPayer.vm.ShowDashboard(isConfig);
    }
});

$(function () {

});