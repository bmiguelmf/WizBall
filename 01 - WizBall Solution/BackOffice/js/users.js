$(document).ready(function () {
    //alert($.session.get('Username'));
    //html elements
    var username = $('#username');

    //vars
    

    //functions
    function alterUsername() {
        username.text($.session.get('Username'));
    };


    //events
    alterUsername();



    console.log('READY users.js');
});