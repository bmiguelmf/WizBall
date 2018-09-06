var $grid;
$(document).ready(function () {


    if ($(".scrollToTop").length > 0) {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 300) {
                $('.scrollToTop').fadeIn();
            } else {
                $('.scrollToTop').fadeOut();
            }
        });

        //Click event to scroll to top
        $('.scrollToTop').click(function () {
            $('html, body').animate({scrollTop: 0}, 800);
            return false;
        });

    }

    var config = {
        '.chosen-select': {},
        '.chosen-select-deselect': {allow_single_deselect: true},
        '.chosen-select-no-single': {disable_search_threshold: 10},
        '.chosen-select-no-results': {no_results_text: 'Sem resultados!'},
        '.chosen-select-width': {width: "95%"}
    }
    for (var selector in config) {
        $(selector).chosen(config[selector]);
    }


    if ($(".dataTables-example").length > 0) {
        var oTable = $('.dataTables-example').DataTable({
            language: {
                "sProcessing": "A processar...",
                "sLengthMenu": "Mostrar _MENU_ registos",
                "sZeroRecords": "Não foram encontrados resultados",
                "sInfo": "A mostrar _START_ - _END_ de _TOTAL_ registos",
                "sInfoEmpty": "0 registos",
                "sInfoFiltered": "(filtrado de _MAX_ registos no total)",
                "sInfoPostFix": "",
                "sSearch": "Procurar:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "Primeiro",
                    "sPrevious": "Anterior",
                    "sNext": "Seguinte",
                    "sLast": "Último"
                }
            }
        });
    }

    if ($(".dataD").length > 0) {
        var oTable = $('.dataD').DataTable({
            language: {
                "sProcessing": "A processar...",
                "sLengthMenu": "Mostrar _MENU_ registos",
                "sZeroRecords": "Não foram encontrados resultados",
                "sInfo": "A mostrar _START_ - _END_ de _TOTAL_ registos",
                "sInfoEmpty": "0 registos",
                "sInfoFiltered": "(filtrado de _MAX_ registos no total)",
                "sInfoPostFix": "",
                "sSearch": "Procurar:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "Primeiro",
                    "sPrevious": "Anterior",
                    "sNext": "Seguinte",
                    "sLast": "Último"
                }
            },
            "order": [[2, "desc"]]
        });
    }

    if ($(".input-group.date").length > 0) {
        $('.input-group.date').datepicker({
            todayBtn: "linked",
            keyboardNavigation: false,
            forceParse: false,
            calendarWeeks: true,
            autoclose: true
        });
    }
    $grid = $('.grid');
    $grid.masonry({
        // options
        itemSelector: '.grid-item',
        columnWidth: 400
    });

    if ($(".homepage").length > 0) {

        /*  **********************************************************
         *   ESTATISTICAS
         *   Pintar os gráficos com os valores calc em stats_functions 
         *   **********************************************************
         * */
        /*beneficiarios*/
        $(function () {
            var data = [];

            $.ajax({
                type: "POST",
                url: "../functions/stats_functions.php", // server path to send data
                dataType: "json",
                data: {functionname: 'getSumPeople'},

                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    alert(thrownError);
                },
                success: function (obj) {

                    $(obj).each(function (index, value) {
                        var array = {};
                        array.labels = value.month;
                        array.data = value.countVol;
                        array.year = value.year; //isto há de servir para o filtro ano

                        data.push(array);
                    });
                    //console.log(data);

                    var lineData = {
                        // labels: data.map(function (a) {
                        //     return a.labels;
                        // }),
                        type: 'line',
                        data: {
                            labels: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
                            datasets: [
                                {
                                    backgroundColor: "rgba(28,132,198,0.5)",
                                    borderColor: "rgba(28,132,198,1)",
                                    borderWidth: 2,
                                    pointBorderColor: "#fff",
                                    pointHighlightFill: "#fff",
                                    pointBorderWidth: 1,
                                    pointRadius: 4,
                                    pointHitRadius: 20,
                                    lineTension: 0.4,
                                    pointHighlightStroke: "rgba(28,132,198,1)",
                                    data: data.map(function (a) {
                                        return a.data;
                                        //data: [65, 60, 40, 50, 35, 25, 60, 40, 50, 35, 25, 40, 41]
                                    })
                                }
                            ]
                        },
                        options: {
                            legend: {
                                display: false
                            },
                            responsive: true,
                            scales: {
                                xAxes: [{
                                    gridLines: {
                                        lineWidth: 1,
                                        color: "rgba(0,0,0,.05)"
                                    },
                                    scaleLabel: {
                                        display: true,
                                        labelString: "Mês",
                                        fontStyle: "bold"
                                    }
                                }],
                                yAxes: [{
                                    gridLines: {
                                        lineWidth: 1,
                                        color: "rgba(0,0,0,.05)"
                                    },
                                    scaleLabel: {
                                        display: true,
                                        labelString: "Nº de Voluntários",
                                        fontStyle: "bold"
                                    }
                                }]
                            },
                            tooltips: {
                                xPadding: 20,
                                yPadding: 3,
                                titleSpacing: 2,
                                xAlign: 'center',
                                custom: function (data) {
                                    if (data.title) {
                                        data.title[0] += data.body[0].lines[0];
                                        data.body[0].lines[0] = '';
                                    }
                                }
                            }
                        }
                    };
                    var ctx = document.getElementById("lineChart").getContext("2d");
                    var myNewChart = new Chart(ctx, lineData);
                }
            });
        });


        /*produtos*/
        $(function () {
            var data = [];

            $.ajax({
                type: "POST",
                url: "../functions/stats_functions.php", // server path to send data
                dataType: "json",
                data: {functionname: 'getSumProducts'},

                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    alert(thrownError);
                },
                success: function (obj) {

                    $(obj).each(function (index, value) {
                        var array = {};
                        array.labels = value.month;
                        array.data = value.sum;
                        array.year = value.year; //isto há de servir para o filtro ano

                        data.push(array);
                    });

                    var lineDataProducts = {
                        // labels: data.map(function (a) {
                        //     return a.labels;
                        // }),
                        type: 'line',
                        data: {
                            labels: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
                            datasets: [
                                {
                                    backgroundColor: "rgba(28,132,198,0.5)",
                                    borderColor: "rgba(28,132,198,1)",
                                    borderWidth: 2,
                                    pointBorderColor: "#fff",
                                    pointHighlightFill: "#fff",
                                    pointBorderWidth: 1,
                                    pointRadius: 4,
                                    pointHitRadius: 20,
                                    lineTension: 0.4,
                                    pointHighlightStroke: "rgba(28,132,198,1)",
                                    data: data.map(function (a) {
                                        return a.data;
                                    })
                                }
                            ]
                        },
                        options: {
                            legend: {
                                display: false
                            },
                            responsive: true,
                            scales: {
                                xAxes: [{
                                    gridLines: {
                                        lineWidth: 1,
                                        color: "rgba(0,0,0,.05)"
                                    },
                                    scaleLabel: {
                                        display: true,
                                        labelString: "Mês",
                                        fontStyle: "bold"
                                    }
                                }],
                                yAxes: [{
                                    gridLines: {
                                        lineWidth: 1,
                                        color: "rgba(0,0,0,.05)"
                                    },
                                    scaleLabel: {
                                        display: true,
                                        labelString: "Peso Total (Kg)",
                                        fontStyle: "bold"
                                    }
                                }]
                            },
                            tooltips: {
                                xPadding: 20,
                                yPadding: 3,
                                custom: function (data) {
                                    if (data.title) {
                                        data.title[0] += data.body[0].lines[0];
                                        data.body[0].lines[0] = '';
                                    }
                                }
                            }
                        }
                    };
                    //console.log(lineDataProducts);
                    var ctp = document.getElementById("statProdutos").getContext("2d");
                    var myNewChartProducts = new Chart(ctp, lineDataProducts);
                }
            });
        });

        $(function () {
            var data = [];
            var color = ["#d5d3d3", "#bababa", "#79d2c0", "#1ab394", "#00b370"];

            $.ajax({
                type: "POST",
                url: "../functions/stats_functions.php", // server path to send data
                dataType: "json",
                data: {functionname: 'getTopSources'},

                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    alert(thrownError);
                },
                success: function (obj) {

                    $(obj).each(function (index, value) {
                        var array = {};
                        array.label = value.code;
                        array.data = value.percentage;
                        array.color = color[index];
                        data.push(array);
                    });
                    //console.log(data);
                    var plotObj = $.plot($("#flot-pie-chart"), data, {
                        series: {
                            pie: {
                                show: true
                            }
                        },
                        grid: {
                            hoverable: true
                        },
                        tooltip: true,
                        tooltipOpts: {
                            content: "%p.0%, %s", // show percentages, rounding to 2 decimal places
                            shifts: {
                                x: 20,
                                y: 0
                            },
                            defaultTheme: false
                        }
                    });
                }
            });

        });
    }
});

