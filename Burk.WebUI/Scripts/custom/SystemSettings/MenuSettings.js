$(document).ready(function () {
    LoadMenu();
});

function LoadMenu() {
    ShowBlockUI();
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
            $("#jqxMenu").on('itemclick', function (event) {
                AddEditMenuItem(event.args.id);
            });
            UnblockUI();
        }
    });
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