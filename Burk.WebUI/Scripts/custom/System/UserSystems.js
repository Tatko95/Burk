$(document).ready(function () {
    InitGrid();
});

function InitGrid() {
    $("#jqxgrid").jqxGrid(
        {
            width: 700,
            height: 346,
            localization: getLocalization(UICulture),
            source: {
                datatype: "json",
                datafields: [
                    { name: 'FullName', type: 'string' },
                    { name: 'ShortName', type: 'string' },
                    { name: 'SystemId', type: 'int' },
                ],
                id: 'SystemId',
                url: URLGrid,
                loadComplete: function (data) { },
            },
            theme: "boostrap",
            pageable: true,
            sortable: true,
            columnsresize: true,
            columns: [
                { datafield: 'SystemId', hidden: true },
                { text: localization.FullName, datafield: 'FullName', cellsrenderer: cellsrenderer, align: 'center', width: 350 },
                { text: localization.ShortName, datafield: 'ShortName', cellsrenderer: cellsrenderer, align: 'center', width: 350 }
            ],
        });
}

function AddEdit(objKey) {
    $.ajax({
        url: '/System/AddEdit/',
        type: 'GET',
        data: { systemId: objKey },
        success: function (result) {
            $("#addEditDialog").html(result).dialog({
                width: 220,
                height: 220,
                resizable: false,
                modal: true,
                show: { effect: "drop", direction: "left" },
                hide: { effect: "drop", direction: "left" },
                title: objKey == null ? "Create new" : "Edit",
                closeOnEscape: true,
                close: function () {
                    $(this).dialog('destroy').html("");
                }
            });
        }
    });
}