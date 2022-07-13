
$(document).ready(function () {
    $.get("/Skills/GetSkills", function (response) {
        console.log(response);
        $('#skillList').empty();
        response.map(skill =>
            $('#skillList').append($('<option/>', {
                value: skill,
                text: skill

            })))
    })
});