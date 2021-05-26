$('#newProdForm').submit(function (e) {
    e.preventDefault(); // stop the standard form submission

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            console.log(data.UploadedFileCount + ' file(s) uploaded successfully');
        },
        error: function (xhr, error, status) {
            console.log(error, status);
        }
    });
});



function showMessage(message, isError) {
    if (isError == 1) {
        $("#infoMessage").removeClass("messageInfo hidden");
        $("#infoMessage").addClass("messageError showBlock");
    } else {
        $("#infoMessage").removeClass("messageError hidden");
        $("#infoMessage").addClass("messageInfo showBlock");
    }

    setTimeout(function () {
        $("#infoMessage").addClass("hidden");
    }, 3000);

}

function blockFormSend() {

}

function unblockFormSend() {

}
