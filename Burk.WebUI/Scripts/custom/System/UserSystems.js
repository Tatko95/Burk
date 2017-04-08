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
                    text: '', datafield: 'Work', columntype: 'button', width: 30, cellsrenderer: function () {
                        return '<div style="width: 100%; height: 100%"><img src="/../Content/JQWidgets/images/search.png" style="margin-left: -7px; margin-top: -18px"/></div>';
                    }
                },
                {
                    text: '', datafield: 'Edit', columntype: 'button', width: 30, cellsrenderer: function () {
                        return '<div style="width: 100%; height: 100%"><img src="/../Content/JQWidgets/images/icon-edit.png" style="margin-left: -12px; margin-top: -18px"/></div>';
                    }
                },
                {
                    text: '', datafield: 'Settings', columntype: 'button', width: 30, cellsrenderer: function () {
                        return '<div style="width: 100%; height: 100%"><img src="/../Content/JQWidgets/images/icon-settings.png" style="margin-left: -8px; margin-top: -18px"/></div>';
                    }
                },
                { text: localization.FullName, datafield: 'FullName', cellsrenderer: cellsrenderer, align: 'center', width: 350 },
                { text: localization.ShortName, datafield: 'ShortName', cellsrenderer: cellsrenderer, align: 'center', width: 350 },
                {
                    text: '', datafield: 'Delete', columntype: 'button', width: 30, cellsrenderer: function () {
                        return '<div style="width: 100%; height: 100%"><img src="/../Content/JQWidgets/images/icon-delete.png" style="margin-left: -9px; margin-top: -18px"/></div>';
                    }
                },
            ],
        });

    $("#jqxgrid").on("cellclick", function (event) {
        var rowindex = event.args.rowindex;
        var columnindex = event.args.columnindex;
        var systemId = $("#jqxgrid").jqxGrid('getrowid', rowindex);
        if (columnindex == 1) {
            window.location.href = "/Work/Index?systemId=" + systemId;
        }
        if (columnindex == 2) {
            AddEdit(systemId);
        }
        if (columnindex == 3) {
            window.location.href = "/SettingSystem/Index?systemId=" + systemId;
        }
        if (columnindex == 6) {
            Delete(systemId);
        }
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
                height: 'auto',
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
    ShowBlockUI();
    $.ajax({
        url: '/System/Delete/',
        data: { systemId: objKey },
        success: function (text) {
            if (text === "Deleted") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDeletedDiv", localization.Deleted, function () { $("#jqxgrid").jqxGrid('updatebounddata'); });
            }
            else if (text === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}