// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid resizing                                                                                
// ----------------------------------------------------------------------------------------------------------------
window.addEventListener("resize", setMatchesTipsGridHeight);   // Adds an event listener to the window resize event. This ways we can reset matchesTipsGrid height whenever the user changes window size.

function setMatchesTipsGridHeight() {                                       // Function containing the logic on how the gridMatchesGrid should resize it self to fit the current browser window.                               

    if (window.innerWidth >= 960) {

        currentGridBodyHeight   = getCurrentGridBodyHeight();               // Gets the real current grid body height. 
        availableGridBodyHeight = getAvailableGridBodyHeight();             // Gets the available grid body height. 

        if (currentGridBodyHeight < availableGridBodyHeight) {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + currentGridBodyHeight + "px;");
        }
        else {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + availableGridBodyHeight + "px;");
        }

    }
}
function getCurrentGridBodyHeight() {

    var rowsCounter = 0;                                            
    var rows = document.getElementById("grid-body").childNodes;     // Gets all rows inside matchesTipsGrid.

    for (var i = 0; i < rows.length; i++) {                         // For each one.
        if (rows[i].style.display !== "none") {                     // Check if it is visible.
            rowsCounter++;                                          // And increases rowsCounter
        }
    }

    return rowsCounter * 30;                                        // Finally return the number of visible rows * 30. (Current matchesTipsGrid body height).
}
function getAvailableGridBodyHeight() {

    var windowHeight        = parseInt(window.innerHeight);                 // Gets window height (Total height space available).
    var navbarHeight        = parseInt($("#app-header").height());          // Gets the navbarHeight.
    var competitionsFilters = parseInt($("#filters").outerHeight());        // Gets the competitions filters height.
    var gridHeader          = parseInt($("#grid-header").outerHeight());    // Sets matchesTipsGrid header height.
    var gridPadding         = 100;                                          // Hardcoded padding for matchesTipsGrid.


    var availableGridBodyHeight = windowHeight - navbarHeight - competitionsFilters - gridHeader - gridPadding;     // Total available height for matchesTipsGrid body.


    while (availableGridBodyHeight % 30 !== 0) {                                                                    // This small step will ensure the the gridBodyHeight is divisible by 30.
        availableGridBodyHeight--;                                                                                  // 30px is the size of individual rows. 
    }

    return availableGridBodyHeight;
}




// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid competitions filters                                                                    
// ----------------------------------------------------------------------------------------------------------------
document.getElementById("filters").addEventListener("click", function (e) {                             // Adds event listener to the div containing all the competitions filters options.

    if (e.target && (e.target.id === "show-all-outter" || e.target.id === "show-all")) {                // If user selects show all competitions "btn".

        showAllRows();                                                                                  // Calls showAllRows() which will select all competitions as well showing up all matchesTipsGrid rows.
        setMatchesTipsGridHeight();                                                                     // Finally because the visible number of rows in MatchesTipsGrid may changed we need to reset its height.

        resetRowsColors();
    }
    else if (e.target && (e.target.id === "show-none-outter" || e.target.id === "show-none")) {         // If user selects hide all competitions "btn".

        hideAllRows();                                                                                  // Calls hideAllRows() which will deselect all competitions as well hiding all matchesTipsGrid rows.
        setMatchesTipsGridHeight();                                                                     // Finally because the number of rows in MatchesTipsGrid may changed we need to reset its height.

        resetRowsColors();
    }
    else if (e.target && e.target.nodeName === "DIV") {                                                 // If user selects one of the others child divs inside the parent div Filters.

        var div = document.getElementById(e.target.id);                                                 // Gets the element.                                                  

        if (div.classList.contains("competition")) {                                                    // If the element has the class named "competition" then we know that is a valid div to be evaluated.

            div.classList.toggle("unselected");                                                         // Toggle the class unselected. This will deselect this particular competition in case it is selected,
                                                                                                        // Or select it in case it is deselected.
            filterRowsByCompetitions();                                                                 // Then call filterByCompetition() which will filter the matchesTipsGrid accordingly to the user competition selection/deselection.

            setMatchesTipsGridHeight();                                                                 // Finally because the visible number of rows in MatchesTipsGrid may changed we need to reset its height.

            resetRowsColors();
        }

    }
    else if (e.target && e.target.nodeName === "IMG") {                                                 // If user selects one of the others child imgs inside the parent div Filters.

        document.getElementById(e.target.id).parentElement.classList.toggle("unselected");              // Gets the particular img parent div which is always a competition.
                                                                                                        // Then we can be sure we can toggle the class named "unselected". 
                                                                                                        // This will deselect this particular competition in case it is selected, or select it in case it is deselected.

        filterRowsByCompetitions();                                                                     // Then call filterByCompetition() which will filter the matchesTipsGrid accordingly to the user competition selection/deselection.

        setMatchesTipsGridHeight();                                                                     // Finally because the visible number of rows in MatchesTipsGrid may changed we need to reset its height.

        resetRowsColors();
    }

});

