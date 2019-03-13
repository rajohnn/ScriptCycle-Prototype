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
    },
    getMonthlyPharmacyPayments: function () {
        var payments = [];
        payments.push('Payments'); // add chart axis title
        _.forEach(ap.vm.BillingCycleRecords().reverse(), function (item) {
            payments.push(item.PharmacyPaid());
        });
        return payments;
    },
    getPharmacyPaymentDates: function () {
        var dates = [];
        _.forEach(ap.vm.BillingCycleRecords(), function (item) {
            dates.push(moment(item.Date()).format('L'));
        });
        return dates;
    },
    onDismissDetails: function () {
        ap.vm.ShowDetails(false);
    },
    onDisplayDetails: function () {
        ap.vm.ShowDetails(true);
    },
    onDisplaySummary: function () {
        ap.vm.ShowDetails(true);
    },
    onViewClaimsFile: function () {
        console.log("on view claims file clicked.");
    },
    onConfigure: function () {
        var show = ap.vm.ShowDashboard();
        ap.vm.ShowDashboard(!show);
    },
    onSearchCheckNumber: function () {        
        $("#check-modal").modal("show");
    },
    onCloseCheckNumberResults: function () {
        $("#check-modal").modal("hide");
    }
});