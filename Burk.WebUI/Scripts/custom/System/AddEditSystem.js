$(document).ready(function () {
});

function Save() {
    var data = JSON.stringify({ model: GetFormObject('addEditSystemDialog') });
    if ($('#addEditSystemDialog').valid()) {
        console.log(data);
        $.ajax({
            type: "POST",
            data: data,
            contentType: 'application/json',
            url: '/System/AddEdit/',
            success: function (text) {
                alert("work");
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
        $('#addEditDialog').dialog('destroy').html("");
    }
    else {
        alert("НеВсіПоляЗаповнені"); //зробити випадаюче вікно
    }
}