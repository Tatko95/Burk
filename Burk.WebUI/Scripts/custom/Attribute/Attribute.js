function Attribute(attributePanel, attributeType, attributeId, fullName, width, height, x, y, isInGrd) {
    this.AttributePanel = attributePanel;
    this.Id = attributeType + attributeId;
    this.ServerId = attributeId;
    this.X = x;
    this.Y = y;
    this.Width = width;
    this.Height = height;
    this.IsDeleted = false;
    this.FullName = fullName;
    this.MinWidth = 0;
    this.IsInGrid = isInGrd;
    ConfigurateAttr(this);
}

function ConfigurateAttr(attr) {
    $('#' + attr.AttributePanel.Id).prepend("<div id='" + attr.Id + "'></div>");
    ConfigurateStyleAttribute(attr);
    ConfigurateFullName(attr);
    ConfiguratePopOver(attr);
    ConfigurateInputBox(attr);
    $('#' + attr.Id).draggable({
        stop: function (event, ui) {
            if (IsCrossingAttribute(attr.AttributePanel, attr, ui.position.left, ui.position.top, ui.position.left + ui.helper[0].clientWidth, ui.position.top + ui.helper[0].clientHeight)) {
                attr.X = ui.originalPosition.left;
                attr.Y = ui.originalPosition.top;
            }
            else {
                attr.X = ui.position.left;
                attr.Y = ui.position.top;
            }
            ChangePositionOnServer(attr);
        },
        drag: function (event, ui) {
            if (IsCrossingAttribute(attr.AttributePanel, attr, ui.position.left, ui.position.top, ui.position.left + ui.helper[0].clientWidth, ui.position.top + ui.helper[0].clientHeight)) {
                ui.position.left = ui.originalPosition.left;
                ui.position.top = ui.originalPosition.top;
            }
        },
        containment: "parent"
    });
    $('#' + attr.Id).resizable({
        resize: function (event, ui) {
            if (IsCrossingAttribute(attr.AttributePanel, attr, attr.X, attr.Y, attr.X + ui.size.width, attr.Y + ui.size.height)) {
                ui.element.width(ui.originalSize.width);
                ui.element.height(ui.originalSize.height);
            }
            if (IsLesOfMinWidthAttribute(attr, ui)) {
                ui.element.width(ui.originalSize.width);
                ui.element.height(ui.originalSize.height);
            }
            if (IsLesOfMinHeightAttribute(attr, ui)) {
                ui.element.width(ui.originalSize.width);
                ui.element.height(ui.originalSize.height);
            }
            //ChangeSizeInput(attr, ui);
        },
        stop: function (event, ui) {
            if (IsCrossingAttribute(attr.AttributePanel, attr, attr.X, attr.Y, attr.X + ui.size.width, attr.Y + ui.size.height)) {
                attr.Width = ui.originalSize.width;
                attr.Height = ui.originalSize.height;
            }
            else if (IsLesOfMinWidthAttribute(attr, ui)) {
                attr.Width = ui.originalSize.width;
                attr.Height = ui.originalSize.height;
            }
            else if (IsLesOfMinHeightAttribute(attr, ui)) {
                attr.Width = ui.originalSize.width;
                attr.Height = ui.originalSize.height;
            }
            else {
                attr.Width = ui.size.width;
                attr.Height = ui.size.height;
            }
            ChangeSizeOnServer(attr);
        },
        containment: "parent"
    });

    ChangeSizeOnServer(attr);
    while (IsCrossingAttribute(attr.AttributePanel, attr, attr.X, attr.Y, attr.X + attr.Width, attr.Y + attr.Height)) {
        if ((attr.X + attr.Width) < attr.AttributePanel.Width) {
            attr.X = attr.X + 1;
        }
        else if ((attr.Y + attr.Height) < attr.AttributePanel.Height) {
            attr.X = 0;
            attr.Y = attr.Y + 1;
        }
        else {
            $('#' + attr.Id).remove();
            attr.IsDeleted = true;
            break;
        }
    }

    if (!attr.IsDeleted) {
        ChangePositionOnServer(attr);
        $('#' + attr.Id).css('left', attr.X);
        $('#' + attr.Id).css('top', attr.Y);
    }
}

