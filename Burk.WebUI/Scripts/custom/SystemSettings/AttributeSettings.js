var panel;
$(document).ready(function () {
    panel = new AttributePanel('AttributePanel');
    CreatePanel();
    console.log(panel.Attributes)
});

function CreatePanel() {
    $.ajax({
        url: '/Attribute/GetAttributePanel/',
        type: 'GET',
        data: { insetId: $('#DossierInsetId').val() },
        success: function (result) {
            var maxWidth = panel.Width;
            var maxHeight = panel.Height;
            result.forEach(function (item) {
                panel.AddAttribute(item.AttributeTypeName, item.DosAttributeId, item.FullName, item.Width, item.Height, item.X, item.Y, item.IsShowInGrid);
                if (item.X + item.Width > maxWidth) {
                    maxWidth = item.X + item.Width;
                }
                if (item.Y + item.Height > maxHeight) {
                    maxHeight = item.Y + item.Height;
                }
            });
            panel.SetSize(maxWidth, maxHeight)
        }
    });
}

function AddWindow(objKey) {
    $.ajax({
        url: '/Attribute/AddEditAttribute/',
        type: 'GET',
        data: { attributeId: objKey, insetId: $('#DossierInsetId').val() },
        success: function (result) {
            $("#AddEditDiv").html(result).dialog({
                width: 220,
                height: 'auto',
                resizable: false,
                modal: true,
                show: { effect: "drop", direction: "left" },
                hide: { effect: "drop", direction: "left" },
                title: objKey == null ? localization.CreateNew : localization.Edit,
                closeOnEscape: true,
                close: function () {
                    $(this).dialog('destroy').html("");
                }
            });
        }
    });
 }