/*  **********************************************************
 *   BUTTON LOAD MORE SCRIPT
 *   Quando o butão loadMore e clicado envia (n) clicks
 *   via AJAX.
 *   **********************************************************
 * */
if ($(".js-voluntarios").length > 0 || $(".js-lista-refood").length > 0) {

    $(function () {

        var count = 1, // Clicks counter
            $loadButton = $(".load-more"); // load more button

        if (window.XMLHttpRequest) {
            xml = new XMLHttpRequest();
        } else {  // code for IE6, IE5
            xml = new ActiveXObject("Microsoft.XMLHTTP");
        }

        xml.onreadystatechange = function () {
            if (xml.readyState == 4 && xml.status == 200) {
                $grid.masonry('destroy');
                document.getElementById("livesearch").innerHTML = xml.responseText;
                $grid = $('.grid');
                $grid.masonry({
                    // options
                    itemSelector: '.grid-item',
                    columnWidth: 400
                });
                $grid.masonry('reloadItems');
                $grid.masonry('layout');
            }
            getCount(num, $(".grid-item").length);
        };

        $loadButton.click(function () {
            var namePage = $(this).attr("name");
            var search = document.getElementById("caixaPesquisa").value;
            xml.open("GET", "../../functions/funcoes_aux.php?" + namePage + "=" + count + "&search=" + search, true);
            xml.send();
            // Scroll effect
            $("html, body").animate({scrollTop: $("#js-loadMore").offset().top}, 500);
            num += 6;
            count++;
        });


        function getCount(num, num_actual) {

            if (num_actual < num) {
                $loadButton.hide();
            }
            else {
                $loadButton.show();
            }
        }
    });
}

