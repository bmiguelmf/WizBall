function IsFormValid() {

    var result = true;

    if (!isUsernameReady()) {
        result = false;
    }

    if (!isEmailReady()) {
        result = false;
    }

    if (!isPasswordReady()) {
        result = false;
    }

    VerifyUsername();

    return result;
}


function isUsernameReady() {

    var result = true;

    var txtUsername     = document.getElementById("txtUsername").value;
    var usernameStatus  = document.getElementById("usernameStatus");

    if (txtUsername.length === 0) {
        usernameStatus.innerText = "Required | Max : 50";
        result = false;
    }
    else if (txtUsername.length > 50) {
        usernameStatus.innerText = "Max length 50";
        result = false;
    }
    else {
        usernameStatus.innerText = "";
    }

    return result;
}
function isEmailReady() {

    var result = true;

    var txtEmail = document.getElementById("txtEmail").value;
    var emailStatus = document.getElementById("emailStatus");

    var emailValidator = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()\.,;\s@\"]+\.{0,1})+[^<>()\.,;:\s@\"]{2,})$/;

    if (txtEmail.length === 0) {
        emailStatus.innerText = "Required";
        result = false;
    }
    else if (txtEmail.length > 100) {
        emailStatus.innerText = "Max length 100";
        result = false;
    }
    else if (!emailValidator.test(txtEmail)) {
        emailStatus.innerText = "Invalid email format";
        result = false;
    }
    else {
        emailStatus.innerText = "";
    }

    return result;
}
function isPasswordReady() {

    var result = true;

    var txtPassword = document.getElementById("txtPassword").value;
    var passwordStatus = document.getElementById("passwordStatus");

    if (txtPassword.length === 0) {
        passwordStatus.innerText = "Required";
        result = false;
    }
    else if (txtPassword.length < 6) {
        passwordStatus.innerText = "Min length 6";
        result = false;
    }
    else if (txtPassword.lenght > 100) {
        passwordStatus.innerText = "Max length 100";
        result = false;
    }
    else {
        passwordStatus.innerText = "";
    }

    return result;
}



function VerifyUsername() {

    var txtUsername     = document.getElementById("txtUsername").value;
    var usernameStatus  = document.getElementById("usernameStatus");


    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/WizballWS.asmx/GetAllUsers",
        dataType: "json",
        success: function (data) {
            alert("su");
        },
        error: function (data, status, error) {
            alert("fu");
        }
    });


}

