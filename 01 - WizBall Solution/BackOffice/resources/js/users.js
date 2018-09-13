$(document).ready(function () {
    //html elements
    var username = $('#username');
    var tbl_users = $('#users_table');
    var tbl_users_body = $('#users_table_body');

    //vars


    //functions
    function alterNavbarUsername() {
        username.text($.session.get('Username'));
    };
    
    function paginateTable(table, limit) {
        table.hpaging({
            "limit": limit
        })
    };

    function loadSideBarEffectsScripts() {
        $.getScript('/resources/js/plugins/classie.js');
        $.getScript('/resources/js/plugins/sidebar-effects.js');
    };

    function paginateTableAndLoadSideBarScripts(table){
        paginateTable(table, 2);
        loadSideBarEffectsScripts();
    };

    function GetUsers() {
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
                        console.log(data.d);
                        tbl_users_body.append("<tr value=\" + value.Id + \"> <td style=\"width: 8 %;\" class=\"text-center\"><input type=\"checkbox\"/></td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/" + value.Picture + "\" /></span></td>  <td style=\"width:17%;\">" + value.Username + "</td> <td style=\"width:29%;\">" + value.Email + "</td> <td style=\"width:13%;\">" + value.CurrentUserHistory.AfterState.Description + "</td>  <td style=\"width:13%;\"> " + (value.Newsletter === true ? "Yes" : "No") + " </td> <td style=\"width:10%;\" class=\"st-trigger-effects\"><a class=\"btn_edit\" data-effect=\"st-effect-1\"><i class=\"glyphicon glyphicon-pencil\"></i></a></td> </tr>");
                    });
                    paginateTableAndLoadSideBarScripts(tbl_users);
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
    alterNavbarUsername();
    GetUsers();


    console.log('READY users.js');
});