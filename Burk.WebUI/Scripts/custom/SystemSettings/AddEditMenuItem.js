$(document).ready(function () {
});

function Save() {
    var data = JSON.stringify({ model: GetFormObject('addEditMenuItemDialog') });
    alert("1");
    if ($('#addEditMenuItemDialog').valid()) {
        alert("2");
        ShowBlockUI();
        $.ajax({
            type: "POST",
            url: '/Menu/AddEditMenuItem/',
            data: data,
            contentType: 'application/json',
            success: function (text) {
                if (result == "Success") {
                    ShowMessageBox(1, "SuccessfulCreateDiv", localization.Saved, function () { LoadMenu(); });
                    UnblockUI();
                    $('#addEditMenuItemDialog').dialog('destroy').html("");
                }
                else if (result == "Error") {
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