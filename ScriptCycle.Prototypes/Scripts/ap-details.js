Declare("ap", {
    serverModel: null,
    model: null,
    vm: null,
    init: function () {
        if (ap.serverModel) {
            ap.model = ko.observable(ko.mapping.fromJS(ap.serverModel));
        }
        ap.vm = ap.model();
        ko.applyBindings(ap.model);

        $("#grid-payees").dxDataGrid({
            dataSource: ap.vm.PayeeDetailRecords,
            selection: { mode: 'single' },
            grouping: {
                contextMenuEnabled: true
            },
            columns: [
                "BillingCycleDate",
                "APCycleName",
                "PaymentCenterId",
                {
                    dataField: "PaymentCenterName",
                    groupIndex: 0
                },
                "CheckNumber",
                "TotalPharmacyPaid",
                "TotalClaims"
            ],
            groupPanel: { visible: true },
            onSelectionChanged: function (selectedItem) {
                console.log(selectedItem);
            }
        });
    },
    onSearchCheckNumber: function () {
        $("#check-modal").modal("show");
    },
    onCloseCheckNumberResults: function () {
        $("#check-modal").modal("hide");
    },
});

$(function () {
    var dataGrid;

    var makeAsyncDataSource = function (jsonFile) {
        return new DevExpress.data.CustomStore({
            loadMode: "raw",
            key: "ID",
            load: function () {
                return $.getJSON('/ap/' + jsonFile);
            }
        });
    };

    $("#grid-claims").dxDataGrid({
        dataSource: new DevExpress.data.DataSource({
            load: function () {
                return $.getJSON('/ap/GetClaimDetails').done(function (result) {
                    console.log("load of claims is done.");                    
                });
            }
        }),
        columns: [
            "Name",
            "BillingDate",
            "ClaimDate",
            "Rx",
            "RxDate",
            "NCPDP",
            "PharmacyName",
            "PharmacyChain",
            {
                dataField: "PharmacyChainCode",
                groupIndex: 0
            },            
            "Col20180101",
            "Code",
            "NDC",
            "DrugName"
        ],
        selection: { mode: 'single' },
        grouping: { contextMenuEnabled: true },
        groupPanel: { visible: true },
        onSelectionChanged: function (selectedItem) {
            ap.vm.SelectedClaim(selectedItem);
            $("#check-modal").modal('show');
        }
    });

    $("#gridBox").dxDropDownBox({
        value: [8],
        valueExpr: "ID",
        placeholder: "Select billing cycles...",
        displayExpr: "Name",
        showClearButton: true,
        dataSource: makeAsyncDataSource("getcycles"),
        contentTemplate: function (e) {
            var value = e.component.option("value"),
                $dataGrid = $("<div>").dxDataGrid({
                    configuration: {
                        showCheckboxesMode: 'Always'
                    },
                    dataSource: e.component.option("dataSource"),
                    columns: [
                        { dataField: "ID", width: 50 },
                        { dataField: "Name", width: 200 },
                        { dataField: "Date", width: 125 }
                    ],
                    hoverStateEnabled: true,
                    paging: { enabled: true, pageSize: 10 },
                    filterRow: { visible: false },
                    scrolling: { mode: "infinite" },
                    height: 345,
                    selection: { mode: "multiple" },
                    selectedRowKeys: value,
                    onSelectionChanged: function (selectedItems) {
                        var keys = selectedItems.selectedRowKeys;
                        e.component.option("value", keys);
                    }
                });

            dataGrid = $dataGrid.dxDataGrid("instance");

            e.component.on("valueChanged", function (args) {
                var value = args.value;
                dataGrid.selectRows(value, false);
            });

            return $dataGrid;
        }
    });

    $("#gridBox2").dxDropDownBox({
        value: [8],
        valueExpr: "ID",
        placeholder: "Select billing cycles...",
        displayExpr: "Name",
        showClearButton: true,       
        dataSource: makeAsyncDataSource("getcycles"),
        contentTemplate: function (e) {
            var value = e.component.option("value"),
                $dataGrid = $("<div>").dxDataGrid({
                    dataSource: e.component.option("dataSource"),
                    columns: ["Name"],
                    hoverStateEnabled: true,
                    paging: { enabled: true, pageSize: 10 },
                    filterRow: { visible: false },
                    scrolling: { mode: "infinite" },
                    //height: 245,
                    selection: { mode: "multiple" },
                    selectedRowKeys: value,
                    onSelectionChanged: function (selectedItems) {
                        var keys = selectedItems.selectedRowKeys;
                        e.component.option("value", keys);
                    }
                });

            dataGrid = $dataGrid.dxDataGrid("instance");

            e.component.on("valueChanged", function (args) {
                var value = args.value;
                dataGrid.selectRows(value, false);
            });

            return $dataGrid;
        }
    });

    $("#gridBox3").dxDropDownBox({
        value: [8],
        valueExpr: "ID",
        placeholder: "Select a value...",
        displayExpr: "Name",
        showClearButton: true,
        dataSource: makeAsyncDataSource("getcycles"),
        contentTemplate: function (e) {
            var value = e.component.option("value"),
                $dataGrid = $("<div>").dxDataGrid({
                    dataSource: e.component.option("dataSource"),
                    columns: ["Name"],
                    hoverStateEnabled: true,
                    paging: { enabled: true, pageSize: 10 },
                    filterRow: { visible: false },
                    scrolling: { mode: "infinite" },                    
                    selection: { mode: "multiple" },
                    selectedRowKeys: value,
                    onSelectionChanged: function (selectedItems) {
                        var keys = selectedItems.selectedRowKeys;
                        e.component.option("value", keys);
                    }
                });

            dataGrid = $dataGrid.dxDataGrid("instance");

            e.component.on("valueChanged", function (args) {
                var value = args.value;
                dataGrid.selectRows(value, false);
            });

            return $dataGrid;
        }
    });
});