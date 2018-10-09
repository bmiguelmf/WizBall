﻿
//HTML ELEMENTS
var data_table = $('#data_table');
var data_table_head = $('#data_table_head');
var data_table_body = $('#data_table_body');

//VARS
//save the value if there are matches in the database or not.
var has_matches = undefined;

//is used to validate whether a synchronization method was successful or not.
var is_sync = false;

//ARRAYS
//is an array with all areas. The index is the id and the value is the name.
var Areas = [];



//FUNCTIONS
//fills the table head according to the given entity
function fillContentTableHead(entity) {
    clearTable(data_table_head);
    if (entity.toLowerCase() === "matches") {
        data_table_head.append("<tr> <th style=\"width:18%\" class=\"text-center\"><a class=\"order-by-desc\">Competition<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:18%\" class=\"text-center\"><a class=\"order-by-desc\">Home team<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:10%\" class=\"text-center\"></th> <th style=\"width:8%\" class=\"text-center\"></th> <th style=\"width:10%\" class=\"text-center\"></th> <th style=\"width:18%\" class=\"text-center\"><a class=\"order-by-desc\">Away team<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:18%\" class=\"text-center\"><a class=\"order-by-desc\">Date<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> </tr>");
    } else if (entity.toLowerCase() === "teams") {
        data_table_head.append("<tr> <th style=\"width:10%\" class=\"text-center\"><a class=\"order-by-desc\">TLA<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:10%\" class=\"text-center\">Logo</th> <th style=\"width:20%\" class=\"text-center\"><a class=\"order-by-desc\">Short name<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:20%\" class=\"text-center\"><a class=\"order-by-desc\">Full name<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:20%\" class=\"text-center\"><a class=\"order-by-desc\">Region<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th>  <th style=\"width:20%\" class=\"text-center\"><a class=\"order-by-desc\">Website<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> </tr>");
    } else {
        swal({
            title: "Error!",
            text: "Could not load content table header.",
            icon: "warning",
            timer: 5000
        }).then((value) => {
            location.reload(true);
        });
    }
}

//
function formatDateWithStyle(date) {

    //var day = date.slice(7, 10);
    //var month = date.slice(4, 7);
    //var hour = date.slice(16, 18);
    //var min = date.slice(19, 21);

    //return day + " " + month + " " + hour + "h" + min;
}

function turnDateIntoLocalDate(utc_date) {
    var convertable_date = new Date(utc_date);
    var local_date = new Date();
    convertable_date.setHours(convertable_date.getHours() + local_date.getTimezoneOffset());
    return convertable_date.toString();
}

//fills the table body according to the given entity.
function fillDataTableBody(entity, value) {
    if (entity.toLowerCase() === "matches") {
        data_table_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width:18%\">" + value.Competition.Name + "</td> <td style=\"width:18%\">" + value.HomeTeam.Name + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + value.HomeTeam.Area.Name.toLowerCase() + "/" + value.HomeTeam.Flag + "\" /></span></td> <td style=\"width:8%\" class=\"no-users\">VS</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + value.AwayTeam.Area.Name.toLowerCase() + "/" + value.AwayTeam.Flag + "\" /></span></td> <td style=\"width:18%\">" + value.AwayTeam.Name + "</td> <td style=\"width:18%\">BRUH</td> </tr>");
    } else if (entity.toLowerCase() === "teams") {
        data_table_body.append("<tr value=\"" + value.Id + "\">  <td style=\"width:10%\">" + value.TLA + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + Areas[value.Area.Id].toLowerCase() + "/" + value.Flag + "\" /></span></td> <td style=\"width:20%\">" + value.ShortName + "</td> <td style=\"width:20%\">" + value.Name + "</td> <td style=\"width:20%\">" + Areas[value.Area.Id] + "</td> <td style=\"width:20%\"> <a class=\"order-by-desc\" href=\"" + value.WebSite + "\" target=\"_blank\">" + value.WebSite + "&nbsp;<i class=\"glyphicon glyphicon-share-alt\"></i></a></td> </tr>");
    } else {
        swal({
            title: "Error!",
            text: "Could not load content table body.",
            icon: "warning",
            timer: 5000
        }).then((value) => {
            location.reload(true);
        });
    }
}

