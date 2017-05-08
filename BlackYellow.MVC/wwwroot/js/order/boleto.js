
$(document).ready(function () {
    get();
});



function get() {
    $.ajax({
        contentType: "application/json",
        method: "GET",
        url: "/Order/BoletoMontado",
        success: function (data) {
            console.log(data);
            $("#boleto").html(data);
        }
    });
}