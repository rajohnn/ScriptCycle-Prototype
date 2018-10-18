Declare("members", {
    serverModel: null,
    model: null,
    init: function () {       

        if (configuration.serverModel) {
            configuration.model = ko.observable(ko.mapping.fromJS(members.serverModel));
        }        
        ko.applyBindings(members.model);
    }    
});

$(function () {  
    $("#date-of-birth").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
    $("#group-effective-date").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
    $("#group-term-date").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
    $("#subgroup-term-date").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
    $("#subgroup-effective-date").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
});