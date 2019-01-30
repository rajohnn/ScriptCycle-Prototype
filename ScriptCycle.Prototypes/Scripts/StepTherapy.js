Declare("step", {
    serverModel: null,
    model: null,
    vm: null,    
    init: function () {
        if (step.serverModel) {
            step.model = ko.observable(ko.mapping.fromJS(step.serverModel));
        }
        step.vm = step.model();
        step.initChunks();

        step.vm.Filter.subscribe(function (value) {            
            if (value)
                step.applyFilteredChuncks(value);
        });        

        ko.applyBindings(step.model);
    },
    initChunks: function () {
        var count = step.vm.Programs().length;
        var programs = step.chunk(step.vm.Programs(), count / 3);
        step.vm.ChunkedPrograms = new ko.observableArray();
        step.vm.ChunkedPrograms(programs);
        step.applyChunks();        
    },
    applyFilteredChuncks: function (filter) {
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
        step.clearChunks();
        step.applyChunks(); 
    },
    applyChunks: function () {        
        step.vm.ProgramsColumn1(step.vm.ChunkedPrograms()[0]);
        step.vm.ProgramsColumn2(step.vm.ChunkedPrograms()[1]);
        step.vm.ProgramsColumn3(step.vm.ChunkedPrograms()[2]); 
        step.applySortable();
    },
    clearChunks: function () {
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
        // console.log(selected);
        $("#step-tier-modal").modal('show');
    }
});