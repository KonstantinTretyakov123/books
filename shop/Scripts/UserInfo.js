$(document).ready(function () {
    var show = false;
    $("#Info").click(function () {
        var id = $('#UserId').val();
        var div = document.getElementById("results");
        if (show == false) {
            $.ajax({
                type: "GET",
                url: "/Book/ViewUserInfo?id=" + id,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    div.innerHTML =
                        '<p>' +
                        data.LastName +
                        " " +
                        data.FirstName +
                        " " +
                        data.MiddleName +
                        "<br>" +
                        data.Address +
                        " " +
                        data.Number +
                        "</p>";
                },
                error: function (data) {
                    console.log(data);
                }
            });
            show = true;
        } else {
            div.removeChild(div.firstChild);
            show = false;
        }
    });
});