/*  **********************************************************
 *   SELECT SEARCH SCRIPT
 *   Recebe dados do lado do servidor consoante os dados
 *   introduzidos no input pelo utilizador.
 *
 *
 *   NOTA: Este script espera que browser faça o load de todos
 *   os elementos(rendering inclusive) da pagina. Só depois
 *   é que é executado.
 *   **********************************************************
 * */
if ($(".js-nova-refood").length > 0 || $(".js-nova-rota").length > 0 || $(".js-rotas").length > 0 || $(".js-editar-refood").length > 0) {

    $(window).load(function () {
        // Cache selector

        var $selectNames = $("#nomeResponsavel"); // Selector wrapper option elements
        var $ajudantes = $("#ajudantes");

        $('.bs-searchbox input').keyup(function () {

            var $textInput = $(this).val(); // Text inside input element

            checkInput($textInput);
        });

        function getNames(names) {
            // Sempre que a função é chamada limpa os resultados <option> presentes no DOM da pagina
            removeOptions();

            // Get the name values via AJAX (JSON)
            $.ajax({
                type: "POST",
                url: "../functions/funcoes_aux.php", // server path to send data
                dataType: "json",
                data: {functionname: 'getVoluntarios', arguments: [names]},
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    alert(thrownError);
                },
                success: function (names) {
                    showNames(names);
                }
            });

        }

        function showNames(names) {
            // Populate new options inside the select wrapper
            $.each(names, function (index, name) {
                var
                    namePerson = names[index].name,
                    idPerson = names[index].id;

                $("<option></option>")
                    .text(namePerson)
                    .attr("value", idPerson)
                    .appendTo($selectNames);
            });

            // [WARNING]
            // selectpicker method, refresh the options list with the new added data.
            // If selectpicker method doesnt find any option inside the selector
            // throws an error in console like this
            // [Uncaught TypeError: Cannot read property 'not' of null]
            $selectNames.selectpicker('refresh');
        }

        // Remove <option> elements in page
        function removeOptions() {
            $selectNames.find("option").remove();
        }

        // Verify text inside input element
        function checkInput(text) {
            if (text.length >= 2) {
                getNames(text);
            }
        }
    });
}

/*  **********************************************************
 *   STEPS SCRIPT
 *   some info about this sript
 *   **********************************************************
 * */
