
//HTML ELEMENTS
var newsletter_title = $('#input_newsletter_title');
var newsletter_body = $('#txt_newsletter_body');

//VARS


//ARRAYS


//FUNCTIONS
//resets all newsletter fields.
function resetFields() {
    newsletter_title.val("");
    newsletter_body.val("");
}

//validates the newsletter.
function validateNewsletter() {
    var validated = true;
    $(".has-error").removeClass("has-error");

    if (newsletter_body.val() === "") {
        newsletter_body.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the body field.");
        validated = false;
    }
    if (newsletter_body.val().length > 254) {
        newsletter_body.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The body must be less than 255 characters.");
        validated = false;
    }

    if (newsletter_title.val() === "") {
        newsletter_title.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the title field.");
        validated = false;
    }
    if (newsletter_title.val().length > 60) {
        newsletter_title.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The title must be less than 60 characters.");
        validated = false;
    }



    if (validated) {
        error.hide();
        error.find('.message').text("");
    } else {
        error.fadeIn();
        $("html, body").animate({ scrollTop: 0 }, "slow");
    }

    return validated;
}

//checks if the newslatter is valid.
function confirmAndSubmit() {
    if (!validateNewsletter()) {
        return;
    }
    swal({
        title: "Are you sure?",
        text: "This newsletter will be sent to all subscribed users.",
        icon: "info",
        buttons: true,
        closeModal: false
    }).then((willDelete) => {
        if (willDelete) {
            sendNewsletter(newsletter_title.val(), newsletter_body.val());
        } else {
            swal({
                title: "Cancelled!",
                text: "",
                icon: "info",
                timer: 1000
            });
        }
    });
}

//send newsletter and alert if it was sent.
function sendNewsletter(title, body) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/SendNewsletter",
        data: "{title: " + JSON.stringify(title) + ", body: " + JSON.stringify(body) + "}",
        dataType: "json",
        success: function (data) {
            if (data.d) {
                swal({
                    title: "Success!",
                    text: "Newsletter successfully sent!",
                    icon: "success",
                    timer: 5000
                }).then((value) => {
                    resetFields();
                });
            } else {
                swal({
                    title: "Error!",
                    text: "Sorry, we are currently unable to fulfill your request!",
                    icon: "warning",
                    timer: 5000
                });
            }
        },
        error: function () {

        }
    });
}

//CALLS


//EVENTS
$('#reset_newsletter').click(function () {
    resetFields();
});

$('#send_newsletter').click(function () {
    confirmAndSubmit();
});


console.log('READY newsletter.js');