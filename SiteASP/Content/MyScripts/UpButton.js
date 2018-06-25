$("body").ready(function () {
    $("body").append('<a href="#" id="go-to-top" title="Вверх">^</a>');
});
$(function () {
    $.fn.scrollToTop = function () {
        $(this).hide().removeAttr("href");
        var scrollDiv = $(this);
        $(window).scroll(function () {
            if ($(window).scrollTop() > "250") {
                $(scrollDiv).fadeIn("slow");
            }
            else {
                $(scrollDiv).fadeOut("slow");
            }
        });
        $(this).click(function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");
        });
    }
});
$(function () {
    $("#go-to-top").scrollToTop();
    $("#go-to-top").mouseover(function () {
        $(this).animate({
            fontSize: "20px"
        }, 50).css({
            color: "white",
            backgroundColor: "#ffb84d"
        });
    });
    $("#go-to-top").mouseout(function () {
        $(this).animate({
            fontSize: "15px"
        }, 50).css({
            color: "black",
            backgroundColor: "rgba(191, 191, 191, 0.40)"
        });
    });
});