function filterRowsByCompetitions() {

    var children = document.getElementById("filters").childNodes;       // Gets all childrens in filters div (We need all competitions div elements which contains needed info).                          

    for (var i = 1; i < children.length; i++) {                         // For each item except the first one (which is not a competition instead is the div options).

        compId = children[i].getAttribute("id");                        // Gets the attribute Id for the current child item (competition) which will be needed for the next step.

        if (children[i].classList.contains("unselected")) {             // If current child item (competition) has a class named "unselected" then.
            hideRowsByCompetition(compId);                              // Hides all rows which belongs to the respective competition id.
        }
        else {
            showRowsByCompetition(compId);                              // Shows all rows which belongs to the respective competition id.
        }
    }

}
function showRowsByCompetition(competitionId) {

    var gridRows = document.getElementById("grid-body").childNodes;         // Gets all rows in matchesTipsGrid table.

    for (var i = 0; i < gridRows.length; i++) {                             // For each one of the rows.

        if (gridRows[i].getAttribute("compid") === competitionId) {         // Check if the current row has the attribute compId equals to the parameter competitionId.
            gridRows[i].style.display = "flex";                             // And then change its state from display:none to display:flex.
        }
    }

}
function hideRowsByCompetition(competitionId) {

    var gridRows = document.getElementById("grid-body").childNodes;         // Gets all rows in matchesTipsGrid table.

    for (var i = 0; i < gridRows.length; i++) {                             // For each one of the rows.

        if (gridRows[i].getAttribute("compid") === competitionId) {         // Check if the current row has the attribute compId equals to the parameter competitionId.
            gridRows[i].style.display = "none";                             // And then change its state from display:flex to display:none.
        }
    }

}

function showAllRows() {

    var gridRows = document.getElementById("grid-body").childNodes;         // Gets all rows in matchesTipsGrid table.

    for (var i = 0; i < gridRows.length; i++) {                             // For each one of the rows.
        gridRows[i].style.display = "flex";                                 // Change its state to display:flex.
    }


    var filters = document.getElementById("filters").childNodes;            // Gets all childrens in filters div.

    for (i = 1; i < filters.length; i++) {                                  // For each item except the first one (which is not a competition instead is the div options).
        filters[i].classList.remove("unselected");                          // Removes class named unselected.
    }
}
function hideAllRows() {

    var gridRows = document.getElementById("grid-body").childNodes;         // Gets all rows in matchesTipsGrid table.

    for (var i = 0; i < gridRows.length; i++) {                             // For each one of the rows.
        gridRows[i].style.display = "none";                                 // Change its state to display:none.
    }


    var filters = document.getElementById("filters").childNodes;            // Gets all childrens in filters div.

    for (i = 1; i < filters.length; i++) {                                  // For each item except the first one (which is not a competition instead is the div options).
        filters[i].classList.add("unselected");                             // Adds class named unselected.       
    }
}




// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid columns sorting                                                                    
// ----------------------------------------------------------------------------------------------------------------
var competitionsSorting = "asc";
document.getElementById("header-cell-competitions").addEventListener("click", function () {
  
    document.getElementById("header-cell-date").querySelector("I").style.color      = "transparent";                // Sets header-cell-date arrow to transparent.
    document.getElementById("header-cell-ftotahg").querySelector("I").style.color   = "transparent";                // Sets header-cell-ftotahg arrow to transparent. 


    var headerCellCompetitionsArrow = document.getElementById("header-cell-competitions").querySelector("I");       // Sets header-cell-competitions arrow to greenyellow.
    headerCellCompetitionsArrow.style.color = "#9acd32";


    headerCellCompetitionsArrow.classList.toggle("fa-long-arrow-alt-up");                                           // Toggle sorting icon.
    headerCellCompetitionsArrow.classList.toggle("fa-long-arrow-alt-down");


    if (competitionsSorting === "desc") {                                                                           // Sorts columns accordingly.

        sortCompetitionsAsc();
        competitionsSorting = "asc";

    }
    else if (competitionsSorting === "asc") {

        sortCompetitionsDesc();
        competitionsSorting = "desc";

    }

    resetRowsColors();
});
function sortCompetitionsAsc() {

    var comp_j, comp_i;
    var rows    = document.getElementById("grid-body").childNodes;
    var table   = document.getElementById("grid-body");

    for (var i = 0; i < rows.length - 1; i++) {
        for (var j = i + 1; j < rows.length; j++) {

            comp_i = parseInt(rows[i].getAttribute("compid"));
            comp_j = parseInt(rows[j].getAttribute("compid"));

            if (comp_j < comp_i) {
                table.insertBefore(rows[j], rows[i]);
            }

        }
    }

}
function sortCompetitionsDesc() {

    var comp_j, comp_i;
    var rows = document.getElementById("grid-body").childNodes;
    var table = document.getElementById("grid-body");

    for (var i = 0; i < rows.length - 1; i++) {
        for (var j = i + 1; j < rows.length; j++) {

            comp_i = parseInt(rows[i].getAttribute("compid"));
            comp_j = parseInt(rows[j].getAttribute("compid"));

            if (comp_j > comp_i) {
                table.insertBefore(rows[j], rows[i]);
            }

        }
    }

}

var dateSorting = "desc";
document.getElementById("header-cell-date").addEventListener("click", function () {

    document.getElementById("header-cell-ftotahg").querySelector("I").style.color       = "transparent";        // Sets header-cell-ftotahg arrow to transparent.    
    document.getElementById("header-cell-competitions").querySelector("I").style.color  = "transparent";        // Sets header-cell-competitions arrow to transparent.


    var headerCellDateArrow = document.getElementById("header-cell-date").querySelector("I");                   // Sets header-cell-date arrow to greenyellow.
    headerCellDateArrow.style.color = "#9acd32";


    headerCellDateArrow.classList.toggle("fa-long-arrow-alt-up");                                               // Toggle sorting icon.
    headerCellDateArrow.classList.toggle("fa-long-arrow-alt-down");


    if (dateSorting === "desc")                                                                                 // Sorts columns accordingly.
    {
        sortDateAsc();
        dateSorting = "asc";
    }
    else if (dateSorting === "asc") {

        sortDateDesc();
        dateSorting = "desc";
    }

    resetRowsColors();
});
function sortDateAsc() {

    var date_j, date_i;
    var rows = document.getElementById("grid-body").childNodes;
    var table = document.getElementById("grid-body");

    for (var i = 0; i < rows.length - 1; i++) {
        for (var j = i + 1; j < rows.length; j++) {

            date_i = parseFloat(rows[i].querySelector("#utc-date").getAttribute("utc-date"));
            date_j = parseFloat(rows[j].querySelector("#utc-date").getAttribute("utc-date"));

            if (date_j < date_i) {
                table.insertBefore(rows[j], rows[i]);
            }

        }
    }

}
function sortDateDesc() {

    var date_j, date_i;
    var rows = document.getElementById("grid-body").childNodes;
    var table = document.getElementById("grid-body");

    for (var i = 0; i < rows.length - 1; i++) {
        for (var j = i + 1; j < rows.length; j++) {

            date_i = parseFloat(rows[i].querySelector("#utc-date").getAttribute("utc-date"));
            date_j = parseFloat(rows[j].querySelector("#utc-date").getAttribute("utc-date"));

            if (date_j > date_i) {
                table.insertBefore(rows[j], rows[i]);
            }

        }
    }

}

