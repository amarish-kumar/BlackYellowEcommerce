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
            success: function (data) {console.log(data) },
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

    return true;
}