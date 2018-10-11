
//HTML ELEMENTS
var data_table = $('#data_table');
var data_table_head = $('#data_table_head');
var data_table_body = $('#data_table_body');

//VARS

//is used to validate whether a synchronization method was successful or not.
var is_sync = false;

//ARRAYS
//contains all areas. The index is the id and the value is the name.
var Areas = [];


//FUNCTIONS
//fills the table head according to the given entity.
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

//converts the date api provides for the date of portugal.
function formatDateToPT(date) {

    var day_month = date.slice(0, 5);
    var hour = date.slice(11, 13);
    hour = parseInt(hour);
    hour++;
    var min = date.slice(14, 16);

    return day_month + " - " + hour + "h" + min;
}

//fills the table body according to the given entity.
function fillDataTableBody(entity, value) {
    if (entity.toLowerCase() === "matches") {
        data_table_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width:18%\">" + value.Competition.Name + "</td> <td style=\"width:18%\">" + value.HomeTeam.Name + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + value.HomeTeam.Area.Name.toLowerCase() + "/" + value.HomeTeam.Flag + "\" /></span></td> <td style=\"width:8%\" class=\"no-users\">VS</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + value.AwayTeam.Area.Name.toLowerCase() + "/" + value.AwayTeam.Flag + "\" /></span></td> <td style=\"width:18%\">" + value.AwayTeam.Name + "</td> <td style=\"width:18%\">" + formatDateToPT(value.UtcDate) + "</td> </tr>");
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
            $.each(data.d, function (index, value) {
                Areas[value.Id] = value.Name;
            });
            //console.log(Areas);
        },
        error: function (data, status, error) {
            console.log("Error 500 getting areas");
        }
    });
}

//synchronizes the matches that exist in the API with those that exist in the database and updates all that data.
function MatchesSync() {
    console.log("matches sync!");
    is_sync = true;
    //$.ajax({
    //    type: "POST",
    //    contentType: "application/json; charset=utf-8",
    //    url: "../WebService.asmx/SyncMatchesTierOne",
    //    data: "",
    //    dataType: "json",
    //    success: function (data) {
    //        is_sync = false;
    //        if (data.d === true) {
    //            is_sync = true;
    //        }
    //        else {
    //            is_sync = false;
    //        }
    //    },
    //    error: function (data, status, error) {
    //        is_sync = false;
    //    }
    //});
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
            if (data.d === true) {
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
            if (data.d === true) {
                is_sync = true;
            }
            else {
                is_sync = false;
            }
        },
        error: function () {
            is_sync = false;
        }
    });
}

