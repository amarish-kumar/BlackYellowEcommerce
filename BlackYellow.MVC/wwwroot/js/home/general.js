$(document).ready(function () {
    getCategories();
   
});




function fillCategories(categories) {
   
    var html = '<li>' +
                    '<a > Categorias </a>' +
               '</li>';
    $("#category").append(html);
    $.each(categories, function (item, value) {
        html = '<li>'+
                    '<a onclick="searchCategory('+value.categoriesId+')">' + value.name +'</a>'+
               '</li>'
        $("#category").append(html);
    });

    
}

function fillProducts(products)
{
    var html = "";

    $.each(products, function (item, value) {

        html = '<div class="col-sm-6 col-md-4">' +
                '<div class="single-product">' +
                    '<div class="product-f-image">' +
                       ' <img src="'+value.ImagePrincipal+'" class="img-responsive" alt="">' +
                        '<div class="product-hover">' +
                            '<a onclick="buy('+value.ProductId+')" class="add-to-cart-link"><i class="fa fa-shopping-cart"></i> Comprar</a>' +
                            '<a href="Product/Details/'+value.ProductId+'" class="view-details-link"><i class="fa fa-link"></i> Detalhes</a>' +
                        '</div>' +
                    '</div>' +
                   ' <h2><a href="Product/Details/' + value.ProductId + '">' + value.Name + '</a></h2>' +
                   ' <div class="product-carousel-price">' +
                       ' <ins>R$'+value.LastPrice+'</ins> <del>'+value.Price+'</del>' +
                   '</div>' +
               ' </div>' +
           ' </div>';

        $("#products").append(html);
    });
}


function getCategories()
{
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Category/List",
        success: function (data) {
            fillCategories(data.categories);
        }
    })
}

function getProducts()
{
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Product/List",
        success: function (data) {
            fillProducts(data.products);
        }
    })
}