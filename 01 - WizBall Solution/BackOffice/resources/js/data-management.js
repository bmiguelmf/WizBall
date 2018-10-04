
//html elements
var content_table = $('#content_table');
var content_table_head = $('#content_table_head');
var content_table_body = $('#content_table_body');


//vars

//objects

//functions
function fillContentTableHead(entity) {
    if (entity.toLowerCase() === "matches") {
        content_table_head.append("<tr> <th style=\"width:\" class=\"text-center\"><a class=\"order-by-desc\">Competition<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:\" class=\"text-center\"><a class=\"order-by-desc\">Home team<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:\" class=\"text-center\"></th> <th style=\"width:\" class=\"text-center\"></th> <th style=\"width:\" class=\"text-center\"></th> <th style=\"width:\" class=\"text-center\"><a class=\"order-by-desc\">Away team<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:\" class=\"text-center\"><a class=\"order-by-desc\">Date<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> </tr>");
    } else if (entity.toLowerCase() === "teams") {
        content_table_head.append(/*HTML head para equipas*/);
    } else {
        swal("Error!", "Could not load content table header.", "warning").then((value) => {
            location.reload(true);
        });
    }
}

function gsevgfwe(date) {

    var day = date.slice(7, 10);
    var month = date.slice(4, 7);
    var hour = date.slice(16, 18);
    var min = date.slice(19, 21);

    return day + " " + month + " " + hour + "h" + min;
}

function turnDateIntoLocalDate(utc_date) {
    var convertable_date = new Date(utc_date);
    var local_date = new Date();
    convertable_date.setHours(convertable_date.getHours() + local_date.getTimezoneOffset());
    return convertable_date.toString();
}

function fillContentTableBody(entity, value) {
    if (entity.toLowerCase() === "matches") {
        
        console.log(turnDateIntoLocalDate(value.UtcDate.toString()));
        content_table_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width:\">" + value.Competition.Name + "</td> <td style=\"width:\">" + value.HomeTeam.Name + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + value.HomeTeam.Area.Name.toLowerCase() + "/" + value.HomeTeam.Flag + "\" /></span></td> <th style=\"width:\">VS</th> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + value.AwayTeam.Area.Name.toLowerCase() + "/" + value.AwayTeam.Flag + "\" /></span></td> <td style=\"width:\">" + value.AwayTeam.Name + "</td> <td style=\"width:\"></td> </tr>");
    } else if (entity.toLowerCase() === "teams") {
        content_table_body.append(/*HTML head para equipas*/);
    } else {
        swal("Error!", "Could not load content table body.", "warning").then((value) => {
            location.reload(true);
        });
    }
}

function GetTeams() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllTeams",
        data: "",
        dataType: "json",
        success: function (data) {
            clearTable(content_table_head);
            clearTable(content_table_body);
            if (data.d.length > 0) {
                console.log(data.d);
                fillContentTableHead("teams");
                $.each(data.d, function (index, value) {
                    fillContentTableBody("teams");
                });
            }
            else {
                swal("Info!", "There are no teams at the moment. Please run full sync.", "info");
                content_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No teams to display! <td></td><td></td><td></td></td></tr>");
            }
        },
        error: function (data, status, error) {
            swal("Error!", " " + (error.message === undefined ? "Unknown error" : error.message) + " ", "warning");
        }
    });
}

function FullDatabaseSync() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/FullDatabaseSync",
        data: "",
        dataType: "json",
        success: function (data) {
            if (data.d) {
                return true;
            }
            else {
                return false;
            }
        },
        error: function (data, status, error) {
            return false;
        }
    });
}

function GetMatches() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetNextMatchesByTierOneCompetitions",
        data: "",
        dataType: "json",
        success: function (data) {
            clearTable(content_table_head);
            clearTable(content_table_body);
            if (data.d.length > 0) {
                fillContentTableHead("matches");
                $.each(data.d, function (index, value) {
                    fillContentTableBody("matches", value);
                });
            }
            else {
                swal({
                    title: "There are no matches at the moment",
                    text: "Please run full sync.",
                    icon: "info",
                    buttons: {
                        full_sync: {
                            closeModal: false,
                            text: "Sync now!",
                            value: "full_sync"
                        }
                    },
                    closeModal: false
                })
                    .then((value) => {
                        switch (value) {
                            case "full_sync":
                                FullDatabaseSync();
                                swal({
                                    title: "Synchronizing the data",
                                    text: "Please wait a few seconds...",
                                    icon: "info",
                                    timer: 150000,
                                    buttons: false,
                                    closeOnEsc: false,
                                    closeOnClickOutside: false
                                }).then((value) => {
                                    swal({
                                        title: "Success!",
                                        icon: "success",
                                        timer: 3000
                                    }).then((value) => {
                                        GetMatches();
                                    });

                                });
                                break;

                            default:
                                if (user_requests_count <= 0) {
                                    window.location.href = "Users.aspx";
                                } else {
                                    window.location.href = "UserRequests.aspx";
                                }
                        }
                    });






                content_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No matches to display! <td></td><td></td><td></td></td></tr>");
            }
        },
        error: function (data, status, error) {
            swal("Error!", " " + (error.message === undefined ? "Unknown error" : error.message) + " ", "warning");
        }
    });
}

//calls
GetMatches();

//events
$('.st-pusher').click(function () {
    is_code_changed = false;
});

$(document).keydown(function (e) {
    if (e.keyCode === 27) {
        $('.st-pusher').trigger('click');
    }
});

$('#show_teams').click(function () {
    //GetTeams();
});

console.log('READY users.js');
