

$("#save").on("click", function () {

    var name = $('#Header').val();
    $.ajax({
        type: 'GET',
        url: "/Article/GetByName?name=" + name,
        cache: false,
        success: function (data) {
            debugger 
            if (data == true) {
                alert("This record is already exists!");
            } else {
                $('form').trigger('submit', function(success) {
                    alert("Registration has been successful!");
                });
            }
        }, error: function (xhr, status, error) {
            alert("There was an error adding!");
        }
    });
});
