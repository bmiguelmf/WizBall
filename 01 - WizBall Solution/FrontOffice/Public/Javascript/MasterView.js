//////////////////////////////////////////////////////////////////////////////
// Event Listners.
//////////////////////////////////////////////////////////////////////////////

// Humburger click.
document.getElementById("humburger").addEventListener("click", function () {

    document.getElementById("responsive-menu").classList.toggle("responsive-menu-open");

});

// Window resize.
window.addEventListener("resize", setMatchesTipsGridHeight);

//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////





function setMatchesTipsGridHeight() {

    // windows height.
    var winHeight = window.innerHeight;

    // Navigation height.
    var navHeight = $("#app-header").height();

    // Free height.
    var freeHeight = winHeight - navHeight - 30;

    // eightPercent.
    var eightPercent    = Math.floor(freeHeight * 0.8);
   

    while (eightPercent % 30 !== 0) {
        eightPercent++;
    }

    var marginTop = (freeHeight - eightPercent) / 2;


    if (window.innerWidth >= 960) {
        document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + eightPercent + "px;");
        document.getElementById("grid").setAttribute("style", "margin-top:" + marginTop + "px;");
    }
    else {
        document.getElementById("grid").setAttribute("style", "margin-top: 0");
        document.getElementById("grid-body-scrollable").setAttribute("style", "height: auto");
    }
   
}
// Run setMatchesTipsGridHeight one time when page ready


// Im here
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