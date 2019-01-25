Declare("step", {
    serverModel: null,
    model: null,
    internalDNDType: 'text/x-example',
    init: function () {
        if (step.serverModel) {
            step.model = ko.observable(ko.mapping.fromJS(step.serverModel));
        }
        ko.applyBindings(step.model);
    }
});