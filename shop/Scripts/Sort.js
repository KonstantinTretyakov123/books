$(document).ready(function() {
    $("#select").change(function() {
        $.ajax({
            type: "GET",
            url: "/Car/SortCars?value=" + $(this).val(),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('.model').remove();
                jQuery.each(data, function() {
                    console.log($(this)[0].BodyType);
                    $('table').append('<tr class="model">\
                        <td >'+ $(this)[0].CarName +'</td >\
                        <td >'+ $(this)[0].ReleaseYear +'</td >\
                        <td >'+ $(this)[0].Run +'</td >\
                        <td >'+ $(this)[0].Fuel +'</td >\
                        <td >'+ $(this)[0].Color +'</td >\
                        <td>\
                        <form action="/Car/ViewCurrentCar" method="post">\
                        <input type="hidden" name="Id" value="'+ $(this)[0].Id +'" />\
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