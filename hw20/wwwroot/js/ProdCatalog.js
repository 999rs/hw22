﻿$(document).ready(function () {
    $('#prodCatTable').DataTable();
});

// добавляем продукты в карзину
// id значение ID продукта
// Qnt  идентификатор элемента со значением количества
function addProductToCart(Id, Qnt ) {
    console.log(Id);
    console.log( $(Qnt).val());
    
    var qVal = $(Qnt).val();


    $.ajax({
        contentType: 'application/json',
        url: '/Product/AddToCart/' + Id + '/' + qVal,
        type: 'POST',
        success: updateCartInfo,
        error: function () { alert("Ошибка при обращении к серверу") }

    })


}

// обновляем данные о корзине в блоке навигации
function updateCartInfo(data) {

    if (data.result == "ok") {
        $("#CartItemsLinkId").text('In Cart: ' + data.posCount + '(' + data.itemCount + ')')
    }
    else { alert("Контроллер не вернул ОК") }

}