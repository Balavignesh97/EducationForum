(function () {
    $('#LoginSpinner').hide();
})();
$('#Loginbtn').click(function () {

    //var Validstatus = $("#LoginForm").valid();
    //if (Validstatus == true) {
        $('#LoginSpinner').show();
        $("#Loginbtn").prop("disabled", true);

        var datastring = $(this).closest('form').serialize();
        var object2 = '/Authentication/AuthenticateLogin';

        Callservice(datastring, object2);
    //}
});