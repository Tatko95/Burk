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
                //if (text == "Success") {
                //    OnSuccessSavePost();
                //    $.unblockUI();
                //}
                //else {
                //    OnIsCopyPost();
                //    $.unblockUI();
                //}
            }
        });
        ShowMessageBox(1, "SuccessfulCreateDiv", localization.SucCreate)
        $('#addEditDialog').dialog('destroy').html("");
    }
    else {
        ShowMessageBox(1, "ErrorInputDiv", localization.ReqError)
    }
}