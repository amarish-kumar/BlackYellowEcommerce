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