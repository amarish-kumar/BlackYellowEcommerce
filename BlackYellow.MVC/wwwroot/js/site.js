// Write your Javascript code.

$(document).ready(function () {
    getCategories();
    getItensQTD();

});

function buy(id) {

    var product = { ProductId: id }

    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Order/Buy",
        data: JSON.stringify(product),
        success: function (data) {
            getItensQTD();
            bootbox.alert("Produto adicionado com sucesso");
        }
    })
}


function getCategories() {
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Category/ListWithProducts",
        success: function (data) {
            fillCategories(data.categories);
        }
    })
}



function searchCategory(categoryId) {
    var category = { CategoryId: categoryId }
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Product/SearchByCategory",
        data: JSON.stringify(category),
        success: function (data) {

        }
    });
}

function fillCategories(categories) {

    var html = '<li>' +
                    '<a > Categorias </a>' +
               '</li>';
    $("#category").append(html);
    $.each(categories, function (item, value) {

        html = '<li>' +
                    '<a href="/Product/SearchByCategory/' + value.categoryId + '">' + value.name + '</a>' +
               '</li>'
        $("#category").append(html);
    });
    console.log(html);


}

function getItensQTD() {
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Order/Itens",
        success: function (data) {

            fillCartQTD(data.carrinho.quantity);
        },
        error: {}
    })
}


function fillCartQTD(qtd) {
    $(".product-count").html(qtd);
}