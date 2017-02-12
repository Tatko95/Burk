$(document).ready(function () {
});

function SaveInset() {
    var data = JSON.stringify({ model: GetFormObject('addEditInsetItemForm') });
    if ($('#addEditInsetItemForm').valid()) {
        ShowBlockUI();
        $.ajax({
            type: "POST",
            url: '/Inset/AddEditInsetItem/',
            data: data,
            contentType: 'application/json',
            success: function (text) {
                if (text == "Success") {
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.Saved, function () { LoadInsetMenu(); });
                    UnblockUI();
                    $('#addEditInsetDialog').dialog('destroy').html("");
                }
                else if (text == "Error") {
                    UnblockUI();
                    ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
                }
            }
        });
    }
    else {
        ShowMessageBox(1, "ErrorDiv", localization.ReqError);
    }
}