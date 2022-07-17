// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#CountryList").change(function () {
        var paraId = document.getElementById("CountryList").value;

        var ddlstates = $('#StateList');
        var ddlCities = $('#CityList');

        //         alert(ddlcountries.val());
        $.ajax({
            cache: false,
            url: '/Member/GetStatesByCountryId',
            method: 'get',
            data: { countryId: paraId },
            dataType: 'json',
            success: function (data) {
                ddlstates.empty();

                ddlstates.append($('<option/>', { value: -1, text: 'Select States' }))
                ddlstates.prop('disabled', false);
                $(data).each(function (index, item) {
                    console.log(item);
                    ddlstates.append($('<option/>', { value: item.stateId, text: item.stateName }))
                })
            },

            error: function (err) {
                alert(err + ' ' + $(this).val());
            }
        }) //End ajax
    }) //Onchange Country

    $("#StateList").change(function () {
        var subId = document.getElementById("StateList").value;
        var ddlstates = $('#StateList');
        var ddlCities = $('#CityList');

        $.ajax({
            cache: false,
            url: '/Member/GetCityByStateId',
            method: 'get',
            data: { StateId: subId },
            dataType: 'json',
            success: function (data) {
                ddlCities.empty();

                ddlCities.append($('<option/>', { value: -1, text: 'Select Cities' }))
                ddlCities.prop('disabled', false);
                $(data).each(function (index, item) {
                    console.log(item);
                    ddlCities.append($('<option/>', { value: item.cityId, text: item.cityName }))
                })
            },

            error: function (err) {
                alert(err + ' ' + $(this).val());
            }
        }) //End ajax
    }) //Onchange State
}) // document