Declare("ar", {
    serverModel: null,
    model: null,
    vm: null,
    init: function () {
        if (ar.serverModel) {
            ar.model = ko.observable(ko.mapping.fromJS(ar.serverModel));
        }
        ar.vm = ar.model();
        ko.applyBindings(ar.model);        
    },
    getMonthlyPayments: function () {
        var payments = [];
        payments.push('Payments'); // add chart axis title
        _.forEach(ar.vm.ClientPayments().reverse(), function (item) {
            payments.push(item.ClientBilled());
        });
        return payments;
    },
    getPaymentDates: function () {
        var dates = [];
        _.forEach(ar.vm.ClientPayments(), function (item) {
            dates.push(moment(item.Date()).format('L'));
        });
        return dates;
    },
    onUpload: function () {

    },
    onConfigure: function () {

    },
    onSearchCheckNumber: function () {

    },
    onDismissDetails: function () {

    }
});

$(function () {   

});