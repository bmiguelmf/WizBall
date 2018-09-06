$(document).ready(function () {

    //html elements
    var pass = $('#pwd');
    var eye_icon = $('#eye');

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

    }

    //function getUsername() {
    //    window.location = "file:///C:/wamp64/www/siteRefood/refood_project/refood2/recuperar-password.html";

    //}
    //end functions

    //events
    eye_icon.click(function () {
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









    console.log('READY login.js');
});