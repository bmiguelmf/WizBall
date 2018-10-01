var fileUpload          = document.getElementById("fileuploadUserPicture");
var customFileUpload    = document.getElementById("btnCustomFileUpload");
var userPic             = document.getElementById("imgUserPic");


customFileUpload.addEventListener("click", function () {

    fileUpload.click();

});

fileUpload.addEventListener("change", function () {

    if (this.files && this.files[0]) {

        var fileReader = new FileReader();

        fileReader.readAsDataURL(this.files[0]);

        fileReader.onload = function (data) {
            userPic.src = data.target.result;
        };
    }

});