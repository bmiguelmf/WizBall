$(document).ready(function () {

    setViewMatchesHeight();

    window.addEventListener("resize", setViewMatchesHeight);

});


function setViewMatchesHeight() {

    // Gets the pointer to html element.
    var gridMatches = document.getElementById("my-grid-body");

    // Gets the n childs of grid matches.
    var nMatches = gridMatches.childElementCount;

    // Set the initial grid height just by multipling row height by total row number.
    var gridHeight = nMatches * 29;
    // This number can be very high (bigger than viewport) in some cases so we need to check if this is the case.


    // First gets the viewport height based on orientation and subtract (150 or 200 px).
    var viewPortHeight;

    // Vertical.
    if (window.innerHeight > window.innerWidth) {
        viewPortHeight = $(window).height() - 350;
    }
    // Horizontal.
    else {
        viewPortHeight = $(window).height() - 300;
    }



    // Now while gridHeight is bigger than viewPortHeight
    while (gridHeight > viewPortHeight) {

        // Simply reduces it by 29px at a time.
        gridHeight -= 29;
    }

    
    // Setup attribute.
    var viewMatchesHeight = "height:" + gridHeight + "px;";


    // And finally apply the height.
    document.getElementById("scrolableGridMatchesBody").setAttribute("style", viewMatchesHeight);
}