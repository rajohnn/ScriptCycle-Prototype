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

ko.bindingHandlers.enterkey = {
    init: function (element, valueAccessor, allBindings, viewModel) {
        var callback = valueAccessor();
        $(element).keypress(function (event) {
            var keyCode = (event.which ? event.which : event.keyCode);
            if (keyCode === 13) {
                callback.call(viewModel);
                return false;
            }
            return true;
        });
    }
};

function formatCurrency(symbol, value, precision) {
    return (value < 0 ? "-" : "") + symbol + Math.abs(value).toFixed(precision).replace(/(\d)(?=(\d{3})+\.)/g, "$1,");
}

function rawNumber(val) {
    return Number(val.replace(/[^\d\.\-]/g, ""));
}

ko.bindingHandlers.currency = {
    symbol: ko.observable("$"),
    init: function (element, valueAccessor, allBindingsAccessor) {
        //only inputs need this, text values don't write back
        if ($(element).is("input") === true) {
            var underlyingObservable = valueAccessor(),
                interceptor = ko.computed({
                    read: underlyingObservable,
                    write: function (value) {
                        if (value === "") {
                            underlyingObservable(null);
                        } else {
                            underlyingObservable(rawNumber(value));
                        }
                    }
                });
            ko.bindingHandlers.value.init(element, function () {
                return interceptor;
            }, allBindingsAccessor);
        }
    },
    update: function (element, valueAccessor, allBindingsAccessor) {
        var symbol = ko.unwrap(allBindingsAccessor().symbol !== undefined ? allBindingsAccessor().symbol : ko.bindingHandlers.currency.symbol),
            value = ko.unwrap(valueAccessor());
        if ($(element).is("input") === true) {
            //leave the boxes empty by default
            value = value !== null && value !== undefined && value !== "" ? formatCurrency(symbol, parseFloat(value), 2) : "";
            $(element).val(value);
        } else {
            //text based bindings its nice to see a 0 in place of nothing
            value = value || 0;
            $(element).text(formatCurrency(symbol, parseFloat(value), 2));
        }
    }
};

ko.bindingHandlers.number = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var defaults = ko.bindingHandlers.number.defaults,
            aba = allBindingsAccessor,
            unwrap = ko.utils.unwrapObservable,
            value = unwrap(valueAccessor()) || valueAccessor(),
            result = '',
            numarray;

        var separator = unwrap(aba().separator) || defaults.separator,
            decimal = unwrap(aba().decimal) || defaults.decimal,
            precision = unwrap(aba().precision) || defaults.precision,
            symbol = unwrap(aba().symbol) || defaults.symbol,
            after = unwrap(aba().after) || defaults.after;

        value = parseFloat(value) || 0;

        if (precision > 0)
            value = value.toFixed(precision);

        numarray = value.toString().split('.');

        for (var i = 0; i < numarray.length; i++) {
            if (i === 0) {
                result += numarray[i].replace(/(\d)(?=(\d\d\d)+(?!\d))/g, '$1' + separator);
            } else {
                result += decimal + numarray[i];
            }
        }

        result = (after) ? result += symbol : symbol + result;

        ko.bindingHandlers.text.update(element, function () { return result; });
    },
    defaults: {
        separator: ',',
        decimal: '.',
        precision: 0,
        symbol: '',
        after: false
    }
};

// handles binding with bootstrap toggle buttons
ko.bindingHandlers.bootstrapToggleOn = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        $elem = $(element);
        $(element).bootstrapToggle({
            on: 'Yes',
            off: 'No',
            onstyle: 'primary',
            offstyle: 'danger'
        });
        if (ko.utils.unwrapObservable(valueAccessor())) {
            $elem.bootstrapToggle('on');
        } else {
            $elem.bootstrapToggle('off');
        }

        $elem.change(function () {
            if ($(this).prop('checked')) {
                valueAccessor()(true);
            } else {
                valueAccessor()(false);
            }
        });

    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var vStatus = $(element).prop('checked');
        var vmStatus = ko.utils.unwrapObservable(valueAccessor());
        if (vStatus !== vmStatus) {
            $(element).bootstrapToggle('toggle');
        }
    }
};