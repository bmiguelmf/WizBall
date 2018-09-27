//global scope

//global html elements
var tbl_users = $('#users_table');
var tbl_users_body = $('#users_table_body');
var pagination = $('#pg_users_table');

//global functions
function clearTable(table) {
    table.empty();
    pagination.empty();
}

function paginateTable(table, limit) {
    table.hpaging({
        "limit": limit
    });
}

//function checkAdminLogin() {
//    if ($.session.get('AdminUsername') === undefined) {
//        window.location.replace("Login.aspx");
//    }
//}

//checkAdminLogin();

//document ready
$(document).ready(function () {
    //html elements
    var session_label_username = $('#username');

    //vars


    //functions
   
    function GetSessionUsernameToNavbar() {
        session_label_username.text($.session.get('AdminUsername'));
    }

    //events
    $(document).keydown(function (e) {
        if (e.keyCode === 27) {
            $('.st-pusher').trigger('click');
        }
    });

    //calls
    GetSessionUsernameToNavbar();
    
    console.log('READY general.js');
});