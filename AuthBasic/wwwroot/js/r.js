// TODO hack shit
var canCall = true;
function what() {

    if (canCall) {
        canCall = false;
    }
    else{
        return;
    }


    var PostArray = document.getElementsByClassName("last");
    var LastPostID = PostArray[PostArray.length - 1].id;
    var Subreddit = window.location.pathname.match(/\/\w\/\w+/gm)[0].slice(3);

    $.ajax({
        url: `/reddit/GetPosts?subreddit=${Subreddit}`,
        dataType: 'html',
        success: function (data) {
            $('#grid').html(data);
            setTimeout(() => {
                canCall = true;
            }, 100);
        }
    });
}

window.addEventListener('DOMContentLoaded', (event) => {
    console.log('DOM fully loaded and parsed');

    let options = {
        rootMargin: '0px',
        threshold: 1.0
    }

    var observer = new IntersectionObserver(what, options);

    var target = document.getElementsByClassName('last')[0];
    observer.observe(target);
});
