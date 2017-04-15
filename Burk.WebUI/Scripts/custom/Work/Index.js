var column0 = new GridColumn("Text0");
var column1 = new GridColumn("Text1");
var column2 = new GridColumn("Text2");
var column3 = new GridColumn("Text3");
var column4 = new GridColumn("Text4");
var column5 = new GridColumn("Text5");
var column6 = new GridColumn("Text6");
var column7 = new GridColumn("Text7");
var column8 = new GridColumn("Text8");
var column9 = new GridColumn("Text9");
var column10 = new GridColumn("Text10");
var columns = new Columns([column0, column1, column2, column3, column4, column5, column6, column7, column8, column9, column10]);

$(document).ready(function () {
    if ($('#DossierId').val() != null && $('#DossierId').val() != "") {
        InitGrid();
    }
})

function InitGrid() {
    $.ajax({
        type: "GET",
        url: '/Attribute/GetColumnsAttributeForGrid/',
        data: { dossierId: $('#DossierId').val() },
        contentType: 'application/json',
        success: function (result) {
            ConfigurateColumnsGrid(result);
            $("#jqxgrid").jqxGrid({
                width: (columns.Width() > 999 ? 1000 : columns.Width() < 425 ? 425 : columns.Width()) + 60,
                height: 346,
                localization: getLocalization(UICulture),
                source: {
                    datatype: "json",
                    datafields: [
                        { name: 'MainListId', type: 'int' },
                        { name: 'Text0', type: 'string' },
                        { name: 'Text1', type: 'string' },
                        { name: 'Text2', type: 'string' },
                        { name: 'Text3', type: 'string' },
                        { name: 'Text4', type: 'string' },
                        { name: 'Text5', type: 'string' },
                        { name: 'Text6', type: 'string' },
                        { name: 'Text7', type: 'string' },
                        { name: 'Text8', type: 'string' },
                        { name: 'Text9', type: 'string' },
                        { name: 'Text10', type: 'string' },
                    ],
                    id: 'MainListId',
                    url: "/Value/GetGridValues?dossierId=" + $('#DossierId').val(),
                    sortcolumn: 'MainListId',
                    sortdirection: 'desc',
                    loadComplete: function (data) { },
                },
                theme: "boostrap",
                pageable: true,
                sortable: true,
                columnsresize: true,
                columns: [
                    { datafield: 'MainListId', hidden: true },
                    {
                        text: '', datafield: 'Edit', columntype: 'button', width: 30, cellsrenderer: function () {
                            return '<div style="width: 100%; height: 100%"><img src="/../Content/JQWidgets/images/icon-edit.png" style="margin-left: -12px; margin-top: -18px"/></div>';
                        }
                    },
                    { text: column0.text, datafield: 'Text0', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column0.width === 'undefined' ? 0 : column0.width), hidden: column0.hidden },
                    { text: column1.text, datafield: 'Text1', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column1.width === 'undefined' ? 0 : column1.width), hidden: column1.hidden },
                    { text: column2.text, datafield: 'Text2', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column2.width === 'undefined' ? 0 : column2.width), hidden: column2.hidden },
                    { text: column3.text, datafield: 'Text3', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column3.width === 'undefined' ? 0 : column3.width), hidden: column3.hidden },
                    { text: column4.text, datafield: 'Text4', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column4.width === 'undefined' ? 0 : column4.width), hidden: column4.hidden },
                    { text: column5.text, datafield: 'Text5', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column5.width === 'undefined' ? 0 : column5.width), hidden: column5.hidden },
                    { text: column6.text, datafield: 'Text6', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column6.width === 'undefined' ? 0 : column6.width), hidden: column6.hidden },
                    { text: column7.text, datafield: 'Text7', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column7.width === 'undefined' ? 0 : column7.width), hidden: column7.hidden },
                    { text: column8.text, datafield: 'Text8', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column8.width === 'undefined' ? 0 : column8.width), hidden: column8.hidden },
                    { text: column9.text, datafield: 'Text9', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column9.width === 'undefined' ? 0 : column9.width), hidden: column9.hidden },
                    { text: column10.text, datafield: 'Text10', cellsrenderer: cellsrenderer, align: 'center', width: (typeof column10.width === 'undefined' ? 0 : column10.width), hidden: column10.hidden },
                    {
                        text: '', datafield: 'Delete', columntype: 'button', width: 30, cellsrenderer: function () {
                            return '<div style="width: 100%; height: 100%"><img src="/../Content/JQWidgets/images/icon-delete.png" style="margin-left: -9px; margin-top: -18px"/></div>';
                        }
                    },
                ],
            });
            $("#jqxgrid").on("cellclick", function (event) {
                var rowindex = event.args.rowindex;
                var columnindex = event.args.columnindex;
                var mainListId = $("#jqxgrid").jqxGrid('getrowid', rowindex);
                if (columnindex == 1) {
                    Edit(mainListId);
                }
                //if (columnindex == 3) {
                //    window.location.href = "/SettingSystem/Index?systemId=" + systemId;
                //}
                if (columnindex == 13) {
                    Delete(mainListId);
                }
            });
        }
    });
}

function ConfigurateColumnsGrid(obj) {
    obj.forEach(function (item) {
        columns.columns.forEach(function (column) {
            if (column.name == item.attributeType) {
                column.text = item.text;
                column.width = item.width;
                column.hidden = false;
            }
        });
    });
}
function GridColumn(name, text) {
    this.name = name;
    this.text = text;
    this.hidden = true;
}
function Columns(mass) {
    this.columns = mass;
    this.Width = function () {
        var w = 0;
        this.columns.forEach(function (item) {
            if (item.hidden == false) {
                w += item.width;
            }
        })
        return w;
    }
}

function Delete(mainListId) {
    ShowBlockUI();
    $.ajax({
        type: "GET",
        url: '/Value/DeleteValue/',
        data: { mainListId: mainListId },
        contentType: 'application/json',
        success: function (result) {
            UnblockUI();
            $("#jqxgrid").jqxGrid('updatebounddata');
        }
    });
}

function Edit(mainListId) {
    window.location.href = '/Work/AddEditObj?systemId=' + $('#SystemId').val() + '&dossierId=' + $('#DossierId').val() + "&mainListId=" + mainListId;
}