//gets all the areas vai ajax and places them in an array where the index is the id of the Area and the value is the respective name.
function GetAllAreasToArr() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllAreas",
        data: "",
        dataType: "json",
        success: function (data) {
            console.log(data.d);
            $.each(data.d, function (index, value) {
                Areas[value.Id] = value.Name;
            });
            console.log(Areas);
        },
        error: function (data, status, error) {
            console.log("Error 500 getting areas");
        }
    });
}

//synchronizes the matches that exist in the API with those that exist in the database and updates all that data.
function MatchesSync() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/SyncMatchesTierOne",
        data: "",
        dataType: "json",
        success: function (data) {
            is_sync = false;
            if (data.d) {
                is_sync = true;
            }
            else {
                is_sync = false;
            }
        },
        error: function (data, status, error) {
            is_sync = false;
        }
    });
}

//checks if there are matches data in the database and saves that value in "has_matches" so that the code can
//then decide whether to perform a full sync or if there are no matches for the next few days when "GetMatches()" is performed.
function hasMatches() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/MatchesHasRows",
        data: "",
        dataType: "json",
        success: function (data) {
            has_matches = data.d;
        },
        error: function (data, status, error) {
            console.log("Error 500 getting matches top 1");
        }
    });
}

//synchronizes the teams that exist in the API with those that exist in the database and updates all that data.
function TeamsSync() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/SyncTeams",
        data: "",
        dataType: "json",
        success: function (data) {
            is_sync = false;
            if (data.d) {
                is_sync = true;
            }
            else {
                is_sync = false;
            }
        },
        error: function (data, status, error) {
            is_sync = false;
        }
    });
}

//
function loadingSync(entity) {
    swal({
        title: "Synchronizing " + entity.toLowerCase() + ".",
        text: "Please wait a few seconds...",
        icon: "info",
        timer: entity.toLowerCase() === "data" ? 150000 : 10000,
        buttons: false,
        closeOnEsc: false,
        closeOnClickOutside: false
    }).then((value) => {
        if (is_sync) {
            swal({
                title: "Success!",
                text: entity + " synchronized successfully.",
                icon: "success",
                timer: 5000
            }).then((value) => {
                switch (entity.toLowerCase()) {
                    case "teams":
                        GetTeams();
                        break;
                    case "matches":
                        GetMatches();
                        break;
                    case "data":
                        GetMatches();
                        break;
                    default:
                        GetMatches();
                }
            });
        } else {
            swal({
                title: "Info!",
                text: "There are no " + entity.toLowerCase() + ".",
                icon: "info",
                timer: 5000
            });
            clearTable(data_table_body);
            data_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No " + entity.toLowerCase() + " to display! <td></td><td></td><td></td></td></tr>");
        }
    });
}

//alert, and if the action is confirmed, performs a synchronization method depending on the given entity.
function alertAndSyncEntity(entity, show_alert) {
    if (show_alert) {
        swal({
            title: "Are you sure?",
            text: "This may take a few seconds.",
            icon: "warning",
            buttons: true
        }).then((willDelete) => {
            if (willDelete) {

                switch (entity.toLowerCase()) {
                    case "teams":
                        TeamsSync();
                        break;
                    case "matches":
                        MatchesSync();
                        break;
                    case "full":
                        FullDatabaseSync();
                        entity = "data";
                        break;
                    default:
                        FullDatabaseSync();
                        entity = "data";
                }

                entity = entity.toLowerCase().replace(/\b[a-z]/g, function (first_char) {
                    return first_char.toUpperCase();
                });
                loadingSync(entity);
            } else {
                swal({
                    title: "Canceled!",
                    text: "",
                    icon: "info",
                    timer: 3000
                });
            }
        });
    } else {
        loadingSync(entity);
    }


}

