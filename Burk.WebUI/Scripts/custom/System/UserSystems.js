$(document).ready(function () {
    InitGrid();
});

function InitGrid() {
    $("#jqxgrid").jqxGrid(
        {
            width: 835,
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
                sortcolumn: 'SystemId',
                sortdirection: 'desc',
                loadComplete: function (data) { },
            },
            theme: "boostrap",
            pageable: true,
            sortable: true,
            columnsresize: true,
            columns: [
                { datafield: 'SystemId', hidden: true },
                {
                    text: '', datafield: 'Edit', columntype: 'button', width: 110, cellsrenderer: function () {
                        return localization.Edit;
                    }, buttonclick: function (row) {
                        var systemId = $("#jqxgrid").jqxGrid('getrowid', row);
                        AddEdit(systemId);
                    }
                },
                { text: localization.FullName, datafield: 'FullName', cellsrenderer: cellsrenderer, align: 'center', width: 350 },
                { text: localization.ShortName, datafield: 'ShortName', cellsrenderer: cellsrenderer, align: 'center', width: 350 },
                {
                    text: '', datafield: 'Delete', columntype: 'button', width: 19, cellsrenderer: function () {
                        return "x";
                    }, buttonclick: function (row) {
                        var systemId = $("#jqxgrid").jqxGrid('getrowid', row);
                        Delete(systemId);
                    }
                },
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
                title: objKey == null ? localization.CreateNew : localization.Edit,
                closeOnEscape: true,
                close: function () {
                    $(this).dialog('destroy').html("");
                }
            });
        }
    });
}

function Delete(objKey) {
    $.ajax({
        url: '/System/Delete/',
        data: { systemId: objKey },
        success: function (text) {
            if (text === "Deleted") {
                ShowMessageBox(1, "SuccessDeletedDiv", localization.Deleted, function () { $("#jqxgrid").jqxGrid('updatebounddata'); });
            }
            else if (text === "Error") {
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}