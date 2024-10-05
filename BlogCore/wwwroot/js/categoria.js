var dataTable;

$(document).ready();

$(document).ready(function () {
    cargarDatatable();
});

function CargarDatatable() {
    dataTable = $("#tblCategorias").dataTable({
        "ajax": {
            "url": "/admin/categorias/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" }
            { "data": "nombre", "width": "50%" }
            { "data": "orden", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> <a href="/Admin/Categorias/Edit/{data}"`;
                }
            }

        ]

    }); 
}