$("#CityInput").change(function () {
    var ddlstates = $('#StateAll');
    var url = '/State/GetStates';
    $.ajax({
        cache: false,
        url: url,
        method: 'get',
        dataType: 'json',
        success: function (data) {
            ddlstates.empty();
            console.log(data);
            ddlstates.append($('<option/>', { value: -1, text: 'Select States' }))
            ddlstates.prop('disabled', false);
            $(data).each(function (index, item) {
                ddlstates.append($('<option/>', { value: item.stateId, text: item.stateName }))
            })
        },

        error: function (err) {
            alert(err + ' ' + $(this).val());
        }
    }) 
}) 
