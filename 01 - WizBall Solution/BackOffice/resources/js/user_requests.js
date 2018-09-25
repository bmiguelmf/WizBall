$(document).ready(function () {
    //html elements
    var session_username = $('#username');
    var tbl_users = $('#users_table');
    var tbl_users_body = $('#users_table_body');
    //var btn_submit = $('#btn_submit');

    //vars

    //functions
    function GetSessionUsernameToNavbar() {
        session_username.text($.session.get('Username').toUpperCase());
    };

    function paginateTable(table, limit) {
        table.hpaging({
            "limit": limit
        })
    };

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

        Admin['Id'] = ($.session.get('AdminId') == "" ? 1 : $.session.get('AdminId'));

        User['Id'] = id;

        UserHistory['Admin'] = Admin;
        UserHistory['User'] = User;

        BeforeUserState['Id'] = parseInt($('#user_state').attr('user_state'));
        UserHistory['BeforeState'] = BeforeUserState;

        AfterUserState['Id'] = (is_granted ? 21 : 11);
        UserHistory['AfterState'] = AfterUserState;

        UserHistory['Description'] = permission + " by " + $.session.get('Username');

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
                        GetPendingUsers();
                        paginateTable(tbl_users, 2);
                    });
                } else {
                    swal("Info!", "User unsuccessfully " + permission.toLowerCase() + "!", "warning").then((value) => {
                        
                    });
                }


            },
            error: function (data, status, error) {
                swal("Error!", " " + (error.message == "undefined" ? "Unknown error" : error.message) + " ", "warning");
            }
        });
    };

    function assignActionBtnClickEvents() {

        $('.btn_grant').on("click", function () {
            aproveUser($(this).closest("tr").attr('value'), true);
        });

        $('.btn_revoke').on("click", function () {
            aproveUser($(this).closest("tr").attr('value'), false);
        });
    };

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
                            tbl_users_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width: 8 %;\" class=\"text-center\"><input type=\"checkbox\"/></td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/" + value.Picture + "\" /></span></td>  <td style=\"width:17%;\">" + value.Username + "</td> <td style=\"width:29%;\">" + value.Email + "</td> <td id=\"user_state\" user_state=\"" + value.CurrentUserHistory.AfterState.Id + "\" style=\"width:13%;\">" + value.CurrentUserHistory.AfterState.Description + "</td> <td style=\"width:10%;\"><a class=\"btn_grant\"><i class=\"glyphicon glyphicon-ok\"></i></a></td> <td><a class=\"btn_revoke\"><i class=\"glyphicon glyphicon-trash\"></i></a></td></tr>");
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

    //events
    GetSessionUsernameToNavbar();

    GetPendingUsers();



    console.log('READY user_requests.js');
});