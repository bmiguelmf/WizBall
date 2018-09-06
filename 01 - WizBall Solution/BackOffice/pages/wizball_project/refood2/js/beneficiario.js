/**
 * Created by gracacs on 04-05-2016.
 */
$(document).ready(function () {

    $("#guardar").click(function () {

        $.post("../functions/beneficiario.php", $("#form_beneficiario").serialize(), function (data) {
            function sendMsg(str) {
                $('html, #form_beneficiario').animate({scrollTop: 0}, 800);
                $("span.msg").text(str);
                $("#mensagemErro").fadeIn("fast");
            }
            //console.log(data);
            switch (data[0]) {
                case "1":
                {
                    sendMsg("Por favor verifique o Nome!");
                    break;
                }
                case "2":
                {
                    sendMsg("Por favor verifique as Idades!");
                    break;
                }
                case "3":
                {
                    sendMsg("Por favor verifique a Entrega ao Domicílio!");
                    break;
                }

                case "4":
                {
                    sendMsg("Por favor verifique o Número de Adultos!");
                    break;
                }
                case "5":
                {
                    sendMsg("Por favor verifique o Contacto!");
                    break;
                }
                case "6":
                {
                    sendMsg("Por favor verifique o Horário!");
                    break;
                }
                case "0":
                {
                    sendMsg("Erro de inserção dos dados na base de dados.");
                    break;
                }

                default:
                {
                    //alert("Here's Johnny!");
                     //var dadosUser = JSON.parse(data);
                     //window.location = dadosUser['paginaAIr'];
                    break;
                }
            }
        });
    });
});