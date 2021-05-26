$(document).ready(function () {
    $('#prodCatTable').DataTable();
});

// добавляем продукты в карзину
// id значение ID продукта
// Qnt  идентификатор элемента со значением количества
function addProductToCart(Id, Qnt ) {
    console.log(Id);
    //console.log( $(Qnt).val());
    
    //var qVal = $(Qnt).val();
    var qVal = Qnt;


    $.ajax({
        contentType: 'application/json',
        url: '/Product/AddToCart/' + Id + '/' + qVal,
        type: 'POST',
    /*   success: updateCartInfo(Id),*/
        success: function (data) {
            updateCartInfo(Id, data);
            updateCartTileInfo(Id, data);
        },
        error: function () { alert("Ошибка при обращении к серверу") }

    })


}

// обновляем данные о корзине в блоке навигации
function updateCartInfo(id, data) {

    if (data.result == "ok") {
        $("#CartItemsLinkId").text('In Cart: ' + data.posCount + '(' + data.itemCount + ')');
    }
    else { alert("Контроллер не вернул ОК") }

}

// обновляем данные о корзине в блоке карточки
function updateCartTileInfo(id, data) {

    if (data.result == "ok") {
        if (data.thisItemNewCount > 0)
            $("#itemCartSpan_" + id).text(data.thisItemNewCount);
        else
            $("#itemCartSpan_" + id).text("");
    }
    else { alert("Контроллер не вернул ОК") }

}


function removeProduct(Id) {

    $.ajax({
        contentType: 'application/json',
        url: '/Product/Delete/' + Id ,
        type: 'DELETE',
        /*   success: updateCartInfo(Id),*/
        success: function (data) {
            JSON.stringify(data);
            if (data.result == "ok") {
                removeProdTile(Id);
                showMessage("Продукт удален!", 0)
            }
        },
        error: function () {
            showMessage("Ошибка при обращении к серверу", 1);
            //alert("Ошибка при обращении к серверу")
        }

    })
}

function removeProdTile(Id) {
    $("#ProdCardId_" + Id).remove();

}

function editProduct(id) {
    var url = '/Product/edit/' + id;
    window.open(url);
}
    