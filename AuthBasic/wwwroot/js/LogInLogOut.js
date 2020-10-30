function log_out() {
    $.ajax({
        type: "GET",
        url: "/Account/LogOut",
        success: function (data) {
            location.reload()
        },
        failure: function (data) {
            console.log("LogOut Failed")
        }
    });
}

function log_in() {
    $('#login-overlay').css({
        'display': 'block'
    });
}