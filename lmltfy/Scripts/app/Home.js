function showResults(data) {
    $("#mainGrp").hide();
    $("#resultsDiv").show();
    $("#results").val(data.responseText);
    $("#resultsDiv").highlight();

}
function disableBtn() {
    $("#submitBtn").prop("disabled", true);
    $("#LoadingGif").show();
}