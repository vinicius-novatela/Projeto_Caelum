
$(document).ready(function ($) {


<<<<<<< HEAD
    
        $('input[name="Categoria"]').autocomplete({ //auto complete campo input categoria
            source: function (request, response) {
=======
    $('input[name="Categoria"]').ajaxComplete({ //auto complete campo input categoria
        source: function (request, response) {
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d
            $.post(
                "@Url.Action('CategoriaAutoComplete')",
                { term: request.term },
                function (data) {
                    Response(data);
                });
        },
    });

    $('#post').validate({
        rules: {
            Titulo: {
                required: true,
                maxlength :20
            },
            Resumo: {
                required: true,
                maxlength: 20
            },
            Categoria:{
                required: true,
                maxlength: 20
            },

            messages: {
                Titulo: {
                   maxlength:"Máximo 20 caracteres"
                },
                Resumo: {                   
                   maxlength: "Máximo 20 caracteres"
                },
                Categoria: {                  
                   maxlength: "Máximo 20 caracteres"
                },

            }
        },
    });//fim validate

    function Eventos() {      
    }
});//fim ready()