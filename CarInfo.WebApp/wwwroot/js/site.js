$(document).ready(() => {
    var text;
    $("#searchClick").on("click", () => {
        text = $('option:selected').toArray().map(item => item.text).join();
        document.getElementById("colorStringInput").value = text;
        $("#AllData").submit();
    })
});