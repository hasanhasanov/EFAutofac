

    $("#save").on("click", function () {
        debugger;
        var name = $('#Name').val();
        $.ajax({
            type: 'GET',
            url: "/Category/GetByName?name=" + name,
            cache: false,
            success: function (data) {
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

