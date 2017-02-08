$(document).ready(function () {
});

function Save() {
    var data = JSON.stringify({ model: GetFormObject('addEditMenuItemForm') });
    if ($('#addEditMenuItemForm').valid()) {
        ShowBlockUI();
        $.ajax({
            type: "POST",
            url: '/Menu/AddEditMenuItem/',
            data: data,
            contentType: 'application/json',
            success: function (text) {
                if (text == "Success") {
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.Saved, function () { LoadMenu(); });
                    UnblockUI();
                    $('#addEditMenuItemDialog').dialog('destroy').html("");
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