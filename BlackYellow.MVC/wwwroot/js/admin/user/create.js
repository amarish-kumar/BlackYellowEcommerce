




function registerUser() {

    var user = {
        Email: $('#email').val(),
        Password: $('#password').val()
    }

    console.log(JSON.stringify(user));
   
    $.ajax({
        type: "POST",
        contentType : "application/json",
        url: '/User/RegisterUser',
        data: JSON.stringify(user),
        success: function (data) {console.log(data) },
        
    });

};