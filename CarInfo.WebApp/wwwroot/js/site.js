$(document).ready(() => {
    var text;
    $("#searchClick").on("click", () => {
        text = $('option:selected').toArray().map(item => item.text).join();
        // $("#colorStringInput").val() = text;
        document.getElementById("colorStringInput").value = text;
        $("#AllData").submit();
    })
});