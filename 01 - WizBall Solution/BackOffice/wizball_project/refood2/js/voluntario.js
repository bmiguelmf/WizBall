/**
 * Created by ivorocha on 02-05-2016.
 */

$(document).ready(function () {

    $("#registar").click(function () {

        $.post("../functions/voluntario.php", $("#form_registar").serialize(), function (data) {
            function sendMsg(str) {
                $('html, #form_registar').animate({scrollTop: 0}, 800);
                $("span.msg").text(str);
                $("#mensagemErro").fadeIn("fast");
            }
            switch (data[0]) {
                case "1":
                {
                    sendMsg("Por favor verifique o Username!");
                    break;
                }
                case "2":
                {
                    sendMsg("Por favor verifique o Nome!");
                    break;
                }
                case "3":
                {
                    sendMsg("Por favor verifique a Password WEB!");
                    break;
                }

                case "4":
                {
                    sendMsg("Por favor verifique o Email!");
                    break;
                }
                case "5":
                {
                    sendMsg("Por favor verifique o Contacto!");
                    break;
                }
                case "6":
                {
                    sendMsg("Por favor verifique a Data de Nascimento!");
                    break;
                }
                case "7":
                {
                    sendMsg("Por favor verifique a Fotografia!");
                    break;
                }

                case "8":
                {
                    sendMsg("Por favor verifique o Tipo de utilizador!");
                    break;
                }

                case "9":
                {
                    sendMsg("Por favor verifique a Localização da Refood!");
                    break;
                }

                case "0":
                {
                    sendMsg("Erro de inserção dos dados na base de dados.");
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