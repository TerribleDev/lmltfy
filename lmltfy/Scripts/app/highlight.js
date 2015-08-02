jQuery.fn.highlight = function () {
    $(this).each(function () {
        var el = $(this);
        el.before("<div/>");
        el.prev()
            .width(el.width())
            .height(el.height())
            .css({
                "position": "absolute",
                "background-color": "#ffff99",
                "opacity": ".9"
            })
            .fadeOut(1200);
    });
}