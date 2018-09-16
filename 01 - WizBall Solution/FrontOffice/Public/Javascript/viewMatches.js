$(document).ready(function () {
    setViewMatchesHeight();
});


function setViewMatchesHeight() {

    // Gets viewport height based on orientation.
    var viewMatchesHeight;

    // Vertical.
    if (window.innerHeight > window.innerWidth) {
        viewMatchesHeight = $(window).height() - 200;
    }
    // Horizontal.
    else {
        viewMatchesHeight = $(window).height() - 150;
    }

    // Normalizes viewMatchesHeight in order for matches rows are fully visible.
    while (viewMatchesHeight % 29 != 0) {
        viewMatchesHeight--; 
    }

    // Setup attribute.
    var vpHeight = "height:" + viewMatchesHeight + "px;";

    // And finally apply it.
    document.getElementById("scroll").setAttribute("style", vpHeight);
}