//gets all the teams from the database. if there are no teams will be presented an alert to perform 
//a full sync. if the admin does not perform this action, he will be redirected to the user requests management
//page if there are requests, otherwise it will be redirected to the users management page.
function GetTeams() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllTeams",
        data: "",
        dataType: "json",
        success: function (data) {
            if (data.d.length > 0) {
                console.log(data.d);
                fillContentTableHead("teams");
                clearTable(data_table_body);
                $.each(data.d, function (index, value) {
                    fillDataTableBody("teams", value);
                });
                paginateTable(data_table, 3);
            }
            else {
                swal({
                    title: "There are no teams at the moment",
                    text: "Please run full sync.",
                    icon: "info",
                    buttons: {
                        full_sync: {
                            closeModal: false,
                            text: "Sync now!",
                            value: "sync"
                        }
                    },
                    closeModal: false
                })
                    .then((value) => {
                        switch (value) {
                            case "sync":
                                alertAndSyncEntity("data", false);
                                break;
                            default:
                                if (user_requests_count <= 0) {
                                    window.location.href = "Users.aspx";
                                } else {
                                    window.location.href = "UserRequests.aspx";
                                }
                        }
                    });
            }
        },
        error: function (data, status, error) {
            swal({
                title: "Error!",
                text: " " + (error.message === undefined ? "Sorry, we are currently unable to fulfill your request!" : error.message) + " ",
                icon: "warning",
                timer: 5000
            });
        }
    });
}

//synchronizes all the data that exist in the API with those that exist in the database and updates all that.
function FullDatabaseSync() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/FullDatabaseSync",
        data: "",
        dataType: "json",
        success: function (data) {
            is_sync = false;
            if (data.d) {
                is_sync = true;
            }
            else {
                is_sync = false;
            }
        },
        error: function (data, status, error) {
            is_sync = false;
        }
    });
}

//gets all the matches from the database. if there are no matches will be presented an alert to perform 
//a full sync. if the admin does not perform this action, he will be redirected to the user requests management
//page if there are requests, otherwise it will be redirected to the users management page.
function GetMatches() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetNextMatchesByTierOneCompetitions",
        data: "",
        dataType: "json",
        success: function (data) {
            console.log(data.d);
            if (data.d.length > 0) {
                fillContentTableHead("matches");
                clearTable(data_table_body);
                $.each(data.d, function (index, value) {
                    fillDataTableBody("matches", value);
                });
                paginateTable(data_table, 5);
            }
            else if (has_matches) {
                data_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> There are no games for the next few days. <td></td><td></td><td></td></td></tr>");
                swal({
                    title: "Info!",
                    text: "There are no games for the next few days.",
                    icon: "info",
                    timer: 5000
                });
            } else {
                swal({
                    title: "There are no matches at the moment",
                    text: "Please run full sync.",
                    icon: "info",
                    buttons: {
                        full_sync: {
                            closeModal: false,
                            text: "Sync now!",
                            value: "sync"
                        }
                    },
                    closeModal: false
                })
                    .then((value) => {
                        switch (value) {
                            case "sync":
                                alertAndSyncEntity("data", false);
                                break;
                            default:
                                if (user_requests_count <= 0) {
                                    window.location.href = "Users.aspx";
                                } else {
                                    window.location.href = "UserRequests.aspx";
                                }
                        }
                    });
            }
        },
        error: function (data, status, error) {
            swal({
                title: "Error!",
                text: " " + (error.message === undefined ? "Sorry, we are currently unable to fulfill your request!" : error.message) + " ",
                icon: "warning",
                timer: 5000
            });
        }
    });
}


//CALLS
hasMatches();
GetMatches();
GetAllAreasToArr();


//EVENTS
$('#show_tips').click(function () {
    //GetTips();
});

$('#full_sync').click(function () {
    alertAndSyncEntity("data", true);
});

$('#sync_matches').click(function () {
    alertAndSyncEntity("matches", true);
});

$('#sync_teams').click(function () {
    alertAndSyncEntity("teams", true);
});

$('#show_matches').click(function () {
    GetMatches();
});

$('#show_teams').click(function () {
    GetTeams();
});


console.log('READY users.js');