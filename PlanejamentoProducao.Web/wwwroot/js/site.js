$(document).ready(() => {
    $.ajax({
        type: "GET",
        url: "/api/GerenciadorFila/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);

            $("#tbl-menor-tempo tbody").html("");

            $.each(data, function (i, item) {
                var rows = "<tr>" +
                    "<td>" + item + "</td>" +
                    "</tr>";
                $("#tbl-menor-tempo tbody").append(rows);
            });
        },
        failure: function (data) {
            console.log(data.responseText);
        },
        error: function (data) {
            console.log(data.responseText);
        }
    });
});