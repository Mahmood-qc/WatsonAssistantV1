// Write your JavaScript code.
function updateScroll() {
    var element = document.getElementById("messagesDiv");
    element.scrollTop = element.scrollHeight;
}

function CallAssistant() {

    var message = $("#inputMessage").val();
    $("#messagesDiv").append("<div class='green_box'><span>" + message + "</span></div>");
    $("#inputMessage").val("");
    $.ajax({
        url: "/Home/CallAssistant",
        type: "POST",
        data: "{ Message: '" + message + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        complete: function (response) {
            $("#messagesDiv").append("<div class='blue_box'><span>" + response.responseText + "</span></div>");
            updateScroll();
        }
    })
}