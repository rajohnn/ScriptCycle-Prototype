function Declare(namespaceString, objectLiteral) {
    if (!namespaceString) {
        throw "namespaceString must be set";
    }
    var namespaceObj = window;
    var namespaceNames = namespaceString.split(".");
    for (var i = 0; i < namespaceNames.length; i++) {
        var name = namespaceNames[i];
        namespaceObj[name] = namespaceObj[name] || {};
        if (i === namespaceNames.length - 1) {
            namespaceObj[name] = $.extend(namespaceObj[name], objectLiteral);
        }
        namespaceObj = namespaceObj[name];
    }
    return objectLiteral;
}


ko.bindingHandlers.slideVisible = {
    init: function (element, valueAccessor) {
        // Initially set the element to be instantly visible/hidden depending on the value
        var value = valueAccessor();
        $(element).toggle(ko.unwrap(value)); // Use "unwrapObservable" so we can handle values that may or may not be observable
    },
    update: function (element, valueAccessor) {
        // Whenever the value subsequently changes, slide the element in or out
        var value = valueAccessor();
        ko.unwrap(value) ? $(element).slideDown() : $(element).slideUp();
    }
};

ko.bindingHandlers.fadeVisible = {
    init: function (element, valueAccessor) {
        // Initially set the element to be instantly visible/hidden depending on the value
        var value = valueAccessor();
        $(element).toggle(ko.unwrap(value)); // Use "unwrapObservable" so we can handle values that may or may not be observable
    },
    update: function (element, valueAccessor) {
        // Whenever the value subsequently changes, slowly fade the element in or out
        var value = valueAccessor();
        ko.unwrap(value) ? $(element).fadeIn() : $(element).fadeOut();
    }
};