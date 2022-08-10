$(document).ready(function () {
    $("#CountryEdit").change(function () {
        var paraId = document.getElementById("CountryEdit").value;

        var ddlstates = $('#StateEdit');
        var ddlCities = $('#CityEdit');

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

    $("#StateEdit").change(function () {
        var subId = document.getElementById("StateEdit").value;

        var ddlCities = $('#CityEdit');

        $.ajax({
            cache: false,
            url: '/Member/GetCityByStateId',
            method: 'get',
            data: { StateId: subId },
            dataType: 'json',
            success: function (data) {
                ddlCities.empty();
                //ddlCities.append($('<option/>', { value: -1, text: 'Select Cities' }))
                ddlCities.prop('disabled', false);
                $(data).each(function (index, item) {
                    console.log(item);
                    ddlCities.append($('<option/>', { value: item.cityId, text: item.cityName }))
                });
            },

            error: function (err) {
                alert(err + ' ' + $(this).val());
            }
        }) //End ajax
    }) //Onchange State

    $("#regMemberId").change(function () {
        var paraId = document.getElementById("regMemberId").value;
        var ddlUserName = $('#regUserName');
        var ddlFirstName = $('#regFirstName');
        var ddlLastName = $('#regLastName');
        var ddlEmail = $('#regEmail');
        var url = '/Account/GetMemberById';

        $.ajax({
            cache: false,
            url: url,
            method: 'get',
            data: { memberId: paraId },
            dataType: 'json',
            success: function (data) {
                ddlFirstName.empty();
                ddlLastName.empty();
                ddlFirstName.val(data.firstName);
                ddlLastName.val(data.lastName);
                ddlEmail.val(data.email);
                ddlUserName.val('User'+data.memberId)
                console.log(data.firstName+' '+data.lastName);
            },
            error: function (err) {
                alert(err + ' ' + $(this).val());
            }
        })
    })
});
