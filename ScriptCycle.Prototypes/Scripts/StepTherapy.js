Declare("step", {
    serverModel: null,
    model: null,
    vm: null,    
    init: function () {
        if (step.serverModel) {
            step.model = ko.observable(ko.mapping.fromJS(step.serverModel));
        }
        step.vm = step.model();

        var count = step.vm.Programs().length;
        var programs = step.chunk(step.vm.Programs(), count / 3);

        step.vm.ChunkedPrograms = new ko.observableArray();
        step.vm.ChunkedPrograms(programs);

        step.vm.ProgramColumn1 = ko.pureComputed(function () {
            return step.vm.ChunkedPrograms()[0];
        }, this);

        step.vm.ProgramColumn2 = ko.pureComputed(function () {
            return step.vm.ChunkedPrograms()[1];
        }, this);

        step.vm.ProgramColumn3 = ko.pureComputed(function () {
            return step.vm.ChunkedPrograms()[2];
        }, this);

        ko.applyBindings(step.model);
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
    loadModal: function (selected) {
        console.log(selected);
        $("#step-tier-modal").modal('show');
    }
});