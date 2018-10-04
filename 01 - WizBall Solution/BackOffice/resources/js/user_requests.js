
//html elements
var btn_grant_all_users = $('#grant_all_users');
var btn_revoke_all_users = $('#revoke_all_users');

//vars
var pending_users_ids = [];
//functions
function removeActionButtons() {
    btn_grant_all_users.remove();
    btn_revoke_all_users.remove();
}

function aproveUser(id, is_granted) {
    var permission = "Revoked";

    if (is_granted) {
        permission = "Granted";
    }

    var User = {};
    var UserHistory = {};
    var BeforeUserState = {};
    var AfterUserState = {};
    var Admin = {};

    Admin['Id'] = $.session.get('AdminId') === "" ? 1 : $.session.get('AdminId');

    User['Id'] = id;

    UserHistory['Admin'] = Admin;
    UserHistory['User'] = User;

    BeforeUserState['Id'] = parseInt($('#user_state').attr('user_state'));
    UserHistory['BeforeState'] = BeforeUserState;

    AfterUserState['Id'] = is_granted ? 21 : 11;
    UserHistory['AfterState'] = AfterUserState;

    UserHistory['Description'] = permission + " by " + $.session.get('AdminUsername');

    console.log(UserHistory);

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/InsertUserHistory",
        data: "{UserHistory:" + JSON.stringify(UserHistory) + "}",
        dataType: "json",
        success: function (data) {
            console.log(data.d);
            if (data.d) {
                swal("Success!", "User successfully " + permission.toLowerCase() + "!", "success").then((value) => {
                    //GetPendingUsers();
                    window.location.reload();
                });
            } else {
                swal("Info!", "User unsuccessfully " + permission.toLowerCase() + "!", "warning").then((value) => {

                });
            }


        },
        error: function (data, status, error) {
            swal("Error!", " " + (error.message === undefined ? "Unknown error" : error.message) + " ", "warning");
        }
    });
}

function assignActionBtnClickEvents() {

    $('.btn_grant').on("click", function () {
        swal({
            title: "Are you sure?",
            text: "If necessary, you can change this later.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    aproveUser($(this).closest("tr").attr('value'), true);
                } else {
                    swal("Canceled!", "", "info");
                }
            });

    });

    $('.btn_revoke').on("click", function () {
        swal({
            title: "Are you sure?",
            text: "If necessary, you can change this later.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    aproveUser($(this).closest("tr").attr('value'), false);
                } else {
                    swal("Canceled!", "", "info");
                }
            });
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
                let ran_if = false;
                let i = 0;
                $.each(data.d, function (index, value) {
                    if (value.CurrentUserHistory.AfterState.Description === "Pending") {
                        ran_if = true;
                        pending_users_ids[i] = value.Id;
                        tbl_users_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width: 8%;\" class=\"text-center\"><input user_id=\"" + value.Id + "\" class=\"check-all checkbox-change\" type=\"checkbox\"/></td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/Users/" + value.Picture + "\" /></span></td>  <td style=\"width:17%;\">" + value.Username + "</td> <td style=\"width:29%;\">" + value.Email + "</td> <td id=\"user_state\" user_state=\"" + value.CurrentUserHistory.AfterState.Id + "\" style=\"width:16%;\">" + value.CurrentUserHistory.AfterState.Description + "</td> <td style=\"width:10%;\"><a class=\"btn_grant\"><i class=\"glyphicon glyphicon-ok\"></i></a></td> <td style=\"width:10%;\"><a class=\"btn_revoke\"><i class=\"glyphicon glyphicon-trash\"></i></a></td></tr>");
                    }
                    i++;
                });
                if (ran_if === true) {
                    paginateTable(tbl_users, 3);
                    assignActionBtnClickEvents();
                } else {
                    swal("Info!", "There are no user requests at the moment.", "info");
                    removeActionButtons();
                    tbl_users.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No users to display! <td></td><td></td><td></td></td></tr>");
                }
            }
            else {
                swal("Info!", "There are no user requests at the moment.", "info");
                removeActionButtons();
                tbl_users.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No users to display! <td></td><td></td><td></td></td></tr>");
            }
        },
        error: function (data, status, error) {
            swal("Error!", " " + (error.message === undefined ? "Unknown error" : error.message) + " ", "warning");
        }
    });
}

function aproveAllUsers(ids, is_granted) {
    var permission = "Revoked";

    if (is_granted) {
        permission = "Granted";
    }

    for (i = 0; i < ids.length; i++) {
        aproveUser(ids[i], is_granted);
    }

    swal("Success!", "Users successfully " + permission.toLowerCase() + "!", "success").then((value) => {
        //GetPendingUsers();
        window.location.reload();
    });

}

//calls
GetPendingUsers();

//events
btn_grant_all_users.click(function () {
    if (checked_user_ids > 0) {
        // any user is checked
        swal({
            title: "Are you sure?",
            text: "This action will grant selected users.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    for (var i = 0; i < checked_user_ids.length; i++) {
                        aproveUser(checked_user_ids[i], true);
                    }
                } else {
                    swal("Canceled!", "", "info");
                }
            });
    }
    else {
        swal({
            title: "Are you sure?",
            text: "This action will grant all users.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    aproveAllUsers(pending_users_ids, true);
                } else {
                    swal("Canceled!", "", "info");
                }
            });
    }
});

btn_revoke_all_users.click(function () {
    if (checked_user_ids > 0) {
        // any user is checked
        swal({
            title: "Are you sure?",
            text: "This action will revoke selected users.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    for (var i = 0; i < checked_user_ids.length; i++) {
                        aproveUser(checked_user_ids[i], false);
                    }
                } else {
                    swal("Canceled!", "", "info");
                }
            });
    }
    else {
        swal({
            title: "Are you sure?",
            text: "This action will revoke all users.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    aproveAllUsers(pending_users_ids, false);
                } else {
                    swal("Canceled!", "", "info");
                }
            });
    }
});

console.log('READY user_requests.js');
