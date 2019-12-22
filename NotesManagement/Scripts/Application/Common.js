

var $loading = $('#loading').hide();

//Attach the event handler to any element
$(document)
    .ajaxStart(function () {
        //ajax request went so show the loading image
        $loading.show();
    })
    .ajaxStop(function () {
        //got response so hide the loading image
        $loading.hide();
    });

jQuery.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    for (var i = 0, l = a.length; i < l; i++) {
        var item = a[i];
        var name = item.name;
        // if the value is null or undefined, we set to empty string, else we
        // use the value passed
        var value = item.value != null ? item.value : '';

        // if the key already exists we convert it to an array
        if (o[name] !== undefined) {
            if (!o[name].push) {
                // convert to array
                o[name] = [o[name]];
            }
            o[name].push(value);
        }
        else {
            o[name] = value;
        }
    }

    return o;
};