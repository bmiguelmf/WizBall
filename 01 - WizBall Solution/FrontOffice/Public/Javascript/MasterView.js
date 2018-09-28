// Humburger click.
document.getElementById("humburger").addEventListener("click", function () {

    document.getElementById("responsive-menu").classList.toggle("responsive-menu-open");

});




// Modal logout show.
document.getElementById("logout").addEventListener("click", function () {

    document.getElementById("outter-modal").style.display = "block";

});
document.getElementById("logoutt").addEventListener("click", function () {

    document.getElementById("outter-modal").style.display = "block";

});
// Modal logout close.
document.getElementById("btnModalCancel").addEventListener("click", function () {

    document.getElementById("outter-modal").style.display = "none";

});