var ftotahgSorting = "desc";
document.getElementById("header-cell-ftotahg").addEventListener("click", function () {
  
    document.getElementById("header-cell-date").querySelector("I").style.color = "transparent";             // Sets header-cell-date arrow to transparent.    
    document.getElementById("header-cell-competitions").querySelector("I").style.color = "transparent";     // Sets header-cell-competitions arrow to transparent.


    var headerCellFtotahgArrow = document.getElementById("header-cell-ftotahg").querySelector("I");         // Sets header-cell-date arrow to greenyellow.
    headerCellFtotahgArrow.style.color = "#9acd32";


    headerCellFtotahgArrow.classList.toggle("fa-long-arrow-alt-up");                                        // Toggle sorting icon.
    headerCellFtotahgArrow.classList.toggle("fa-long-arrow-alt-down");


    if (ftotahgSorting === "desc")                                                                             // Sorts columns accordingly.
    {
        sortFtotahgAsc();
        ftotahgSorting = "asc";
    }
    else if (ftotahgSorting === "asc") {

        sortFtotahgDesc();
        ftotahgSorting = "desc";
    }

    resetRowsColors();
});
function sortFtotahgAsc() {

    var ftotahg_j, ftotahg_i;
    var rows  = document.getElementById("grid-body").childNodes;
    var table = document.getElementById("grid-body");

    for (var i = 0; i < rows.length - 1; i++) {
        for (var j = i + 1; j < rows.length; j++) {

            ftotahg_i = parseInt(rows[i].getAttribute("ftotahg"));
            ftotahg_j = parseInt(rows[j].getAttribute("ftotahg"));

            if (ftotahg_j < ftotahg_i) {
                table.insertBefore(rows[j], rows[i]);
            }

        }
    }

}
function sortFtotahgDesc() {

    var ftotahg_j, ftotahg_i;
    var rows = document.getElementById("grid-body").childNodes;
    var table = document.getElementById("grid-body");

    for (var i = 0; i < rows.length - 1; i++) {
        for (var j = i + 1; j < rows.length; j++) {

            ftotahg_i = parseInt(rows[i].getAttribute("ftotahg"));
            ftotahg_j = parseInt(rows[j].getAttribute("ftotahg"));

            if (ftotahg_j > ftotahg_i) {
                table.insertBefore(rows[j], rows[i]);
            }

        }
    }

}





// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid reset row colors                                                                   
// ----------------------------------------------------------------------------------------------------------------
function resetRowsColors() {

    var rows = document.getElementById("grid-body").childNodes;

    var oddEven = 0;
    for (var i = 0; i < rows.length; i++) {
        if(rows[i].style.display === "flex")
        {
            if (oddEven === 0) {
                rows[i].style.backgroundColor = "#f2f2f2";
                oddEven = 1;
            }
            else {
                rows[i].style.backgroundColor = "#fff";
                oddEven = 0;
            }          
        }
    }
}




// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid utc_date to client date                                                                                
// ----------------------------------------------------------------------------------------------------------------
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




// ----------------------------------------------------------------------------------------------------------------
// --- On view load executions                                                                
// ----------------------------------------------------------------------------------------------------------------
window.addEventListener("load", function () {
    convertUtcDateToLocalDate();
    setMatchesTipsGridHeight();
});