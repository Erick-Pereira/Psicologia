var objetoGrafico = new Object();

objetoGrafico.CarregaGrafico = function () {

    $("#gridColuna").html("");

    $.ajax(
        {
            type: 'GET',
            timeout: 5000,
            url: '/Home/CarregaGrafico',
            async: true,

            success: function (jsonResult) {

                jsonResult.dados.forEach(function (item) {

                    var coluna = $("<div>", { class: "coluna" });
                    var tituloColuna = $("<div>", { class: "tituloColuna" });
                    tituloColuna.text(item.tituloRodape);

                    var colunaPorcentagem = $("<div>", { class: "colunaPorcentagem" });
                    var porcentagem = $("<div>", { class: "porcentagem", style: "height: " + item.porcentagem + "%" });
                    colunaPorcentagem.append(porcentagem);

                    var bolinha = $("<div>", { class: "bolinha" });
                    var porcentagemTitulo = $("<span>", { class: "porcentagemTitulo" });
                    porcentagemTitulo.text(item.porcentagem + "%");

                    bolinha.append(porcentagemTitulo);

                    coluna.append(tituloColuna);
                    coluna.append(colunaPorcentagem);
                    coluna.append(bolinha);

                    $("#gridColuna").append(coluna);

                });

            }
        });
}

$(function () {
    objetoGrafico.CarregaGrafico();
});