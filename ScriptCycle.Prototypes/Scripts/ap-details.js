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
            grouping: { contextMenuEnabled: true },
            groupPanel: { visible: true },
            onSelectionChanged: function (selectedItem) {
                console.log(selectedItem);
            }
        });
    }    
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
                    $("#grid-claims").dxDataGrid("columnOption", "PharmacyChainCode", "groupIndex", 0);
                });
            }
        }),
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
        placeholder: "Select a value...",
        displayExpr: "Name",
        showClearButton: true,
        dataSource: makeAsyncDataSource("getcycles"),
        contentTemplate: function (e) {
            var value = e.component.option("value"),
                $dataGrid = $("<div>").dxDataGrid({
                    dataSource: e.component.option("dataSource"),
                    columns: ["ID", "Name", "Date"],
                    hoverStateEnabled: true,
                    paging: { enabled: true, pageSize: 10 },
                    filterRow: { visible: true },
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

    $("#gridBox2").dxDropDownBox({
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
                    filterRow: { visible: true },
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
                    filterRow: { visible: true },
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
});