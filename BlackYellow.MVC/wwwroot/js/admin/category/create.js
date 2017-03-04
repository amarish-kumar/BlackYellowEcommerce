function registerCategory() {
    var category = {
        Name: $('#name').val(),
        Description : $('#description').val()
    }

    //fazer validação de campos
    //se tiver tudo ok faça..
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: '/Category/RegisterCategory',
        data: JSON.stringify(category),
        success: function (data) {
            if (data.success != null) {
                //limpaCampos();
                $('#modal-success').modal();
                $('.modal-title').html("Sucesso!")
                $('.modal-body').html(data.success);
            }
            else {
                //limpaCampos();
                $('#modal-warning').modal();
                $('.modal-title').html("Ooops!")
                $('.modal-body').html(data.error);
            }
        },
        error: function (data) {
        }
    });
}