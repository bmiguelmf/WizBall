/**
 * Created by gracacs on 03-05-2016.
 */

$(document).ready(function () {
    $("#submeter").click(function () {

        $.post("../functions/fonte.php", $("#form_fonte").serialize(), function (data) {

            function sendMsg(str) {
                $('html, #form_fonte').animate({scrollTop: 0}, 800);
                $("span.msg").text(str);
                $("#mensagemErro").fadeIn("fast");
            }
            switch (data[0]) {
                case "1":
                {
                    sendMsg("Por favor verifique o nome!");
                    break;
                }
                case "2":
                {
                    sendMsg("Por favor verifique o nome da empresa!");
                    break;
                }
                case "3":
                {
                    sendMsg("Por favor verifique o telefone!");
                    break;
                }
                case "4":
                {
                    sendMsg("Por favor verifique o email!");
                    break;
                }
                case "5":
                {
                    sendMsg("Por favor verifique a morada!");
                    break;
                }
                case "0":
                {
                    sendMsg("Erro de inserção dos dados na base de dados.");
                    break;
                }
                default:
                {
                    /*alert("yay!");
                    var dadosUser = JSON.parse(data);
                    window.location = dadosUser['paginaAIr'];*/
                    break;
                }
            }
        });
    });
});