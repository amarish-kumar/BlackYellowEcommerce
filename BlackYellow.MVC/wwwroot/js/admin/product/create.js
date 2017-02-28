$(document).ready(function () {
    getCategories();

});

function getCategories() {
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Category/List",
        success: function (data) { fillCategories(data) }
    });
}


function fillCategories(response)
{
   
    $("p").append("<option value="+ response.CategoryId+">"+response.Name+"</option> ");
}