// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    messageTimerId = null;
});


function showMessage(message, isError) {
    $("#infoMessage").text(message);
    $("#pinId").removeClass("UnPinIcon hidden");
    $("#pinId").addClass("pinIcon");

    if (isError == 1) {
        
        $("#infoMessage").removeClass("messageInfo hidden");
        $("#infoMessage").addClass("messageError showBlock");
    } else {
        $("#infoMessage").removeClass("messageError hidden");
        $("#infoMessage").addClass("messageInfo showBlock");
    }

    messageTimerId = setTimeout(function () {
        $("#infoMessage").addClass("hidden");  
        $("#pinId").addClass("hidden");
    }, 3000);

    setTimeout(function () {       
        unblockFormSend();
    }, 3000);

}

function pinMessage() {
    if (messageTimerId == undefined) {
        messageTimerId = null
    }

    if (messageTimerId != null) {
        clearTimeout(messageTimerId);
        messageTimerId = null;
        $("#pinId").removeClass("pinIcon");
        $("#pinId").addClass("UnPinIcon");
    }
    else {
        $("#infoMessage").addClass("hidden");
        $("#pinId").removeClass("UnPinIcon");
        $("#pinId").addClass("pinIcon hidden");
    }

}