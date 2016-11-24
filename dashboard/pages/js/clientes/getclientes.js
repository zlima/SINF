$( document ).ready(function() {
    
  $('#datatable-responsive').DataTable({
        "processing" : true,
        "ajax" : {
            "url" : "http://localhost:49822/api/Clientes",
            dataSrc : ''
        },
        "columns" : [ {
            "data" : "CodCliente"
        }, {
            "data" : "NomeCliente"
        }, {
            "data" : "NumContribuinte"
        }, {
            "data" : "Morada"
        },
        {
        	"data" : "Pais"
        },
        {
        	"data" : "Moeda"
        }]
    });

});