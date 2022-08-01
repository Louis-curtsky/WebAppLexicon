$(document).ready(function () {
    $("#CityInput").change(function () {
        var ddlstates = $('#StateAll');
        var url = '/Member/GetStates';
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
                console.log(data.firstName+' '+data.lastName);
                ddlFirstName.val(data.firstName);
                ddlLastName.val(data.lastName);
                ddlEmail.val(data.email);
                ddlUserName.val('User'+data.memberId)
            },
            error: function (err) {
                alert(err + ' ' + $(this).val());
            }
        })
    })
});
