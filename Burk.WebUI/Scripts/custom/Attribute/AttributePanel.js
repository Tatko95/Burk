function AttributePanel(id) {
    this.Attributes = [];
    this.Width = 1100;
    this.Height = 300;
    this.Id = id;

    ConfigurationPanel(this);

    this.AddAttribute = function (attributeType, attributeId, fullName, width, height, x, y, isInGrid) {
        var attr = new Attribute(this, attributeType, attributeId, fullName, width, height, x, y, isInGrid);
        this.Attributes.push(attr);
        if (attr.IsDeleted) {
            this.Attributes.pop();
        }
    };
    this.SetSize = function (width, height) {
        this.Width = width;
        $('#' + this.Id).width(this.Width);
        this.Height = height;
        $('#' + this.Id).height(this.Height);
    };
    this.EditAttribute = function (attrId, newName, isInGrid) {
        panel.Attributes.forEach(function (item) {
            if (item.ServerId == attrId) {
                ChangePositionOnServer(item);
                ChangeSizeOnServer(item);
                ChangeNameAttribute(item, newName);
                ChangeIsInGridAttribute(item, isInGrid)
            }
        });

    }

    function ConfigurationPanel(panel) {
        $('#' + panel.Id).width(panel.Width);
        $('#' + panel.Id).height(panel.Height);
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