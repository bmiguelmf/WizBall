$(document).ready(function () {
    //html elements
    var username = $('#username');
    var tbl_users = $('#users_table');
    var tbl_users_body = $('#users_table_body');

    //vars


    //functions
    function alterUsername() {
        username.text($.session.get('Username'));
    };

    function paginateusersTable(limit) {
        tbl_users.hpaging({
            "limit": limit
        })
    };


    function GetUsers() {
        var user_status = "";
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
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "../WebService.asmx/GetCurrentUserHistoryByUserId",
                            data: "{UserId: " + JSON.stringify(value.Id) + "}",
                            dataType: "json",
                            success: function (status) {
                                var innerStatus = "";
                                console.log(status);
                                if (status != null) {
                                    innerStatus = status.Description;
                                }
                                else {
                                    innerStatus = "Status unavailable";
                                }
                                tbl_users_body.append("<tr value=\" + value.Id + \"> <td style=\"width: 8 %;\" class=\"text-center\"><input type=\"checkbox\"/></td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/" + value.Picture + "\" /></span></td>  <td style=\"width:17%;\">" + value.Username + "</td> <td style=\"width:29%;\">" + value.Email + "</td> <td style=\"width:13%;\">" + innerStatus + "</td>  <td style=\"width:13%;\"> " + (value.Newsletter === true ? "Yes" : "No") + " </td> <td style=\"width:10%;\" class=\"st-trigger-effects\"><a class=\"btn_edit\" data-effect=\"st-effect-1\"><i class=\"glyphicon glyphicon-pencil\"></i></a></td> </tr>");
                            }
                        });

                    });
                    //url: "../WebService.asmx/GetCurrentUserHistoryByUserId",
                    paginateusersTable(2);
                }
                else {
                    tbl_users.append("No users to display!");
                }
            },
            error: function (data, status, error) {
                swal("Erro!", " " + error.message + " ", "warning");
            }
        });
    }


    //events
    alterUsername();
    GetUsers();


    console.log('READY users.js');
});