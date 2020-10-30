// TODO hack shit
function GetCommentForm() {
    console.log("hey")
    $.ajax({
        url: "/reddit/createcomment",
        dataType: 'html',
        success: function (data) {
            $('#testshit').html(data);
            setTimeout(() => {
                canCall = true;
            }, 100);
        }
    });
}
