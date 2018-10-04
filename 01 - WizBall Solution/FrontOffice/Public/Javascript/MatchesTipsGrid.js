// Window resize.
window.addEventListener("resize", setMatchesTipsGridHeight);

var scrollableHeigth = $("#grid-body-scrollable").height();


function setMatchesTipsGridHeight() {

    // windows height.
    var winHeight = window.innerHeight;

    // Navigation height.
    var navHeight = $("#app-header").height();

    // Navigation height.
    var compFilters = $("#filters").outerHeight();

    // Free height.
    var freeHeight = winHeight - navHeight - compFilters -30 -100;


    while (freeHeight % 30 !== 0) {
        freeHeight--;
    }

    if (window.innerWidth >= 960) {
        if (scrollableHeigth < freeHeight) {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + scrollableHeigth + "px;");
            var fds = (freeHeight - scrollableHeigth - 30) / 2;
            document.getElementById("grid").setAttribute("style", "margin-top:" + fds + "px;");
        }
        else {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + freeHeight + "px;");
        }
    }
    
    else {
        document.getElementById("grid").setAttribute("style", "margin-top:auto;");
        document.getElementById("grid-body-scrollable").setAttribute("style", "height: auto");
    }

}



const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
    "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
];
function convertUtcDateToLocalDate() {

    var cells = document.querySelectorAll('.grid-body > .grid-row > #utc-date');

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



// Exec one time functions.
setMatchesTipsGridHeight();
convertUtcDateToLocalDate();





//**********************************************************************
// Competitions filters
//**********************************************************************
document.getElementById("filters").addEventListener("click", function (e) {

    if (e.target && (e.target.id === "show-all-outter" || e.target.id === "show-all")) {

        alert("All");
     
    }
    else if (e.target && (e.target.id === "show-none-outter" || e.target.id === "show-none")) {

        alert("none");

    }
    else if (e.target && e.target.nodeName === "DIV") {

        var div = document.getElementById(e.target.id);

        if (div.classList.contains("competition")) {

            div.classList.toggle("unselected");

            filterByCompetitions();
        }
     
    }   
    else if (e.target && e.target.nodeName === "IMG") {

        document.getElementById(e.target.id).parentElement.classList.toggle("unselected");

        filterByCompetitions();
    }

});

function filterByCompetitions() {

    var children = document.getElementById("filters").childNodes;       // Gets div where imgs are.                          

    for (var i = 0; i < children.length; i++) {                         // For each div lets check if it has the unselected class.

        compId = children[i].getAttribute("id");                        // Gets the competition id which will be needed either way.

        if (children[i].classList.contains("unselected")) {        
            hideFilter(compId);                                         // Hides all rows which belongs to the respective competition id
        }
        else {
            showFilter(compId);                                        // Show all rows which belongs to the respective competition id
        }
    }
}

function showFilter(competitionId) {

    var gridRows = document.getElementById("grid-body").childNodes;

    for (var i = 0; i < gridRows.length; i++) {

        if (gridRows[i].getAttribute("compid") === competitionId) {
            gridRows[i].style.display = "flex";
        }
    }
}
function hideFilter(competitionId) {

    var gridRows = document.getElementById("grid-body").childNodes;

    for (var i = 0; i < gridRows.length; i++) {

        if (gridRows[i].getAttribute("compid") === competitionId) {
            gridRows[i].style.display = "none";
        }
    }
}
