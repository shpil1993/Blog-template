$("document").ready(function () {
    $(".drop_arrow").click(function () {
        var id = $(this).attr('id');
        var state = $(this).css('--state');
        if (state == "false") {
            $("#con" + id).slideDown(300);
            $(this).css('--state', 'true');
            $("#i_tag" + id).removeClass("right");
            $("#i_tag" + id).addClass("down");
        }
        else {
            $("#con" + id).slideUp(300);
            $(this).css('--state', 'false');
            $("#i_tag" + id).removeClass("down");
            $("#i_tag" + id).addClass("right");
        }
    });
});