function logar()
{
    var email = $('#email').val();
    var password = $('#password').val();
    var user = {
        email: email,
        password: password
    }

    console.log(email);
    $.ajax({
        method: "POST",
        contentType: "application/json",
        data:  JSON.stringify(user) ,
        url: "/Account/Logar",
        success: function (data) {
            console.log(data);
            if(data.success != null)
            {
                location.href = "/Home/Index";
            }
            else {

            }
        },

        error: function () {

        }
    })
}