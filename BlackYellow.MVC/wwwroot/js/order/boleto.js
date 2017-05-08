
$(document).ready(function () {
    get();
});



function get() {
    $.ajax({
        contentType: "application/json",
        method: "GET",
        url: "http://localhost:29525/api/values/1",
        success: function (data) {
            console.log(data);
            $("#boleto").html(data);
        }
    });
}