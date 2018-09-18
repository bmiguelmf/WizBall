$(document).ready(function () {

    setViewMatchesHeightx();

    convertUtcDateToLocalDate();

    window.addEventListener("resize", setViewMatchesHeightx);

});



function convertUtcDateToLocalDate() {

    var cells = document.querySelectorAll('.my-grid-body > .my-grid-row > #cell-utc');

    for (var i = 0; i < cells.length; i++) {


        var mil = parseFloat(cells[i].getAttribute("utc-date"));

        var datex = new Date(mil);

        var month, day, hour, minute;



        month = monthNames[datex.getMonth()];

        day = ("0" + datex.getDate()).slice(-2);

        hour = ("0" + datex.getHours()).slice(-2);

        minute = ("0" + datex.getMinutes()).slice(-2);

        cells[i].innerHTML = day + " " + month + " " + hour + ":" + minute;
    }

}
const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
    "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
];



function setViewMatchesHeightx() {

    // Enforces Wrapper to be the whole viewport height.
    var totalViewPort = $(window).height();
    document.getElementById("grid-wrapper").setAttribute("style", "height:" + totalViewPort + "px;");


    // Header Height
    var headerHeight    = $("#header").height();
    var footerHeight    = $("#footer").height();
    var viewPortHeight  = $(window).height();

   
    var gridMatchesHeader       = $("#my-grid-header").height();
    var gridMatchesCompetitons  = $("#tire-one-comps").height();
    var gridMatchesBody = viewPortHeight - footerHeight - headerHeight - gridMatchesHeader - gridMatchesCompetitons;



    while (gridMatchesBody % 29 !== 0) {
        gridMatchesBody--;
    }


    // Width validations.
    if ($(window).width() < 576 || $(window).height() < 600) {
        document.getElementById("main").style.alignItems = "flex-start";
        document.getElementById("tire-one-comps").style.borderRadius = "0";
        document.getElementById("cont-matches").style.padding = "0";
    }
    else if($(window).width() < 768) {
        gridMatchesBody -= 29;
        document.getElementById("main").style.alignItems = "center";
        document.getElementById("tire-one-comps").style.borderRadius = "7px 7px 0 0";
        document.getElementById("cont-matches").style.padding = "0 20px";
    }
    else {
        gridMatchesBody -= 58;
        document.getElementById("main").style.alignItems = "center";
        document.getElementById("tire-one-comps").style.borderRadius = "7px 7px 0 0";
    }




    // And finally apply the height.
    document.getElementById("scrolableGridMatchesBody").setAttribute("style", "height:" + gridMatchesBody + "px;");

 
}