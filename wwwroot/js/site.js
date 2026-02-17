let table = new DataTable('#table-contatos',{
    ordering: true,
        paging: true,
        searching: true,
        language: {
        emptyTable: "Nenhum registro encontrado na tabela",
            info: "Mostrar _START_ até _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrar 0 até 0 de 0 Registros",
            infoFiltered: "(Filtrar de _MAX_ total registros)",
            thousands: ".",
            lengthMenu: "Mostrar _MENU_ registros por pagina",
            loadingRecords: "Carregando...",
            processing: "Processando...",
            zeroRecords: "Nenhum registro encontrado",
            search: "Pesquisar",
            paginate: {
            next: "Proximo",
                previous: "Anterior",
                first: "Primeiro",
                last: "Ultimo"
        },
        aria: {
            sortAscending: ": Ordenar colunas de forma ascendente",
                sortDescending: ": Ordenar colunas de forma descendente"
        }
    }
});



$('.close-alert').click(function(){
    $('.alert').hide('hide')
})
