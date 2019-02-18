Declare("step", {
    serverModel: null,
    model: null,
    vm: null,
    haveDrugSource: false,
    init: function () {
        if (step.serverModel) {
            step.model = ko.observable(ko.mapping.fromJS(step.serverModel));
        }
        step.vm = step.model();
        // set the drug search view model
        drugsearch.vm = step.model();
        drugsearch.initSubscriptions();

        step.initChunks();

        step.vm.Filter.subscribe(function (value) {
            if (value)
                step.applyFilteredProgramChunks(value);
        });      
        
        ko.applyBindings(step.model);

        $.get("https://next.json-generator.com/api/json/get/V1cGoKmDV", function (data) {
            console.log(data);
            $(".rule").typeahead({ source: data });
        }, 'json');  
    },
    initDrugSource: function () {        
        $.get("https://next.json-generator.com/api/json/get/V1cGoKmDV", function (data) {
            console.log(data);
            $("#drugid").typeahead({ source: data });
        }, 'json');
        step.haveDrugSource = true;
    },
    initChunks: function () {
        var count = step.vm.Programs().length;
        var programs = step.chunk(step.vm.Programs(), count / 3);
        step.vm.ChunkedPrograms = new ko.observableArray();
        step.vm.ChunkedPrograms(programs);

        count = step.vm.DrugFills().length;
        var drugFills = step.chunk(step.vm.DrugFills(), count / 3);
        step.vm.ChunkedDrugFills = new ko.observableArray();
        step.vm.ChunkedDrugFills(drugFills);

        step.applyChunks();
    },
    applyFilteredProgramChunks: function (filter) {
        step.vm.ChunkedPrograms.removeAll();
        var programs = step.vm.Programs();
        var filteredPrograms = _.filter(programs, function (program) {
            var name = program.Name().toLowerCase();
            var result = name.indexOf(filter.toLowerCase());
            if (result > -1) {
                return true;
            }
        });
        var count = filteredPrograms.length;
        if (count > 0) {
            var chunkedPrograms = step.chunk(filteredPrograms, count / 3);
            step.vm.ChunkedPrograms = new ko.observableArray();
            step.vm.ChunkedPrograms(chunkedPrograms);
        }
        step.clearProgramChunks();
        step.applyChunks();
    },
    applyChunks: function () {
        step.vm.ProgramsColumn1(step.vm.ChunkedPrograms()[0]);
        step.vm.ProgramsColumn2(step.vm.ChunkedPrograms()[1]);
        step.vm.ProgramsColumn3(step.vm.ChunkedPrograms()[2]);

        step.vm.DrugsColumn1(step.vm.ChunkedDrugFills()[0]);
        step.vm.DrugsColumn2(step.vm.ChunkedDrugFills()[1]);
        step.vm.DrugsColumn3(step.vm.ChunkedDrugFills()[2]);

        step.applySortable();
    },
    clearProgramChunks: function () {
        if (step.vm.ProgramsColumn1())
            step.vm.ProgramsColumn1.removeAll();

        if (step.vm.ProgramsColumn2())
            step.vm.ProgramsColumn2.removeAll();

        if (step.vm.ProgramsColumn3())
            step.vm.ProgramsColumn3.removeAll();
    },
    chunk: function (myArray, chunk_size) {
        var index = 0;
        var arrayLength = myArray.length;
        var tempArray = [];

        for (index = 0; index < arrayLength; index += chunk_size) {
            myChunk = myArray.slice(index, index + chunk_size);
            tempArray.push(myChunk);
        }
        return tempArray;
    },
    applySortable: function () {
        $(".column-tiers").sortable({
            placeholder: "sortable-placeholder",
            over: function () {
                $(".sortable-placeholder").stop().animate({
                    height: 0
                }, 400);
            },
            change: function () {
                $(".sortable-placeholder").stop().animate({
                    height: 100
                }, 400);
            }
        });
    },
    loadModal: function (selected) {
        console.log(selected);
        $("#step-tier-modal").modal('show');
    },
    onAddProgram: function () {
        $("#modal-create-program").modal("show");
    },
    onAddFill: function () {
        $("#modal-drug-fill").modal("show");
    },
    showPanel: function () {        
        step.vm.DrugSelection.ShowPanel(!step.vm.DrugSelection.ShowPanel());
    },
    onDrugSelectApply: function () {
        step.vm.DrugSelection.ShowPanel(false);
    },
    onCreateProgram: function () {
        var name = step.vm.NewProgramName();
        if (name && name.length > 0) {
            var url = "/StepTherapy/CreateProgram";

            $.ajax({
                url: url,
                data: JSON.stringify({ name: name }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8"
            })
            .done(function (response) {
                if (response) {
                    var program = ko.mapping.fromJS(response);
                    step.vm.Programs.push(program);
                    var count = step.vm.Programs().length;
                    var programs = step.chunk(step.vm.Programs(), count / 3);
                    step.vm.ChunkedPrograms = new ko.observableArray();
                    step.vm.ChunkedPrograms(programs);
                    step.applyChunks();
                    step.clearProgramModal();
                }
                else {
                    console.log("Create program call failed.");
                }
            })
            .fail(function (errorMessage) {
                console.log("massive failure.");
            })
            .always(function () {
            });
        }
    },
    clearProgramModal: function () {
        step.vm.NewProgramName("");
        $("#modal-create-program").modal("hide");
    }
});