$(document).ready(function () {
});

function Save() {
    var data = JSON.stringify({ model: GetFormObject('addEditSystemDialog') });
    if ($('#addEditSystemDialog').valid()) {
        $.ajax({
            type: "POST",
            url: '/System/AddEdit/',
            data: data,
            contentType: 'application/json',
            success: function (text) {
                if (text == "SuccessCreate") {
                    //    $.unblockUI();
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.SucCreateSystem, function () { $("#jqxgrid").jqxGrid('updatebounddata'); });
                    $('#addEditDialog').dialog('destroy').html("");
                }
                else if (text == "SuccessEdit") {
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.Saved, function () { $("#jqxgrid").jqxGrid('updatebounddata'); });
                    //    $.unblockUI();
                    $('#addEditDialog').dialog('destroy').html("");
                }
                else if (text == "Error") {
                    ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
                }
            }
        });
    }
    else {
        ShowMessageBox(1, "ErrorInputDiv", localization.ReqError);
    }
}