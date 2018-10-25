Declare("members", {
    serverModel: null,
    model: null,
    init: function () {       

        if (members.serverModel) {
            members.model = ko.observable(ko.mapping.fromJS(members.serverModel));
        }        
        ko.applyBindings(members.model);
    },
    onMemberResultClicked: function () {
       members.model().ShowSearch(false);
    },
    gotoSearch: function () {
        members.model().ShowSearch(true);
    },
    openConfigurationModal: function () {
        $("#configuration-modal").modal('show');
    },
    openClaimHistoryModal: function () {
        $("#claim-history-modal").modal('show');
    },
    openCreateCardHolderModal: function () {
        $("#create-card-holder-modal").modal('show');
    },
    openCreateDependentModal: function () {
        $("#create-dependent-modal").modal('show');
    },
    openDependentsModal: function () {
        $("#dependents-modal").modal('show');
    },
    openMPAModal: function () {
        $("#mpa-modal").modal('show');
    },
    addDiagnosisCodeClicked: function () {
        $("#diagnosis-code-modal").modal('show');
    },
    createDiagnosisCode: function () {
        var model = members.model();
        var code = model.NewDiagnosisCode();
        var existingCodes = model.MemberModel.DiagnosisCodes();
        if (code) {
            var dc = {
                Id: 0,
                Value: code,
                Description: '',
                Count: existingCodes.length + 1
            };
            model.MemberModel.DiagnosisCodes.push(ko.mapping.fromJS(dc));
            model.NewDiagnosisCode(null);
            $("#diagnosis-code-modal").modal('hide');
        }
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
    $("#new-dob").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
    $("#new-effective-date").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
    $("#new-term-date").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
    $("#new-group-effective-date").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });
    $("#new-group-term-date").datepicker({
        uiLibrary: 'bootstrap4',
        size: 'small',
        icons: {
            rightIcon: '<i class="fa fa-calendar text-primary" aria-hidden="true"></i>'
        }
    });    
});