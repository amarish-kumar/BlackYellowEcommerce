function registerUser() {   
    var user = {
        Email: $('#email').val(),
        Password: $('#password').val()
    }

    if (validaCampos())
    {
        $.ajax({
            type: "POST",
            contentType : "application/json",
            url: '/User/RegisterUser',
            data: JSON.stringify(user),
            success: function (data) {
                if (data.success != null) {
                    limpaCampos();
                    $('#modal-success').modal();
                    $('.modal-title').html("Sucesso!")
                    $('.modal-body').html(data.success);
                }
                else {
                    limpaCampos();
                    $('#modal-warning').modal();
                    $('.modal-title').html("Ooops!")
                    $('.modal-body').html(data.error);
                }

            },
            error: function (data) {

               
            }
        });
        
    }
};

function validaCampos()
{
    if($('#password').val() != $('#confirm_password').val())
    {       
        $('#modal-danger').modal();
        $('.modal-title').html("Alerta")
        $('.modal-body').html("Senha não estão iguais. Tente novamente");
        return false;
    }
    console.log($('#email').val());
    if ($('#password').val() == "" || $('#email').val() == "") {
        $('#modal-danger').modal();
        $('.modal-title').html("Alerta")
        $('.modal-body').html("Preencha os campos.");
        return false;
    }

    return true;
}

function limpaCampos()
{
    $('#password').val("");
    $('#confirm_password').val("")
    $('#email').val("")
}