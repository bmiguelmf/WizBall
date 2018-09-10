$(document).ready(function () {

    //html elements
    var pass = $('#pwd');
    var icon_eye = $('#eye');
    var btn_login = $('#login');

    //vars
    var passShown = 0;


    //functions
    function showPassword() {
        pass.attr("type", "text");
    }
    function hidePassword() {
        pass.attr("type", "password");
    }

    function authenticate() {
        var username = $('#username').val();
        var password = $('#password').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WebService.asmx/AdminLogin",
            dataType: "json",
            data: "{Username: " + JSON.stringify(username) + ", Password:" + JSON.stringify(password) + "}",
            success: function (data) {
                $(location).attr('href', "Users.aspx");
            },
            error: function (data, status, error) {
                swal("Erro!", "Lamentamos, não foi possível iniciar sessão... ", "warning");
            }
        });
    }

    //function getUsername() {
    //    window.location = "file:///C:/wamp64/www/siteRefood/refood_project/refood2/recuperar-password.html";

    //}
    //end functions

    //events
    icon_eye.click(function () {
        if (passShown === 0) {
            passShown = 1;
            showPassword();
            eye_icon.removeClass("fa-eye").addClass("fa-eye-slash");
        } else {
            passShown = 0;
            hidePassword();
            eye_icon.removeClass("fa-eye-slash").addClass("fa-eye");
        }
    });

    btn_login.click(function () {
        authenticate();
    });








    console.log('READY login.js');
});