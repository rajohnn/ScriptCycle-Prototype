Declare("apProcess", {
    serverModel: null,
    model: null,
    vm: null,
    init: function () {
        if (apProcess.serverModel) {
            apProcess.model = ko.observable(ko.mapping.fromJS(apProcess.serverModel));
        }
        apProcess.vm = apProcess.model();

        apProcess.vm.Step.subscribe(function (value) {
            if (value === 4) {
                $("#file-modal").modal('show'); 
            }
            if (value === 5) {
                $("#file-posting-modal").modal('show');
            }
        });

        apProcess.vm.FileProgress.subscribe(function (value) {
            if (value === 100) {                
                $("#file-modal").modal('hide');
                apProcess.onNextStep();
            }  
        });

        apProcess.vm.PostProgress.subscribe(function (value) {
            if (value === 100) {
                $("#file-posting-modal").modal('hide');
                console.log("complete");
            }
        });
        ko.applyBindings(apProcess.model);       
    },
    onGotoStep: function (step) {
        apProcess.vm.Step(step);
    },
    onNextStep: function () {
        var step = apProcess.vm.Step();
        step = step + 1;
        apProcess.vm.Step(step);
    },
    onPreviousStep: function () {
        var step = apProcess.vm.Step();
        step = step - 1;
        apProcess.vm.Step(step);
    },
    generateFiles: function () {
        apProcess.vm.FileProgress(0);
        var timer = setInterval(function () {
            apProcess.vm.FileProgress(apProcess.vm.FileProgress() + 1);
        }, 150);
    },
    postFiles: function () {
        apProcess.vm.PostProgress(0);
        var timer = setInterval(function () {
            apProcess.vm.PostProgress(apProcess.vm.PostProgress() + 1);
        }, 150);
    }  
});

$(function () {
    $("#file-modal").on('shown.bs.modal', function () {
        apProcess.generateFiles();
    });   

    $("#file-posting-modal").on('shown.bs.modal', function () {
        apProcess.postFiles();
    });  

    var makeAsyncDataSource = function (jsonFile) {
        return new DevExpress.data.CustomStore({
            loadMode: "raw",
            key: "ID",
            load: function () {
                return $.getJSON("" + jsonFile);
            }
        });
    };

    $("#gridBox").dxDropDownBox({
        value: [],
        valueExpr: "ID",
        placeholder: "Select a value...",
        displayExpr: "Name",
        showClearButton: true,
        dataSource: makeAsyncDataSource("getcycles"),
        dropDownOptions: {
            showTitle: false,
            fullScreen: false,
            showCloseButton: true
        },
        contentTemplate: function (e) {
            var value = e.component.option("value"),
                $dataGrid = $("<div>").dxDataGrid({
                    dataSource: e.component.option("dataSource"),
                    columns: ["ID", "Name"],
                    hoverStateEnabled: true,
                    paging: { enabled: true, pageSize: 10 },
                    filterRow: { visible: true },
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

    $("#batch-grid").dxDataGrid({
        dataSource: new DevExpress.data.DataSource({
            load: function () {
                return $.getJSON('GetProcessRecords').done(function (result) {
                    console.log("process records loaded.");
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
    $("#batch-grid-2").dxDataGrid({
        dataSource: new DevExpress.data.DataSource({
            load: function () {
                return $.getJSON('GetProcessRecords').done(function (result) {
                    console.log("process records loaded.");
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
});