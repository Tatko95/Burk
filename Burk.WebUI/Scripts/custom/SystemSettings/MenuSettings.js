$(document).ready(function () {
    LoadMenu();
    if ($('#IsWork').val() == "False") {
        $("#jqxMenu").on('itemclick', function (event) {
            dossierId = event.args.id / 10000 >> 0
            if (event.args.id == 0) {
                AddEditMenuItem(event.args.id);
            }
            else if (event.args.id > 10000 && event.args.id % 10 == 1) {
                AddEditMenuItem(dossierId);
            }
            else if (event.args.id > 10000 && event.args.id % 10 == 2) {
                DeleteMenuItem(dossierId);
            }
            else if (event.args.id > 10000 && event.args.id % 10 == 3) {
                UpMenuItem(dossierId);
            }
            else if (event.args.id > 10000 && event.args.id % 10 == 4) {
                DownMenuItem(dossierId);
            }
            else {
                window.location.href = "/SettingSystem/Index?systemId=" + $('#SystemId').val() + "&dossierId=" + event.args.id;
            }
        });
    }
    else {
        $("#jqxMenu").on('itemclick', function (event) {
            window.location.href = "/Work/Index?systemId=" + $('#SystemId').val() + "&dossierId=" + event.args.id;
        });
    }
});

function LoadMenu() {
    ShowBlockUI();
    if ($('#IsWork').val() == "False") {
        $.ajax({
            url: '/Menu/GetMenuItemsForSettings/',
            type: 'GET',
            data: { systemId: $("#SystemId").val() },
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

                $("#jqxMenu").jqxMenu({ source: records, width: '120', mode: 'vertical' });
                UnblockUI();
            }
        });
    }
    else {
        $.ajax({
            url: '/Menu/GetMenuItems/',
            type: 'GET',
            data: { systemId: $("#SystemId").val() },
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

                $("#jqxMenu").jqxMenu({ source: records, width: '120', mode: 'vertical' });
                UnblockUI();
            }
        });
    }
}

function AddEditMenuItem(objKey) {
    $.ajax({
        url: '/Menu/AddEditMenuItem/',
        type: 'GET',
        data: { dossierId: objKey },
        success: function (result) {
            $("#addEditMenuItemDialog").html(result).dialog({
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

function DeleteMenuItem(objKey) {
    $.ajax({
        url: '/Menu/DeleteMenuItem/',
        type: 'GET',
        data: { dossierId: objKey },
        success: function (result) {
            if (result === "Success") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDiv", localization.Deleted, function () {
                    window.location.href = "/SettingSystem/Index?systemId=" + $('#SystemId').val();
                });
            }
            else if (result === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}

function UpMenuItem(objKey) {
    ShowBlockUI();
    $.ajax({
        url: '/Menu/UpMenuItem/',
        type: 'GET',
        data: { dossierId: objKey },
        success: function (result) {
            if (result === "Success") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDiv", localization.Successfully, function () { LoadMenu(); });
            }
            else if (result === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}

function DownMenuItem(objKey) {
    ShowBlockUI();
    $.ajax({
        url: '/Menu/DownMenuItem/',
        type: 'GET',
        data: { dossierId: objKey },
        success: function (result) {
            if (result === "Success") {
                UnblockUI();
                ShowMessageBox(1, "SuccessDiv", localization.Successfully, function () { LoadMenu(); });
            }
            else if (result === "Error") {
                UnblockUI();
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}