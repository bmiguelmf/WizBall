$(document).ready(function () {
    //html elements
    var session_username = $('#username');
    var tbl_users = $('#users_table');
    var tbl_users_body = $('#users_table_body');
    var pagination = $('#pg_users_table');
    
    //vars

    //functions
    
    function clearTable(table) {
        table.empty();
        pagination.empty();
    };

    function GetSessionUsernameToNavbar() {
        session_username.text($.session.get('Username'));
    };

    function paginateTable(table, limit) {
        table.hpaging({
            "limit": limit
        });
    };

    //events
    GetSessionUsernameToNavbar();

    $(document).keydown(function (e) {
        if (e.keyCode === 27) {
            $('.st-pusher').trigger('click');
        }
    });

    console.log('READY general.js');
});