$(document).ready(function () {
    $('#prodCatTable').DataTable();
});

// id значение ID продукта
// Qnt  идентификатор элемента со значением количества
function addProductToCart(Id, Qnt ) {
    console.log(Id);
    console.log( $(Qnt).val());

    var pId = Id;
    var qVal = $(Qnt).val();

    function updateCartInfo(data) {

        if (data.result == "ok") {
            $("#CartItemsLinkId").text('In Cart: ' + data.posCount + '(' + data.itemCount + ')')
        }
        else { alert("Контроллер не вернул ОК") }

    }


    $.ajax({
        contentType: 'application/json',
        url: '/Product/AddToCart/' + Id + '/' + qVal,
        type: 'POST',
        success: updateCartInfo,
        error: function () { alert("Ошибка при обращении к серверу") }

    })


}
