$(document).ready(function () {

    //html elements
    var input_username = $('#input_username');
    var input_password = $('#input_password');
    var icon_eye = $('#eye');
    var btn_login = $('#login');
    var form = $('#form_login');
    var error = $('#error_message');

    //vars
    var passShown = 0;


    //functions
    function showPassword() {
        input_password.attr("type", "text");
    }

    function hidePassword() {
        input_password.attr("type", "password");
    }

    function validateForm() {
        var validated = true;
        $(".has-error").removeClass("has-error");

        if (input_username.val() === "") {
            input_username.closest(".form-group").addClass("has-error");
            error.fadeIn();
            error.find('.message').text("Please, fill in the username field.");
            validated = false;
        }

        if (input_password.val() === "") {
            input_password.closest(".form-group").addClass("has-error");
            error.fadeIn();
            error.find('.message').text("Please, fill in the password field.");
            validated = false;
        }
        
        if (validated) {
            error.hide();
            error.find('.message').text("");
        } else {
            error.fadeIn();
        }

        return validated;
    }

    function clearForm() {
        input_username.val("");
        input_password.val("");
    }

    function authenticate() {
        if (!validateForm()) {
            return;
        }
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WebService.asmx/AdminLogin",
            dataType: "json",
            data: "{Username: " + JSON.stringify(input_username.val()) + ", Password:" + JSON.stringify(input_password.val()) + "}",
            success: function (data) {
                if (data.d !== null) {
                    $.session.set("AdminUsername", data.d['Username']);
                    $.session.set("AdminId", data.d['Id']);
                    swal("Success!", "You are logged in.", "success")
                        .then((value) => {
                            window.location.href = 'Users.aspx';
                        });
                } else {
                    swal("Error!", "Incorrect username or password. ", "warning").then((value) => {
                        clearForm();
                    });
                }
                
            },
            error: function (data, status, error) {
                swal("Error!", " " + (error.message === undefined ? "Unknown error" : error.message) + " ", "warning");
            }
        });
    }


    //events
    icon_eye.click(function () {
        if (passShown === 0) {
            passShown = 1;
            showPassword();
            icon_eye.removeClass("fa-eye").addClass("fa-eye-slash");
        } else {
            passShown = 0;
            hidePassword();
            icon_eye.removeClass("fa-eye-slash").addClass("fa-eye");
        }
    });

    btn_login.click(function () {
        authenticate();
    });
   
    console.log('READY login.js');
});