function IsCrossingAttribute(panel, attr, x11, y11, x12, y12) {
    var isCross = false;
    panel.Attributes.forEach(function (item) {
        if (attr.Id != item.Id) {
            var x21 = item.X;
            var y21 = item.Y;
            var x22 = x21 + item.Width;
            var y22 = y21 + item.Height;
            if (x11 < x22 && x12 > x21 && y11 < y22 && y12 > y21) {
                isCross = true;
            }
        }
    });
    return isCross;
}
function IsLesOfMinWidthAttribute(attr, ui) {
    var minWidth = $('#popoverBtn' + attr.Id).outerWidth(true) + $('#fullName' + attr.Id).outerWidth(true) + 2;
    if (ui.size.width < minWidth) {
        return true;
    }
    return false;
}
function IsLesOfMinHeightAttribute(attr, ui) {
    var minHeight = $('#fullName' + attr.Id).outerHeight(true) + $('#inputBox' + attr.Id).outerHeight(true) + 2;
    if (ui.size.height < minHeight) {
        return true;
    }
    return false;
}
function ChangePositionOnServer(attr) {
    $.ajax({
        url: '/Attribute/UpdatePositionAttribute/',
        type: 'POST',
        data: { attrId: attr.ServerId, x: attr.X, y: attr.Y },
        success: function (result) {
            if (result == "Error") {
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}
function ChangeSizeOnServer(attr) {
    $.ajax({
        url: '/Attribute/UpdateSizeAttribute/',
        type: 'POST',
        data: { attrId: attr.ServerId, width: attr.Width, height: attr.Height },
        success: function (result) {
            if (result == "Error") {
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
        }
    });
}
function ChangeNameAttribute(attr, name) {
    $('#fullName' + attr.Id).text(name + ":");
}
function ChangeIsInGridAttribute(attr, isInGrid) {
    attr.IsInGrid = isInGrid;
    if (attr.IsInGrid) {
        $('#popoverBtn' + attr.Id).css('background-color', '#428bca');
    }
    else {
        $('#popoverBtn' + attr.Id).css('background-color', '#ff3333');
    }
}
//function ChangeSizeInput(attr, ui) {
//    if (!IsLesOfMinHeightAttribute(attr,ui)) {
//        var heightInputBox = ui.size.height - $('#fullName' + attr.Id).outerHeight(true) - 20;
//        $('#inputBox' + attr.Id).height(heightInputBox);
//    }
//    else {
//        var heightInputBox = ui.originalSize.height - $('#fullName' + attr.Id).outerHeight(true) - 20;
//        $('#inputBox' + attr.Id).height(heightInputBox);
//    }
//}
function ConfiguratePopOver(attr) {
    $('#' + attr.Id).append("<div id='popover" + attr.Id + "'>" +
        "<input type='button' divId='" + attr.Id + "' id='delete" + attr.ServerId + "' class='btn btn-primary btn-sm' value='" + localization.Delete + "' onclick='DeleteAttribute(this)'/>" +
        "<br/>" +
        "<input type='button' id='edit" + attr.ServerId + "' class='btn btn-primary btn-sm' value='" + localization.Edit + "' onclick='EditAttribute(this)'/>" +
        "</div>");

    if (attr.IsInGrid) {
        $('#' + attr.Id).append("<button style='float:right; background-color:#428bca; height:23px' id='popoverBtn" + attr.Id + "'>&nbsp&nbsp</button>");
    }
    else {
        $('#' + attr.Id).append("<button style='float:right; background-color:#ff3333; height:23px' id='popoverBtn" + attr.Id + "'>&nbsp&nbsp</button>");
    }
    $('#' + attr.Id).append("</br>");
    $("#popover" + attr.Id).jqxPopover({ title: "", showCloseButton: true, selector: $("#popoverBtn" + attr.Id) });
}
function DeleteAttribute(element) {
    var serverId = element.id.slice(6, 444);
    var clientId = $("#" + element.id).attr('divid');
    $.ajax({
        url: '/Attribute/DeleteAttribute/',
        type: 'POST',
        data: { attributeId: serverId },
        success: function (result) {
            if (result == "Error") {
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
            $('#' + clientId).remove();
            $('#AttributePanel').click();
            var deletedIndex;
            panel.Attributes.forEach(function (item, i) {
                if (item.ServerId == serverId) {
                    deletedIndex = i;
                }
            });
            panel.Attributes.splice(deletedIndex, 1);
        }
    });
}
function EditAttribute(element) {
    var serverId = element.id.slice(4, 444);
    $.ajax({
        url: '/Attribute/AddEditAttribute/',
        type: 'GET',
        data: { attributeId: serverId, insetId: $('#DossierInsetId').val() },
        success: function (result) {
            if (result == "Error") {
                ShowMessageBox(1, "ErrorDiv", localization.ErrorDeveloper);
            }
            $("#AddEditDiv").html(result).dialog({
                width: 220,
                height: 'auto',
                resizable: false,
                modal: true,
                show: { effect: "drop", direction: "left" },
                hide: { effect: "drop", direction: "left" },
                title: localization.Edit,
                closeOnEscape: true,
                close: function () {
                    $(this).dialog('destroy').html("");
                }
            });
        }
    });
}
function ConfigurateStyleAttribute(attr) {
    $('#' + attr.Id).width(attr.Width);
    $('#' + attr.Id).height(attr.Height);
    $('#' + attr.Id).css("border-width", "1px");
    $('#' + attr.Id).css("border-color", "black");
    $('#' + attr.Id).css("border-style", "dotted");
    $('#' + attr.Id).css("position", "absolute");
}
function ConfigurateInputBox(attr) {
    $('#' + attr.Id).append("<div><input id='inputBox" + attr.Id + "' style='width:100%; height:100%; margin-top:5px' disabled></div>");
}
function ConfigurateFullName(attr) {
    $('#' + attr.Id).append("<div id='fullName" + attr.Id + "' class='tb_title' style='float:left'>" + attr.FullName + ":</div>");
}