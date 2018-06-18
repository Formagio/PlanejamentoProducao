function incluirProcesso() {
    var data = {
        "Identificador": $("#txt-identificador").val(),
        "TempoExecucao": $("#txt-tempo-execucao").val(),
        "CustoPorHora": $("#txt-custo-por-hora").val(),
    };

    $.ajax({
        type: "POST",
        url: "/api/GerenciadorFila/",
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (data) {
            carregarProcessos();
            $("#frm-inclusao-processo").trigger("reset");
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

function carregarProcessos() {
    $.ajax({
        type: "GET",
        url: "/api/GerenciadorFila/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            preencherTabela($("#tbl-menor-tempo tbody"), data.menor_tempo_espera);
            preencherTabela($("#tbl-menor-custo tbody"), data.menor_custo_espera);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

function preencherTabela(tabela, dados) {
    tabela.html("");

    $.each(dados, function (i, item) {
        var row =
            "<tr>" +
                "<td>" + (i + 1) + ". " + item + "</td>" +
            "</tr>";
        tabela.append(row);
    });
}

$(document).ready(() => {
    carregarProcessos();
});