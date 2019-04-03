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
        $("#upload-modal").modal("show");
    },
    onConfigure: function () {
        var show = ar.vm.ShowDashboard();
        ar.vm.ShowDashboard(!show);
        ar.vm.ShowConfig(show);
        ar.vm.ShowARDetails(false);
    },
    onDismissConfigure: function () {
        ar.vm.ShowDashboard(true);
        ar.vm.ShowConfig(false);
        ar.vm.ShowARDetails(false);
    },
    onSearchInvoiceNumber: function () {
        $("#invoice-modal").modal("show");
    },
    onCloseCheckNumberResults: function () {
        $("#invoice-modal").modal("hide");
    },
    onDismissDetails: function () {
        ar.vm.ShowDetails(false);
    },
    onDisplayDetails: function () {
        ar.vm.ShowDetails(true);
    },
    onDetails: function () {
        ar.vm.ShowDashboard(false);
        ar.vm.ShowARDetails(true);
    }
});

$(function () {   

});