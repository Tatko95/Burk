$(document).ready(function () {
    
});

function Save() {
    var data = JSON.stringify({ model: GetFormObject('addEditAttributeDialog') });
    if ($('#addEditAttributeDialog').valid()) {
        ShowBlockUI();
        $.ajax({
            type: "POST",
            url: '/Attribute/AddEditAttribute/',
            data: data,
            contentType: 'application/json',
            success: function (result) {
                if (result == "Error") {
                    UnblockUI();
                    ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
                }
                else if (result.slice(0, 4) == "Edit") {
                    UnblockUI();
                    panel.EditAttribute(result.slice(4, 44), $('#FullName').val(), $("#IsShowInGrid").is(":checked"));
                    $('#AddEditDiv').dialog('destroy').html("");
                }
                else {
                    UnblockUI();
                    panel.AddAttribute($('#AttributeTypeName').val(), result, $('#FullName').val(), 200, 75, 0, 0, $("#IsShowInGrid").is(":checked"));
                    $('#AddEditDiv').dialog('destroy').html("");
                }
            }
        });
    }
    else {
        ShowMessageBox(1, "ErrorInputDiv", localization.ReqError);
    }
}