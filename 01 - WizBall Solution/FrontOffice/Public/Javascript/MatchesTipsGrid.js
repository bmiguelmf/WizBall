// Window resize.
window.addEventListener("resize", setMatchesTipsGridHeight);

//var scrollableHeigth = getScrollableVisibleHeight();


function setMatchesTipsGridHeight() {

    // windows height.
    var winHeight = window.innerHeight;

    // Navigation height.
    var navHeight = $("#app-header").height();

    // Navigation height.
    var compFilters = parseInt($("#filters").outerHeight());

    // Free height.
    var freeHeight = winHeight - navHeight - compFilters -30 -100;


    while (freeHeight % 30 !== 0) {
        freeHeight--;
    }


    scrollableHeigth = getScrollableVisibleHeight();

    if (window.innerWidth >= 960) {

        if (scrollableHeigth < freeHeight) {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + scrollableHeigth + "px;");
        }
        else {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + freeHeight + "px;");
        }
    }
}

function getScrollableVisibleHeight() {

    var rowsCounter = 0;
    var rows = document.getElementById("grid-body").childNodes;

    for (var i = 0; i < rows.length; i++) {
        if (rows[i].style.display !== "none") {
            rowsCounter++;
        }
    }

    return rowsCounter * 30;
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

        showFilterAll();
        setMatchesTipsGridHeight();
    }
    else if (e.target && (e.target.id === "show-none-outter" || e.target.id === "show-none")) {

        hideFilterAll();
        setMatchesTipsGridHeight();
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
            showFilter(compId);                                         // Show all rows which belongs to the respective competition id
        }

        setMatchesTipsGridHeight();
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

function showFilterAll() {

    // Grid rows
    var gridRows = document.getElementById("grid-body").childNodes;
    for (var i = 0; i < gridRows.length; i++) {
         gridRows[i].style.display = "flex";
    }


    // Competitions filters
    var filters = document.getElementById("filters").childNodes;
    for (i = 1; i < filters.length; i++) {
        filters[i].classList.remove("unselected");
    }
}
function hideFilterAll() {
    var gridRows = document.getElementById("grid-body").childNodes;

    for (var i = 0; i < gridRows.length; i++) {
        gridRows[i].style.display = "none";
    }

    // Competitions filters
    var filters = document.getElementById("filters").childNodes;
    for (i = 1; i < filters.length; i++) {
        filters[i].classList.add("unselected");
    }
}

