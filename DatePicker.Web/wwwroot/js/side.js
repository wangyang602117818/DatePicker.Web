$(function () {
    var current = $(".sub_left .current");
    var right_con = $(".right");
    $(".sub_left li").click(function () {
        var item = $(this);
        var html_url = item.attr("html");
        right_con.loading();
        $.get(html_url, function (data) {
            right_con.loading();
            right_con.html(data);
            if (!item.hasClass("current")) {
                item.addClass("current");
                current.removeClass("current");
                current = item;
            }
            datepicker();
        });
    });
    current.click();
});