//typeBlock = 1 - OK
//typeBlock = 2 - Yes/No
function ShowMessageBox(typeBlock, divId, text, callback) {
    var translations = {};
    var buttons = {};

    if (typeBlock == 1) {
        translations["OK"] = 'OK';

        buttons[translations["OK"]] = function () {
            if (callback !== null || callback !== undefined) {
                callback();
            }
            $("#" + divId).dialog('close');
        };

        $('#' + divId).html("<b>" + text + "<b/>").dialog({
            width: 320,
            height: 'auto',
            resizable: false,
            modal: true,
            closeOnEscape: false,
            zIndex: 900,
            show: { effect: "drop", direction: "left" },
            hide: { effect: "drop", direction: "left" },
            buttons: buttons,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
            },
            close: function () {
                $(this).dialog('destroy').html("");
            }
        });
    }
}