$(document).ready(function () {
});

function SaveDictionary() {
    var data = JSON.stringify({ model: GetFormObject('addEditDictionaryDialog') });
    if ($('#addEditDictionaryDialog').valid()) {
        ShowBlockUI();
        $.ajax({
            type: "POST",
            url: '/Dictionary/AddEditDictionary/',
            data: data,
            contentType: 'application/json',
            success: function (result) {
                if (result == "SuccessCreate") {
                    UnblockUI();
                    ShowMessageBox(1, "SuccessDiv", localization.Successfully, function () { $("#jqxgridDictionaries").jqxGrid('updatebounddata'); });
                    $('#addEditDictionary').dialog('destroy').html("");
                }
                else if (result == "SuccessEdit") {
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.Saved, function () { $("#jqxgridDictionaries").jqxGrid('updatebounddata'); });
                    UnblockUI();
                    $('#addEditDictionary').dialog('destroy').html("");
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