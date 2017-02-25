$(document).ready(function () {
});

function SaveDictionaryValue() {
    var data = JSON.stringify({ model: GetFormObject('addEditDictionaryValueDialog') });
    if ($('#addEditDictionaryValueDialog').valid()) {
        ShowBlockUI();
        $.ajax({
            type: "POST",
            url: '/Dictionary/AddEditValue/',
            data: data,
            contentType: 'application/json',
            success: function (result) {
                if (result == "SuccessCreate") {
                    UnblockUI();
                    ShowMessageBox(1, "SuccessDiv", localization.Successfully, function () { $("#jqxgridValues").jqxGrid('updatebounddata') });
                    $('#AddEditDiv').dialog('destroy').html("");
                }
                else if (result == "SuccessEdit") {
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.Saved, function () { $("#jqxgridValues").jqxGrid('updatebounddata'); });
                    UnblockUI();
                    $('#AddEditDiv').dialog('destroy').html("");
                }
                else if (result == "Error") {
                    UnblockUI();
                    ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
                }
            }
        });
    }
    else {
        ShowMessageBox(1, "ErrorInputDiv", localization.ReqError);
    }
}