//alert, and if the action is confirmed, performs a synchronization method depending on the given entity.
function alertAndSyncEntity(entity) {

    swal({
        title: "Are you sure?",
        text: "This may take a few seconds.",
        icon: "warning",
        buttons: true
    }).then((willDelete) => {
        if (willDelete) {
            switch (entity.toLowerCase()) {
                case "teams":
                    is_sync = false;
                    TeamsSync();
                    break;
                case "matches":
                    is_sync = false;
                    MatchesSync();
                    break;
            }

            entity.toLowerCase().replace(/\b[a-z]/g).toUpperCase();

            swal({
                title: "Synchronizing " + entity.toLowerCase() + ".",
                text: "Please wait a few seconds...",
                icon: "info",
                timer: 2000, //10000
                buttons: false,
                closeOnEsc: false,
                closeOnClickOutside: false
            }).then((value) => {
                if (is_sync) {
                    swal({
                        title: "Success!",
                        text: "Data synchronized successfully.",
                        icon: "success",
                        timer: 5000
                    }).then((value) => {
                        switch (entity.toLowerCase()) {
                            case "teams":
                                GetTeams();
                                break;
                            case "matches":
                                GetMatches();
                                console.log("get matches!");
                                break;
                            default:
                                GetMatches();
                                console.log("get matches default!");
                        }
                    });
                } else {
                    swal({
                        title: "Info!",
                        text: "Could not sync " + entity.toLowerCase() + "...",
                        icon: "info",
                        timer: 5000
                    });
                }
            });
        } else {
            swal({
                title: "Cancelled!",
                text: "",
                icon: "info",
                timer: 3000
            });
        }
    });
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
            clearTable(data_table_body);
            if ($.fn.DataTable.isDataTable('#data_table')) {
                $('#data_table').DataTable().destroy();
            }

            if (data.d.length > 0) {
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
                                alertAndSyncEntity("data");
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

//gets all the matches from the database. if there are no matches will be presented an alert to perform 
//a full sync. if the admin does not perform this action, he will be redirected to the user requests management
//page if there are requests, otherwise it will be redirected to the users management page.
function GetMatches() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetNextMatchesByTierOneCompetitions",
        dataType: "json",
        success: function (data) {
            //check if GetNextMatchesByTierOneCompetitions returns more than zero matches
            clearTable(data_table_body);
            if ($.fn.DataTable.isDataTable('#data_table')) {
                $('#data_table').DataTable().destroy();
            }

            if (data.d.length > 0) {
                fillContentTableHead("matches");
                clearTable(data_table_body);
                $.each(data.d, function (index, value) {
                    fillDataTableBody("matches", value);
                });
                paginateTable(data_table, 5);
            }
            //check if database has at least one matches 
            else if (has_matches) {
                data_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> There are no games for the next few days. <td></td><td></td><td></td></td></tr>");
                swal({
                    title: "Info!",
                    text: "There are no games for the next few days.",
                    icon: "info",
                    timer: 5000
                });
            } else {
                //if GetNextMatchesByTierOneCompetitions returns zero and data base doenst have matches
                swal({
                    title: "There are no matches at the moment",
                    text: "Please run full sync.",
                    icon: "info",
                    buttons: {
                        sync: {
                            text: "Sync now!",
                            value: "sync"
                        }
                    },
                }).then((value) => {
                    switch (value) {
                        case "sync":
                            FullDatabaseSync();
                            swal({
                                title: "Synchronizing data.",
                                text: "Please wait a few seconds...",
                                icon: "info",
                                timer: 150000,
                                buttons: false,
                                closeOnEsc: false,
                                closeOnClickOutside: false
                            }).then((value) => {
                                if (is_sync === true) {
                                    swal({
                                        title: "Success!",
                                        text: "Data synchronized successfully.",
                                        icon: "success",
                                        timer: 5000
                                    }).then((value) => {
                                        GetMatches();
                                    });
                                } else {
                                    swal({
                                        title: "Info!",
                                        text: "Could not sync data...",
                                        icon: "info",
                                        timer: 5000
                                    });
                                    clearTable(data_table_body);
                                    data_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No " + entity.toLowerCase() + " to display! <td></td><td></td><td></td></td></tr>");
                                }
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
            }
        },
        error: function (data, status, error) {
            console.log(data);
            swal({
                title: "Error!",
                text: " " + (error.message === undefined ? "Sorry, we are currently unable to fulfill your request!" : error.message) + " ",
                icon: "warning",
                timer: 5000
            });
        }
    });
}


function GetTips() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetNextMatchesByTierOneCompetitions",
        dataType: "json",
        success: function (data) {
            //check if GetNextMatchesByTierOneCompetitions returns more than zero matches
            clearTable(data_table_body);
            if ($.fn.DataTable.isDataTable('#data_table')) {
                $('#data_table').DataTable().destroy();
            }

            if (data.d.length > 0) {
                fillContentTableHead("matches");
                clearTable(data_table_body);
                $.each(data.d, function (index, value) {
                    fillDataTableBody("matches", value);
                });
                paginateTable(data_table, 5);
            }
            //check if database has at least one matches 
            else if (has_matches) {
                data_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> There are no games for the next few days. <td></td><td></td><td></td></td></tr>");
                swal({
                    title: "Info!",
                    text: "There are no games for the next few days.",
                    icon: "info",
                    timer: 5000
                });
            } else {
                //if GetNextMatchesByTierOneCompetitions returns zero and data base doenst have matches
                swal({
                    title: "There are no matches at the moment",
                    text: "Please run full sync.",
                    icon: "info",
                    buttons: {
                        sync: {
                            text: "Sync now!",
                            value: "sync"
                        }
                    },
                }).then((value) => {
                    switch (value) {
                        case "sync":
                            FullDatabaseSync();
                            swal({
                                title: "Synchronizing data.",
                                text: "Please wait a few seconds...",
                                icon: "info",
                                timer: 150000,
                                buttons: false,
                                closeOnEsc: false,
                                closeOnClickOutside: false
                            }).then((value) => {
                                if (is_sync === true) {
                                    swal({
                                        title: "Success!",
                                        text: "Data synchronized successfully.",
                                        icon: "success",
                                        timer: 5000
                                    }).then((value) => {
                                        GetMatches();
                                    });
                                } else {
                                    swal({
                                        title: "Info!",
                                        text: "Could not sync data...",
                                        icon: "info",
                                        timer: 5000
                                    });
                                    clearTable(data_table_body);
                                    data_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No " + entity.toLowerCase() + " to display! <td></td><td></td><td></td></td></tr>");
                                }
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
            }
        },
        error: function (data, status, error) {
            console.log(data);
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
GetMatches();
GetAllAreasToArr();


//EVENTS
$('#show_tips').click(function () {
    GetTips();
});

$('#full_sync').click(function () {
    alertAndSyncEntity("data", true);
});

$('#sync_matches').click(function () {
    alertAndSyncEntity("matches");
});

$('#sync_teams').click(function () {
    alertAndSyncEntity("teams");
});

$('#show_matches').click(function () {
    GetMatches();
});

$('#show_teams').click(function () {
    GetTeams();
});


console.log('READY data-management.js');