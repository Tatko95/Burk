function AttributePanel(id, isSettings) {
    this.Attributes = [];
    this.Width = 1100;
    this.Height = 300;
    this.Id = id;
    this.IsSettings = isSettings;

    ConfigurationPanel(this);

    this.AddAttribute = function (attributeType, attributeId, fullName, width, height, x, y, isInGrid, isReq, isSettings, attributeTypeIndex, dosInsetId, isEdit) {
        var attr = new Attribute(this, attributeType, attributeId, fullName, width, height, x, y, isInGrid, isReq, isSettings, attributeTypeIndex, dosInsetId, isEdit);
        this.Attributes.push(attr);
        if (attr.IsDeleted) {
            this.Attributes.pop();
        }
    };
    this.SetSize = function (width, height) {
        if (width != null) {
            this.Width = width;
            $('#' + this.Id).width(this.Width);
        }
        if (height != null) {
            this.Height = height;
            $('#' + this.Id).height(this.Height);
        }
    };
    this.EditAttribute = function (attrId, newName, isInGrid, isReq) {
        panel.Attributes.forEach(function (item) {
            if (item.ServerId == attrId) {
                ChangePositionOnServer(item);
                ChangeSizeOnServer(item);
                ChangeNameAttribute(item, newName);
                ChangeIsInGridAttribute(item, isInGrid);
                ChangeIsReq(item, isReq);
            }
        });

    }
    this.GetJSONModel = function () {
        var returnModel = [];
        this.Attributes.forEach(function (item, i) {
            returnModel.push({ AttributeTypeName: item.AttributeTypeName, AttributeTypeIndex: item.AttributeTypeIndex, InsetId: item.InsetId, Value: $('#inputBox' + item.Id).val() });
            //console.log($('#inputBox' + item.Id).val());
        });
        return returnModel;
    }

    function ConfigurationPanel(panel) {
        $('#' + panel.Id).width(panel.Width);
        $('#' + panel.Id).height(panel.Height);
        if (panel.IsSettings) {
            $('#' + panel.Id).css("border-width", "1px");
            $('#' + panel.Id).css("border-color", "black");
            $('#' + panel.Id).css("border-style", "dotted");
            $('#' + panel.Id).resizable({
                resize: function (event, ui) {
                    if (IsCrossingPanel(panel, ui.size.width, ui.size.height)) {
                        ui.element.width(ui.originalSize.width);
                        ui.element.height(ui.originalSize.height);
                    }
                },
                stop: function (event, ui) {
                    panel.Width = ui.size.width;
                    panel.Height = ui.size.height;
                }
            });
        }
        $('#' + panel.Id).css("position", "relative");
    }
}

function IsCrossingPanel(panel, x1, y1) {
    var isCross = false;
    panel.Attributes.forEach(function (item) {
        var x2 = item.X + item.Width;
        var y2 = item.Y + item.Height;
        if (x1 < x2 || y1 < y2) {
            isCross = true;
        }
    });
    return isCross;
}