
//global scope
//global vars
var user_requests_count = 0;
//global html elements
var tbl_users = $('#users_table');
var tbl_users_body = $('#users_table_body');
var users_table_foot = $('#users_table_foot');
var pagination = $('#pg_users_table');
var checked_user_ids = [];

//global functions
function clearTable(table) {
    table.empty();
    //table_settings.ajax.reload();
}

function uncheckCheckedCheckbox() {
    $('.check-all').prop('checked', false);
}

function GetCheckedUserIdsToArray() {
    checked_user_ids = $('.check-all').filter(":checked").map(function () {
        return $(this).attr('user_id');
    }).get();
    console.log(checked_user_ids);
}

function paginateTable(table, limit) {
    table.dataTable({
        destroy: true,
        "pageLength": limit,
        "bLengthChange": false,
        "bAutoWidth": false,
        "fnDrawCallback": function (oSettings) {
            $('#check-all').on('change', function () {
                GetCheckedUserIdsToArray();
            });
            uncheckCheckedCheckbox();
            $('.check-all').on('change', function () {
                GetCheckedUserIdsToArray();
            });
            if (window.location.href.split("/").pop() === "Users.aspx") {
                loadSideBarEffectsScripts();
                assignBtnEditClickEvent();
            }
            if (window.location.href.split("/").pop() === "UserRequests.aspx") {
                assignActionBtnClickEvents();
            }
        }
    });
}


//document ready
$(document).ready(function () {
    //html elements
    var session_label_username = $('#username');
    var cb_check_all_users = $('#check-all');

    //vars
    var bell = $('#bell');
    var error = $('#error_message');

    //functions
    function GetSessionUsernameToNavbar() {
        session_label_username.text($.session.get('AdminUsername'));
    }

    function notifyUsersRequests(number_user_requests) {
        if (window.location.href.split("/").pop() !== "UserRequests.aspx") {
            if (number_user_requests !== 0) {
                $.notify({
                    message: 'You have ' + number_user_requests + ' pending user requests! Click here to see more details.',
                    url: "UserRequests.aspx"
                }, {
                        type: 'danger',
                        url_target: ""
                    });
                bell.css("color", "#ffd300");
            }

        }
    }

    function GetPendingUsersCount() {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WebService.asmx/GetAllUsers",
            data: "",
            dataType: "json",
            success: function (data) {
                if (data.d.length > 0) {
                    $.each(data.d, function (index, value) {
                        if (value.CurrentUserHistory.AfterState.Description === "Pending") {
                            user_requests_count++;
                        }
                    });
                    notifyUsersRequests(user_requests_count);
                }
            }
        });
    }

    //events
    $(document).keydown(function (e) {
        if (e.keyCode === 27) {
            $('.st-pusher').trigger('click');
        }
    });

    cb_check_all_users.change(function () {
        if (this.checked) {
            $('.check-all').prop('checked', true);

        } else {
            uncheckCheckedCheckbox();

        }
    });
    
    //calls

    GetPendingUsersCount();

    GetSessionUsernameToNavbar();

    console.log('READY general.js');
});