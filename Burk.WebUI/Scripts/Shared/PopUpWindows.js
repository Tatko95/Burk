//typeBlock = 1 - OK
//typeBlock = 2 - Yes/No
function ShowMessageBox(typeBlock, divId, text, callback) {
    var translations = {};
    var buttons = {};

    if (typeBlock == 1) {
        translations["OK"] = 'OK';

        buttons[translations["OK"]] = function () {
            if (callBack === null || callBack === undefined) {
                $("#" + divId).dialog('close');
            }
            else {
                callBack();
            }
        };

        $('#' + divId).html("<b>" + text + "<b/>").dialog({
            width: 320,
            height: 'auto',
            resizable: false,
            modal: true,
            closeOnEscape: true,
            zIndex: 900,
            show: { effect: "drop", direction: "left" },
            hide: { effect: "drop", direction: "left" },
            buttons: buttons,
            close: function () {
                $(this).dialog('destroy').html("");
            }
        });
    }
}