$('#editProdForm').submit(function (e) {
    e.preventDefault(); // stop the standard form submission

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            blockFormSend();
            //console.log(data.UploadedFileCount + ' file(s) uploaded successfully');

            if (data.result == "ok")
                showMessage(data.message, 0)
            else {
                console.log(data.message);
                showMessage("Ошибка! " + data.message, 1)


            };
            setTimeout(function () {
                unblockFormSend();
            }, 3000);
        },
        error: function (xhr, error, status) {
            blockFormSend();
            console.log(error, status);
            showMessage("Ошибка на сервере! " + xhr.error + " *** " + xhr.message, 1);
            setTimeout(function () {
                unblockFormSend();
            }, 3000);
        }
    });
});



function blockFormSend() {
    $("#submitBtn").hide();
}

function unblockFormSend() {
    $("#submitBtn").show();
}
