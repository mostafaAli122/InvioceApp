

$(document).ready(function () {
    $('#storeId').change(function () {
        Items=GetItemsData($(this).val())
        AddRow(Items);
    });
   
});
var Items
$('#Add').click(function () {
    AddRow(Items);
    calc_total();
});
function calc_total() {
    
    var sum = 0;
    $("tbody tr").each((index) => {
        var value = parseFloat($('.net').eq(index).val());
        if (!isNaN(value))
            sum += value; 
    });
    $('#InvoiceTotal').val(sum);
}
function AddRow(Items) {
    var s = '<select id="item">';
    Items.forEach((element) => {
        s+=`<option value=${element.id} > ${ element.name } </option >`;
       
    });
    s += '</select>'
    var unit ='<select><option>Package</option><option>Packet</option></select>'
    var c = [];
    c.push(`<tr><td>${s}</td>`);
    c.push(`<td>${unit}</td>`);
    c.push("<td><input type='text' class='price'/></td>");
    c.push("<td><input type='text' class='qty'/></td>");
    c.push("<td><input type='text' class='total'/></td>");
    c.push("<td><input type='text' class='discount'/></td>");
    c.push("<td><input type='text' class='net'/></td></tr>");
    $('.tbody').append(c.join(''));
    $('.qty').change(function () {
       var parent = $(this).closest('tr');
        var price = parseFloat($('.price', parent).val());
        var qty = parseFloat($('.qty', parent).val());

        $('.total', parent).val(qty * price);
    });
    $('.discount').change(function () {
        var parent = $(this).closest('tr');
        var price = parseFloat($('.price', parent).val());
        var qty = parseFloat($('.qty', parent).val());
        var discount = parseFloat($('.discount', parent).val());

        $('.net', parent).val(qty * price - ((price * discount)/100));
    });
}
function GetItemsData(storeId) {
    var Items = false;
    $.ajax({
        url: `/Invoice/GetItems/${storeId}`,
        method: "GET",
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            Items = result;   
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return Items;
}

$('#InvoiceTaxes').change(function () {
   
    var InvoiceTotal = parseFloat($('#InvoiceTotal').val());
    var InvoiceTaxes = parseFloat($('#InvoiceTaxes').val());   
    $('#Invoicenet').val(InvoiceTotal + ((InvoiceTaxes*InvoiceTotal)/100) );
});

$('#save').click(function () {
    AddInvoice();
    console.log($('#InvoiceDate').val());
});
function AddInvoice() {

    $.ajax({
        url: "/Invoice/CreateInvoice",
        data: { InvoiceDate: "2020 - 06 - 22", Storeid: 2,  Total:40, Taxes:7, Net: 42.8},
        type: "POST", dataType: "json",
        success: function (result) {
            alert("Successfully added new Invoice");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}