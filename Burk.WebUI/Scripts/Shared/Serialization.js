$.fn.serializeObject = function () {
    var o = {}; 
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push($('#' + this.name.replace('.', '_')).hasClass('placeholder') ? '' : (this.value || ''));
        }
        else {
            o[this.name] = ($('#' + this.name.replace('.', '_')).hasClass('placeholder') ? '' : (this.value || ''));
        }
    });
    return o;
};

function MergeObj(obj1, obj2) {
    var obj3 = {};
    for (var attrname1 in obj1) {
        obj3[attrname1] = obj1[attrname1];
    }
    for (var attrname2 in obj2) {
        obj3[attrname2] = obj2[attrname2];
    }
    return obj3;
}

function GetFormObject(formid, add) {
    var result = $('#' + formid + (add != null ? add : '')).serializeObject();
    //мутотєнь з чек боксами
    //var checkBox = $('#' + formid + ' input[type=checkbox]:checked').map(function () {
    //    return { "name": this.name, "value": this.value };
    //}).get();
    //for (var x in checkBox) {
    //    delete result[checkBox[x].name];
    //    var nObj = {};
    //    nObj[checkBox[x].name] = checkBox[x].value;
    //    result = MergeObj(result, nObj);
    //}
    return result;
}