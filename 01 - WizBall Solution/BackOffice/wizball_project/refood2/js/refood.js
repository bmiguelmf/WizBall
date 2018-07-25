/**
 * Created by ivorocha on 02-05-2016.
 */

$(document).ready(function () {

    $("#registarRefood").click(function () {
        $.post("../functions/refood.php", $("#form_registarRefood").serialize(), function (data) {
            function sendMsg(str) {
                $('html, #form_registarRefood').animate({scrollTop: 0}, 800);
                $("span.msg").text(str);
                $("#mensagemErro").fadeIn("fast");
            }
            switch (data[0]) {
                case "1":
                {
                    sendMsg("Por favor verifique o nome que adicionei!");
                    break;
                }
                case "2":
                {
                    sendMsg("Por favor verifique a morada!");
                    break;
                }
                case "3":
                {
                    sendMsg("Por favor verifique o código postal!");
                    break;
                }

                case "4":
                {
                    sendMsg("Por favor verifique a localidade");
                    break;
                }
                case "5":
                {
                    sendMsg("Por favor verifique o contacto!");
                    break;
                }
                case "6":
                {
                    sendMsg("Por favor verifique o horário!");
                    break;
                }
                case "7":
                {
                    sendMsg("Por favor verifique o responsável!");
                    break;
                }

                case "8":
                {
                    sendMsg("Por favor verifique a localização da Refood!");
                    break;
                }

                default:
                {
                    //var dadosUser = JSON.parse(data);
                    //window.location = dadosUser['paginaAIr'];
                    break;
                }
            }
        });
    });
});