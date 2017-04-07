$(function () {
    var current = $(".sub_left .current");
    var right_con = $(".right");
    $(".sub_left li").click(function () {
        var item = $(this);
        var html_url = item.attr("html");
        var params = item.attr("params");
        window.history.replaceState({},"", params);
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
    var tag = getQueryString("tag");
    if(tag){
      $("#"+tag).click();
    }else{
      current.click();
    }
    $(".lang_bar_txt").click(function(){
       var code = $(this).attr("code");
       var backUrl = window.location.href;
       window.location.href="/home/language/?culture="+code+"&backurl="+backUrl;
    });
});
function getQueryString(name) { 
   var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i"); 
   var r = window.location.search.substr(1).match(reg); 
   if (r != null) return unescape(r[2]); return null; 
}