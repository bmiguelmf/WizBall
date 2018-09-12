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

    tbl_users.hpaging({
        "limit": 2
    });


    function GetUsers() {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WebService.asmx/GetAllUsers",
            data: "",
            dataType: "json",
            success: function (data) {
                //tbl_users_body.empty();
                if (data.d.length === 0) {
                    console.log("Data d é zero");
                    //$.each(data.d, function (index, value) {
                    //tbl_users.append("<tr value='" + value.ID + "'> <td>" + value.Title  + "</td><td>" + value.Genre.Name + "</td><td>" + value.Rating + "</td><td> <button type='button' class='edit-movie btn btn-success' value='" + value.ID + "'>Editar</button> </td><td><button type='button' class='delete-movie btn btn-danger' value='" + value.ID + "'>Eliminar</button> </td> </tr>");
                    //});
                    //tbl_users.append('</tbody>');
                }
                else {
                    console.log("Data d não é zero")
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