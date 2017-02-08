$(document).ready(function () {
});

function Save() {
    //var data = JSON.stringify({ model: GetFormObject('addEditSystemDialog') });
    if ($('#addEditSystemDialog').valid()) {
        //ShowBlockUI();
        $.ajax({
            type: "POST",
            url: '/System/AddEdit/',
            data: data,
            contentType: 'application/json',
            success: function (text) {
                var result = text.split(' ')[0];
                if (result == "SuccessCreate") {
                    //UnblockUI();
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.SucCreateSystem, function () { window.location.href = "/SettingSystem/Index?systemId=" + text.split(' ')[1] });
                    $('#addEditDialog').dialog('destroy').html("");
                }
                else if (result == "SuccessEdit") {
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.Saved, function () { $("#jqxgrid").jqxGrid('updatebounddata'); });
                    //UnblockUI();
                    $('#addEditDialog').dialog('destroy').html("");
                }
                else if (result == "Error") {
                    //UnblockUI();
                    ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
                }
            }
        });
    }
    else {
        alert("WORK");
        ShowMessageBox(1, "ErrorInputDiv", localization.ReqError);
    }
}