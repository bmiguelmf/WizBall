document.getElementById("humburger").addEventListener("click", function(){

    document.getElementById("responsive-menu").classList.toggle("responsive-menu-open");

});

window.addEventListener("resize", setMatchesTipsGridHeight);


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


    if (window.innerWidth >= 1060) {
        document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + eightPercent + "px;");
        document.getElementById("grid").setAttribute("style", "margin-top:" + marginTop + "px;");
    }
    else {
        document.getElementById("grid").setAttribute("style", "margin-top: 0");
        document.getElementById("grid-body-scrollable").setAttribute("style", "height: auto");
    }
   
}

setMatchesTipsGridHeight();
