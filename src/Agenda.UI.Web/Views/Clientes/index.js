var table = null;
buildDatatable();

function buildDatatable() {

    if (table)
        table.destroy();

    table = $("#dataTable").DataTable({
        processing: true,
        ajax: {
            url: baseUrl('Clientes/GridView'),
            type: "POST",
            dataSrc: 'GridView',
            dataFilter: function (data) {
                var json = JSON.parse(data);

                json.recordsTotal = json.TotalDeRegistros;
                json.recordsFiltered = json.TotalDeRegistros;
                json.data = json.GridView;

                return JSON.stringify(json);
            },
            data: function (data, settings) {
                return {
                    TipoPesquisa: TipoPesquisa,
                    ValorPesquisa: ValorPesquisa,
                    IndiceDePagina: data.start / data.length + 1,
                    RegistrosPorPagina: data.length,
                    Ordenacao: data.order[0].dir,
                    Coluna: data.columns[data.order[0].column].data
                };
            }
        },
        columnDefs: [
            {
                targets: -1,
                data: 'ClienteId',
                render: function (data, type, full, meta) {
                    var editar = baseUrl(thisController+'/Editar/' + data);
                    var atosAutorizacao = baseUrl('AtosAutorizacao/Index/' + data);
                    var btnEditar = '<a class="btn btn-info fa fa-pencil-square-o" data-toggle="tooltip" title="Alterar" href="' + editar + '"></a> ';
                    var btnAtosAutorizacao = '<a class="btn btn-primary fa fa-plus-square" data-toggle="tooltip" title=" Atos de Autorização" href="' + atosAutorizacao + '"></a> ';

                    return btnEditar + btnAtosAutorizacao;
                },
            }
        ],
        columns: [
            { data: 'ClienteId' },
            { data: 'CodigoMec' },
            { data: 'DependenciaAdministrativa' },
            { data: 'Nome' },
            { data: 'Sigla', class: 'text-center' },
            { data: 'Id' },

        ],
    });
}