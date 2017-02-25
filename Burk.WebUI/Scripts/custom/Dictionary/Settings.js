var dictionaryId = 0;

$(document).ready(function () {
    InitGridDictionaries();
    InitGridValues();
});

function InitGridDictionaries() {
    $("#jqxgridDictionaries").jqxGrid(
        {
            width: 835,
            height: 346,
            localization: getLocalization(UICulture),
            source: {
                datatype: "json",
                datafields: [
                    { name: 'FullName', type: 'string' },
                    { name: 'ShortName', type: 'string' },
                    { name: 'DictionaryId', type: 'int' },
                ],
                id: 'DictionaryId',
                url: URLGridDictionaries,
                data: { systemId: $('#SystemId').val() },
                sortcolumn: 'DictionaryId',
                sortdirection: 'desc',
                loadComplete: function (data) {
                    $("#valuesDiv").hide();
                },
            },
            theme: "boostrap",
            pageable: true,
            sortable: true,
            columnsresize: true,
            columns: [
                { datafield: 'DictionaryId', hidden: true },
                {
                    text: '', datafield: 'Edit', columntype: 'button', width: 30, cellsrenderer: function () {
                        return '<div style="width: 100%; height: 100%"><img src="/../Content/JQWidgets/images/icon-edit.png" style="margin-left: -12px; margin-top: -18px"/></div>';
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

    $("#jqxgridDictionaries").on("cellclick", function (event) {
        var rowindex = event.args.rowindex;
        var columnindex = event.args.columnindex;
        dictionaryId = $("#jqxgridDictionaries").jqxGrid('getrowid', rowindex);
        if (columnindex == 1) {
            AddEditDictionary();
        }
        else if (columnindex == 4) {
            DeleteDictionary();
        }
        else {
            var tmpS = $("#jqxgridValues").jqxGrid('source');
            tmpS._source.data = { dictionaryId: dictionaryId };
            $("#jqxgridValues").jqxGrid('source', tmpS);

            $("#jqxgridValues").jqxGrid('updatebounddata');

            $('#valuesDiv').show();
        }
    });
}

function AddEditDictionary(isNew) {
    dictionaryId = isNew ? 0 : dictionaryId;
    $.ajax({
        url: '/Dictionary/AddEditDictionary/',
        type: 'GET',
        data: { dictionaryId: dictionaryId },
        success: function (result) {
            $("#addEditDictionary").html(result).dialog({
                width: 220,
                height: 220,
                resizable: false,
                modal: true,
                show: { effect: "drop", direction: "left" },
                hide: { effect: "drop", direction: "left" },
                title: dictionaryId == null ? localization.CreateNew : localization.Edit,
                closeOnEscape: true,
                close: function () {
                    $(this).dialog('destroy').html("");
                }
            });
        }
    });
}

function DeleteDictionary() {
    ShowBlockUI();
    $.ajax({
        url: '/Dictionary/DeleteDictionary/',
        data: { dictionaryId: dictionaryId },
        success: function (text) {
            if (text === "Success") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDiv", localization.Deleted, function () { $("#jqxgridDictionaries").jqxGrid('updatebounddata'); });
            }
            else if (text === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}

function InitGridValues() {
    $("#jqxgridValues").jqxGrid(
        {
            width: 835,
            height: 346,
            localization: getLocalization(UICulture),
            source: {
                datatype: "json",
                datafields: [
                    { name: 'FullName', type: 'string' },
                    { name: 'ShortName', type: 'string' },
                    { name: 'DicValueId', type: 'int' },
                ],
                id: 'DicValueId',
                url: URLGridValues,
                data: { dictionaryId: dictionaryId },
                sortcolumn: 'DicValueId',
                sortdirection: 'desc',
                loadComplete: function (data) {
                },
            },
            theme: "boostrap",
            pageable: true,
            sortable: true,
            columnsresize: true,
            columns: [
                { datafield: 'DicValueId', hidden: true },
                {
                    text: '', datafield: 'Edit', columntype: 'button', width: 30, cellsrenderer: function () {
                        return '<div style="width: 100%; height: 100%"><img src="/../Content/JQWidgets/images/icon-edit.png" style="margin-left: -12px; margin-top: -18px"/></div>';
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

    $("#jqxgridValues").on("cellclick", function (event) {
        var rowindex = event.args.rowindex;
        var columnindex = event.args.columnindex;
        var dicValueId = $("#jqxgridValues").jqxGrid('getrowid', rowindex);
        if (columnindex == 1) {
            AddEditValue(dicValueId);
        }
        else if (columnindex == 4) {
            DeleteValue(dicValueId);
        }
    });
}

function AddEditValue(valueId) {
    $.ajax({
        url: '/Dictionary/AddEditValue/',
        type: 'GET',
        data: { valueId: valueId, dictionaryId: dictionaryId },
        success: function (result) {
            $("#AddEditDiv").html(result).dialog({
                width: 220,
                height: 220,
                resizable: false,
                modal: true,
                show: { effect: "drop", direction: "left" },
                hide: { effect: "drop", direction: "left" },
                title: valueId == null ? localization.CreateNew : localization.Edit,
                closeOnEscape: true,
                close: function () {
                    $(this).dialog('destroy').html("");
                }
            });
        }
    });
}

function DeleteValue(objKey) {
    ShowBlockUI();
    $.ajax({
        url: '/Dictionary/DeleteValue/',
        data: { valueId: objKey },
        success: function (text) {
            if (text === "Success") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDiv", localization.Deleted, function () { $("#jqxgridValues").jqxGrid('updatebounddata'); });
            }
            else if (text === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}