if ($(".js-nova-rota").length > 0) {

    $(function () {
        $("#wizard").steps();
        $("#form_registarRota").steps({
            bodyTag: "fieldset",
            onStepChanging: function (event, currentIndex, newIndex) {
                // Always allow going backward even if the current step contains invalid fields!
                if (currentIndex > newIndex) {
                    return true;
                }

                // Forbid suppressing "Warning" step if the user is to young
                if (newIndex === 3 && Number($("#age").val()) < 18) {
                    return false;
                }

                var form = $(this);

                // Clean up if user went backward before
                if (currentIndex < newIndex) {
                    // To remove error styles
                    $(".body:eq(" + newIndex + ") label.error", form).remove();
                    $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
                }

                // Disable validation on fields that are disabled or hidden.
                form.validate().settings.ignore = ":disabled,:hidden";

                // Start validation; Prevent going forward if false
                return form.valid();
            },
            onStepChanged: function (event, currentIndex, priorIndex) {
                // Suppress (skip) "Warning" step if the user is old enough.
                if (currentIndex === 2 && Number($("#age").val()) >= 18) {
                    $(this).steps("next");
                }

                // Suppress (skip) "Warning" step if the user is old enough and wants to the previous step.
                if (currentIndex === 2 && priorIndex === 3) {
                    $(this).steps("previous");
                }
            },
            onFinishing: function (event, currentIndex) {
                var form = $(this);

                // Disable validation on fields that are disabled.
                // At this point its recommended to do an overall check (mean ignoring only disabled fields)
                //form.validate().settings.ignore = ":disabled";

                // Start validation; Prevent form submission if false
                return form.valid();
            },
            onFinished: function (event, currentIndex) {
                var form = $(this);

                // Submit form input
                //form.submit();
                validateForm('form_registarRota', 'rota', 'Rota inserida com sucesso');
            },
            labels: {
                cancel: "Cancelar",
                current: "Passo:",
                pagination: "Pagination",
                finish: "Concluir",
                next: "Próximo",
                previous: "Anterior",
                loading: "Carregando ..."
            }
        }).validate({
            errorPlacement: function (error, element) {
                element.before(error);
            },
            rules: {
                confirm: {
                    equalTo: "#password"
                }
            }
        });
    });

}

/*  ******************************************************************
 *                  ## PAGE ROTAS SCRIPTS ##
 *
 *   #1 CALENDAR SCRIPT
 *   O plugin calendario é inicializado aqui
 *
 *   Info:
 *      # Este script permite criar um calendario dinamico na pagina.
 *      # .......
 *
 *   #2 TaskCalendar SCRIPT
 *   O script TaskCalendar é inicializado aqui
 *
 *   Info:
 *      # Esta objeto permite integrar com o calendario
 *      # .........
 *
 *   ******************************************************************
 * */

if ($(".js-rotas").length > 0) {

    // #1 CALENDAR
    $(function () {
        // Instance of object type Calendar
        var cal = new Calendar();
        // Initialize calendar
        cal.init();
    });


    // #2 TaskCalendar
    $(window).load(function () {
        var rotas = TaskCalendar("#js-taskCalendar");

    });
}


var num = 6;

function showResult(str, page) {
    if (window.XMLHttpRequest) {
        xmlhttp = new XMLHttpRequest();
    } else {  // code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            $grid.masonry('destroy');
            document.getElementById("livesearch").innerHTML = xmlhttp.responseText;
            $grid = $('.grid');
            $grid.masonry({
                // options
                itemSelector: '.grid-item',
                columnWidth: 400
            });
            $grid.masonry('reloadItems');
            $grid.masonry('layout');

            num = 6;
            if (($(".grid-item").length >= 6)) {
                $("#js-loadMore").show();
            } else {
                $("#js-loadMore").hide();
            }
        }
    };
    xmlhttp.open("GET", "../../functions/funcoes_aux.php?" + page + "=" + str, true);
    xmlhttp.send();
}

function guardarImagem(paginaAIr) {
    var formData = new FormData($('form_registarVoluntario')[0]);

    $.post("../../functions/" + paginaAIr + ".php", formData, function (data) {
        alert(data);
    });
    //console.log(formData);
}

// Handle erros formulario
function validateForm(form, paginaAIr, mensagem) {
    var x = $('#' + form);
    var erro = false;
    var pass1;

    var formData = new FormData();
    if (x.find('#fotografia').length > 0) {
        formData.append("img", x.find('#fotografia')[0].files[0]);
    }

    $.each(x.serializeArray(), function (i, field) {

        if (field.name == 'password') {
            pass1 = field.value;
        }

        if (field.name == 'cpassword' && field.value != pass1) {
            sendMsg('As palavras-passe têm de coincidir!');
            erro = true;
            return false;
        }
        if (field.value == '' && $("#" + field.name).prop("required")) {
            var label = $("label[for='" + field.name + "']")[0].innerText;

            sendMsg('O campo "' + label + '" não pode estar vazio');
            erro = true;
            return false;
        }

        formData.append(field.name, field.value);

    });

    //formData.append("form", x.serialize());

    if (!erro) {
        $.ajax({
            url: "../../functions/" + paginaAIr + ".php",
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                dadosUser = JSON.parse(data);
                console.log(data);
                if (dadosUser['paginaAIr'] != '' && dadosUser['erro'] == '') {
                    swal({
                        title: "",
                        //text: "Inserido com sucesso !",
                        text: mensagem,
                        type: "success",
                        showCancelButton: false,
                        confirmButtonColor: "#fdc23e",
                        confirmButtonText: "Ok",
                        closeOnConfirm: false
                    });
                    $('.confirm').click(function () {
                        window.location = dadosUser['paginaAIr'];
                    });
                }
                else {
                    sendMsg(dadosUser['erro']);
                }
            }
        });


        // $.post("../../functions/" + paginaAIr + ".php", formData, function (data) {
        //     dadosUser = JSON.parse(data);
        //
        //     if (dadosUser['paginaAIr'] != '' && dadosUser['erro'] == '') {
        //         swal({
        //             title: "",
        //             //text: "Inserido com sucesso !",
        //             text: mensagem,
        //             type: "success",
        //             showCancelButton: false,
        //             confirmButtonColor: "#fdc23e",
        //             confirmButtonText: "Ok",
        //             closeOnConfirm: false
        //         });
        //         $('.confirm').click(function () {
        //             window.location = dadosUser['paginaAIr'];
        //         });
        //     }
        //     else {
        //         sendMsg(dadosUser['erro']);
        //     }
        // });
    }
}

