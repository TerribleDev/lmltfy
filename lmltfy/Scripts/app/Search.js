$(document).ready(function () {
    var playSearch = function () {
        var txt = $("#SearchQuery").val();
        var txtLength = txt.length;

        var currentText = $("#Search").val();
        var currentTextLength = currentText.length;
        $("#Search").val(txt.substr(0, currentTextLength + 1));

        if (txtLength > currentTextLength) {
            _.delay(function () {
                $("#Search").focus();
                playSearch();
                $("#Search").focus();
            }, 200);
        } else {
            _.delay(function () {
                window.location.href = $("#RedirUrl").val() + $("#Key").val();
            }, 300);
        } 

    }

    playSearch();


});