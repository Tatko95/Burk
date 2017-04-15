var panel;
$(document).ready(function () {
    if ($('#IsCreate').val() == "True") {
        ConfiguratePageIfCreate();
    }
    else {
        ConfiguratePageIfEdit();
    }
});

function ConfiguratePageIfCreate() {
    $.ajax({
        type: "GET",
        url: '/Attribute/GetAttribtePanelWithOnlyReq/',
        data: { dossierId: $('#DossierId').val() },
        contentType: 'application/json',
        success: function (result) {
            panel = new AttributePanel('AttributePanel', false);
            var maxHeight = 0;
            result.forEach(function (item) {
                item.Y = 0;
                panel.AddAttribute(item.AttributeTypeName, item.DosAttributeId, item.FullName, item.Width, item.Height, item.X, item.Y, item.IsShowInGrid, item.IsReq, false, item.AttributeTypeIndex, item.DosInsetId);
                if (item.Y + item.Height > maxHeight) {
                    maxHeight = item.Y + item.Height;
                }
            });
            panel.SetSize(null, maxHeight);
        }
    });
}

function ConfiguratePageIfEdit() {
    ShowBlockUI();
    $.ajax({
        type: "GET",
        url: '/Attribute/GetAttributePanel/',
        data: { insetId: $('#InsetId').val() },
        contentType: 'application/json',
        success: function (result) {
            panel = new AttributePanel('AttributePanel', false);
            var maxWidth = 0;
            var maxHeight = 0;
            var isUnblockCounter = 0;
            var count = 0;
            result.forEach(function (item) {
                count++;
                panel.AddAttribute(item.AttributeTypeName, item.DosAttributeId, item.FullName, item.Width, item.Height, item.X, item.Y, item.IsShowInGrid, item.IsReq, false, item.AttributeTypeIndex, item.DosInsetId, true);
                if (item.X + item.Width > maxWidth) {
                    maxWidth = item.X + item.Width;
                }
                if (item.Y + item.Height > maxHeight) {
                    maxHeight = item.Y + item.Height;
                }
                $.ajax({
                    type: "GET",
                    url: '/Value/GetValueAttrByValueId/',
                    data: { valueId: $('#ValueId').val(), typeName: item.AttributeTypeName, typeIndex: item.AttributeTypeIndex },
                    contentType: 'application/json',
                    success: function (result) {
                        ChangeValue(item, result);
                        isUnblockCounter++;
                            if (isUnblockCounter == count) {
                                UnblockUI();
                            }
                    }
                });
            });
            panel.SetSize(maxWidth, maxHeight);
        }
    });
}

function Save() {
    if ($('#ValueId').val() == "") {
        $.ajax({
            type: "GET",
            url: '/Value/SaveValues/',
            data: { obj: JSON.stringify(panel.GetJSONModel()), dossierId: $('#DossierId').val() },
            contentType: 'application/json',
            success: function (result) {
                window.location.href = '/Work/AddEditObj?systemId' + $('#SystemId').val() + '&dossierId=' + $('#DossierId').val() + "&mainListId=" + result;
            }
        });
    }
    else {
        $.ajax({
            type: "GET",
            url: '/Value/EditValue/',
            data: { obj: JSON.stringify(panel.GetJSONModel()), valueId: $('#ValueId').val() },
            contentType: 'application/json',
            success: function (result) {
                ShowMessageBox(1, "SuccessDiv", localization.Saved, function () { });
                //window.location.href = '/Work/AddEditObj?systemId' + $('#SystemId').val() + '&dossierId=' + $('#DossierId').val() + "&mainListId=" + result;
            }
        });
    }
}