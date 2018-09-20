$(document).ready(function () {
    //html elements
    var session_username = $('#username');
    var tbl_users = $('#users_table');
    var tbl_users_body = $('#users_table_body');
    //var btn_submit = $('#btn_submit');
    
    //vars
   
    //functions
    function GetSessionUsernameToNavbar() {
        session_username.text($.session.get('Username'));
    };

    function paginateTable(table, limit) {
        table.hpaging({
            "limit": limit
        })
    };

    function assignActionBtnClickEvents() {
        $('.btn_grant').on("click", function () {
            GetClickedUserToForm($(this).closest("tr").attr('value'));
        });

        $('.btn_revoke').on("click", function () {
            GetClickedUserToForm($(this).closest("tr").attr('value'));
        });
    }

    function GetPendingUsers() {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WebService.asmx/GetAllUsers",
            data: "",
            dataType: "json",
            success: function (data) {
                tbl_users_body.empty();
                if (data.d.length > 0) {
                    $.each(data.d, function (index, value) {
                        if (value.CurrentUserHistory.AfterState.Description == "Pending") {
                            tbl_users_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width: 8 %;\" class=\"text-center\"><input type=\"checkbox\"/></td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/" + value.Picture + "\" /></span></td>  <td style=\"width:17%;\">" + value.Username + "</td> <td style=\"width:29%;\">" + value.Email + "</td> <td style=\"width:13%;\">" + value.CurrentUserHistory.AfterState.Description + "</td> <td style=\"width:10%;\"><a class=\"btn_grant\"><i class=\"glyphicon glyphicon-ok\"></i></a></td> <td style=\"width:10%;\"><a class=\"btn_revoke\" data-effect=\"st-effect-1\"><i class=\"glyphicon glyphicon-remove\"></i></a></td></tr>");
                        }
                    });
                    paginateTable(tbl_users, 2);
                    assignActionBtnClickEvents();
                }
                else {
                    tbl_users.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center\"> No users to display! <td></td><td></td><td></td></td></tr>");
                }
            },
            error: function (data, status, error) {
                swal("Erro!", " " + error.message + " ", "warning");
            }
        });
    };

    function GetClickedUserToForm(id) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WebService.asmx/GetUserById",
            data: "{Id: " + JSON.stringify(id) + "}",
            dataType: "json",
            statusCode: {
                404: function (data) {
                    swal("Oops...", "This user no longer exists!", "error").then((value) => {
                        location.reload(true);
                    });
                },
                500: function (data) {
                    swal("Oops...", "Sorry, we are currently unable to fulfill your request!", "error");
                }
            },
            success: function (data) {
                clearForm();
                if (data.d != null) {
                    //user_photo.attr('src', data.d.Picture);
                    input_username.val(data.d.Username);
                    input_email.val(data.d.Email);
                    toggleBothFormToggles(data.d.CurrentUserHistory.AfterState, data.d.Newsletter);
                    disableFormTextArea();
                }
            },
            error: function (data, status, error) {
                swal("Erro!", " " + error.message + " ", "warning");
            }
        });
    };

    function validateForm() {
        var validated = true;
        $(".has-error").removeClass("has-error");

        if (input_username.val() === "") {
            input_username.closest(".form-group").addClass("has-error");
            error.fadeIn();
            error.find('.message').text("Please, fill in the username field.");
            validated = false;
        }

        if (input_email.val() === "") {
            input_email.closest(".form-group").addClass("has-error");
            error.fadeIn();
            error.find('.message').text("Please, fill in the e-mail field.");
            validated = false;
        }

        if (is_text_area_disabled === false) {
            if (txt_description.val() === "") {
                txt_description.closest(".form-group").addClass("has-error");
                error.fadeIn();
                error.find('.message').text("Please, fill in the description field.");
                validated = false;
            }
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

    //events
    GetSessionUsernameToNavbar();

    GetPendingUsers();

    $('.st-pusher').click(function () {
        is_code_changed = false;
    });

    btn_cancel.on("click", function () {
        $('.st-pusher').trigger('click');
    });

    $(document).keydown(function (e) {
        if (e.keyCode === 27) {
            $('.st-pusher').trigger('click');
        }
    });

    toggle_status.on('change', function (ev) {
        ev.preventDefault();
        if (is_code_changed === false) {
            if (is_text_area_disabled === true) {
                enableFormTextArea();
            } else {
                disableFormTextArea();
            }
        } else {
            is_code_changed = false;
        }
    });

    btn_submit.click(function () {
        if (!validateForm()) {
            return;
        }
        var User = {};
        var UserHistory = {};
        var UserState = {};

        User['Username'] = input_username.val();
        User['Email'] = input_email.val();
        User['Newsletter'] = toggle_newsletter.prop('checked');
        User['Picture'] = user_photo.attr('src');

        UserHistory['Admin'] = $.session.get('LoggedAdmin');
        UserHistory['User'] = User;

        UserState['Id'] = toggle_status.attr('status_id');
        UserHistory['BeforeState'] = UserState;

        UserState['Id'] = (toggle_status.prop('checked') ? toggle_status.attr('granted_id') : toggle_status.attr('blocked_id'));
        UserHistory['AftereState'] = UserState;

        UserHistory['Description'] = txt_description.val();


        //$.ajax({
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    url: "../WebService.asmx/",
        //    data: "{Movie: " + JSON.stringify(movie) + ", atores:" + JSON.stringify(atores) + ", diretores:" + JSON.stringify(diretores) + ", produtores:" + JSON.stringify(produtores) + ", estudios:" + JSON.stringify(estudios) + "}",
        //    // JSON.stringify({Movie: movie, atores: atores, diretores: diretores, produtores: produtores, estudios: estudios }),

        //    dataType: "json",
        //    success: function (data) {
        //        swal("Sucesso!", "Filme criado com sucesso!", "success");
        //        //swal("Filme criado com sucesso!");
        //        HidePanels();
        //        ResetFormCreateMovie();
        //        GetMovies();
        //        panelMovies.fadeIn();
        //    },
        //    error: function (data, status, error) {
        //        swal("Erro!", " " + error.message + " ", "warning");
        //    }
        //});

    });

    console.log('READY users.js');
});