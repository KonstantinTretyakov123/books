$(document).ready(function () {
    $("#select").change(function () {
        $.ajax({
            type: "GET",
            url: "/Book/SortBooks?value=" + $(this).val(),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('.model').remove();
                jQuery.each(data, function () {
                    console.log($(this)[0].Name);
                    $('table').append('<tr class="model">\
                        <td >'+ $(this)[0].Name + '</td >\
                        <td >'+ $(this)[0].Author + '</td >\
                        <td >'+ $(this)[0].Type + '</td >\
                        <td >'+ $(this)[0].Cost + '</td >\
                        <td>\
                        <form action="/Book/ViewCurrentBook" method="post">\
                        <input type="hidden" name="Id" value="'+ $(this)[0].Id + '" />\
                        <input type="submit" value="Подробнее..." />\
                        </form>\
                        </td>\
                        </tr >');
                });


            },
            error: function (data) {
                console.log(data);
            }
        });
    });
});