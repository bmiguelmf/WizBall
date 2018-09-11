$(document).ready(function () {
    //html elements
    var username = $('#username');
    var tbl_users = $('#users_table');

    //vars


    //functions
    function alterUsername() {
        username.text($.session.get('Username'));
    };

    function GetUsers() {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WebService.asmx/GetAllUsers",
            data: "",
            dataType: "json",
            success: function (data) {
                tbl_users.empty();
                if (data.d.length === 0) {
                    tbl_users.append("<thead><tr> <td>Username</td> <td>E-mail</td> <td>Status</td> <td>Newsletter</td> <td colspan='2'>Actions</td> </tr> </thead> <tbody>");
                    console.log(data.d);
                    //$.each(data.d, function (index, value) {
                        //tbl_users.append("<tr value='" + value.ID + "'> <td>" + value.Title  + "</td><td>" + value.Genre.Name + "</td><td>" + value.Rating + "</td><td> <button type='button' class='edit-movie btn btn-success' value='" + value.ID + "'>Editar</button> </td><td><button type='button' class='delete-movie btn btn-danger' value='" + value.ID + "'>Eliminar</button> </td> </tr>");
                    //});
                    //tbl_users.append('</tbody>');
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