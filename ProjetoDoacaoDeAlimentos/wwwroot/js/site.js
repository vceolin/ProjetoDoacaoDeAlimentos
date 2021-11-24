// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function buscaAlimento(nomeAlimento) {
    $.ajax({
        url: "https://api-trabalho-tdc.herokuapp.com/v1/imagens/" + nomeAlimento,
        context: document.body,
        success: function (result) {
            $("#imgAlimento").attr("src", result);
        }
    });
}
