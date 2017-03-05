$(document).ready(function () {
    getCategories();

});

function getCategories() {
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Category/List",
        success: function (data) { fillCategories(data.categories) }
    });
}


function fillCategories(response)
{
   
    $.each(response, function (item, value) {
        console.log(value);
        $("#category").append("<option value=" + value.categoryId + ">" + value.name + "</option> ");
    });
   
   
}