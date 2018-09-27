// Window resize.
window.addEventListener("resize", setMatchesTipsGridHeight);

function setMatchesTipsGridHeight() {

    // windows height.
    var winHeight = window.innerHeight;

    // Navigation height.
    var navHeight = $("#app-header").height();

    // Free height.
    var freeHeight = winHeight - navHeight -30 -100;


    while (freeHeight % 30 !== 0) {
        freeHeight--;
    }
    
    //var scrollableHeigth = $("#grid-body-scrollable").height();

    if (window.innerWidth >= 960) {
        //if (scrollableHeigth < freeHeight) {
        //    document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + scrollableHeigth + "px;");
        //}
        //else {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + freeHeight + "px;");
        //}
        
    }
    else {
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