$(document).ready(function () {
    LoadInsetMenu();
    if ($('#IsWork').val() == "False") {
        $("#jqxMenuInset").on('itemclick', function (event) {
            insetId = event.args.id / 10000 >> 0;
            if (event.args.id == 0) {
                AddEditInsetItem(event.args.id);
            }
            else if (event.args.id > 10000 && event.args.id % 10 == 1) {
                AddEditInsetItem(insetId);
            }
            else if (event.args.id > 10000 && event.args.id % 10 == 2) {
                DeleteInsetItem(insetId);
            }
            else if (event.args.id > 10000 && event.args.id % 10 == 3) {
                LeftInsetItem(insetId);
            }
            else if (event.args.id > 10000 && event.args.id % 10 == 4) {
                RightInsetItem(insetId);
            }
            else {
                window.location.href = "/SettingSystem/Index?systemId=" + $('#SystemId').val() + "&dossierId=" + $('#DossierId').val() + "&insetId=" + event.args.id;
            }
        });
    }
    else {
        if ($('#IsCreate').val() == "True") {
            $('#jqxMenuInset').hide();
        }
        else {
            $("#jqxMenuInset").on('itemclick', function (event) {
                window.location.href = '/Work/AddEditObj?systemId=' + $('#SystemId').val() + '&dossierId=' + $('#DossierId').val() + "&mainListId=" + $('#MainListId').val() + "&insetId=" + event.args.id;
                //window.location.href = "/SettingSystem/Index?systemId=" + $('#SystemId').val() + "&dossierId=" + $('#DossierId').val() + "&insetId=" + event.args.id;
            });
        }
    }
});

function LoadInsetMenu() {
    //ShowBlockUI();
    var URL = $('#IsWork').val() == "True" ? '/Inset/GetInsetItem/' : '/Inset/GetInsetItemForSettings/';
    $.ajax({
        url: URL,
        type: 'GET',
        data: { dossierId: $("#DossierId").val() },
        success: function (result) {
            var data = result;
            var source =
            {
                datatype: "json",
                datafields: [
                    { name: 'id' },
                    { name: 'parentid' },
                    { name: 'text' },
                    { name: 'subMenuWidth' }
                ],
                id: 'id',
                localdata: data
            };

            var dataAdapter = new $.jqx.dataAdapter(source);
            dataAdapter.dataBind();
            var records = dataAdapter.getRecordsHierarchy('id', 'parentid', 'items', [{ name: 'text', map: 'label' }]);

            $("#jqxMenuInset").jqxMenu({ source: records, width: 'auto' });
            //UnblockUI();
        }
    });
}

function AddEditInsetItem(objKey) {
    $.ajax({
        url: '/Inset/AddEditInsetItem/',
        type: 'GET',
        data: { insetId: objKey },
        success: function (result) {
            $("#addEditInsetDialog").html(result).dialog({
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

function DeleteInsetItem(objKey) {
    $.ajax({
        url: '/Inset/DeleteInsetItem/',
        type: 'GET',
        data: { insetId: objKey },
        success: function (result) {
            if (result === "Success") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDiv", localization.Deleted, function () { LoadInsetMenu(); });
            }
            else if (result === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}

function LeftInsetItem(objKey) {
    ShowBlockUI();
    $.ajax({
        url: '/Inset/LeftInsetItem/',
        type: 'GET',
        data: { insetId: objKey },
        success: function (result) {
            if (result === "Success") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDiv", localization.Successfully, function () { LoadInsetMenu(); });
            }
            else if (result === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}

function RightInsetItem(objKey) {
    ShowBlockUI();
    $.ajax({
        url: '/Inset/RightInsetItem/',
        type: 'GET',
        data: { insetId: objKey },
        success: function (result) {
            if (result === "Success") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDiv", localization.Successfully, function () { LoadInsetMenu(); });
            }
            else if (result === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}