function sendMsg(str, form) {
    $('html', form).animate({scrollTop: 0}, 800);
    $("span.msg").text(str);
    $("#mensagemErro").fadeIn("slow");
}

// Apagar registo
function confirmDelete(idRow, paginaAIr) {

    swal({
            title: "",
            text: "Tem a certeza que quer eliminar este registo?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Confirmar",
            closeOnConfirm: false
        },
        function (isConfirm) {
            if (isConfirm) {
                $.post("../../functions/" + paginaAIr + ".php", {"id": idRow}, function (data) {
                    dadosUser = JSON.parse(data);
                    swal({
                        title: "",
                        text: "Eliminado com sucesso",
                        type: "success",
                        showCancelButton: false,
                        confirmButtonColor: "#fdc23e",
                        confirmButtonText: "Ok",
                        closeOnConfirm: false
                    });
                    $('.confirm').click(function () {
                        window.location = dadosUser['paginaAIr'];
                    });
                });
                return true;

            } else {
                return false;
            }
        });

}

function buttonLoadMore(hide) {
    var loadButton = $(".load-more");
    if (hide) {
        loadButton.hide();
    }
    else {
        if (!loadButton.is(":visible")) {
            loadButton.show();
        }
    }
}

function goBack() {
    window.history.back();
}

/*
 *   # dadosPOPUP
 *       Função responsavel por enviar id associado ao percurso do voluntario
 *
 * */

function dadosPOPUP(idPercurso) {
    $.ajax({
        type: "POST",
        url: "../functions/funcoes_aux.php", // server path to send data
        dataType: "json",
        data: {functionname: 'getPercurso', arguments: idPercurso},

        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert(thrownError);
        },
        success: function (obj) {
            $("#portugal").append(obj.pagina);
            $("#myModal1").modal();
            xpto();
        }
    });
}

//todo criar um objeto do selectpicker
function xpto() {
    var $selectNames = $("#nomeResponsavel"); // Selector wrapper option elements

    $('.selectpicker').selectpicker('refresh');
    $("#ajudantes").chosen();
    $('.bs-searchbox input').keyup(function () {

        var $textInput = $(this).val(); // Text inside input element

        checkInput($textInput);
    });

    function getNames(names) {
        // Sempre que a função é chamada limpa os resultados <option> presentes no DOM da pagina
        removeOptions();

        // Get the name values via AJAX (JSON)
        $.ajax({
            type: "POST",
            url: "../functions/funcoes_aux.php", // server path to send data
            dataType: "json",
            data: {functionname: 'getVoluntarios', arguments: [names]},
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.responseText);
                alert(thrownError);
            },
            success: function (names) {
                showNames(names);
            }
        });

    }

    function showNames(names) {
        // Populate new options inside the select wrapper
        $.each(names, function (index, name) {
            var
                namePerson = names[index].name,
                idPerson = names[index].id;

            $("<option></option>")
                .text(namePerson)
                .attr("value", idPerson)
                .appendTo($selectNames);
        });

        // [WARNING]
        // selectpicker method, refresh the options list with the new added data.
        // If selectpicker method doesnt find any option inside the selector
        // throws an error in console like this
        // [Uncaught TypeError: Cannot read property 'not' of null]
        $selectNames.selectpicker('refresh');
    }

    // Remove <option> elements in page
    function removeOptions() {
        $selectNames.find("option").remove();
    }

    // Verify text inside input element
    function checkInput(text) {
        if (text.length >= 2) {
            getNames(text);
        }
    }
}