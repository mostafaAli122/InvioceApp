/***************************************Store Ajax Function******************************/
$(document).ready(function () {
    loadItemsData();
});
function loadItemsData() {
    $.ajax({
        url: "/Items/ListItems",
        method: "GET",
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            var c = []; 
            $.each(result, function (key, item) {
                console.log(item);
                c.push("<tr><td>" + item.id + "</td>");
                c.push("<td>" + item.name + "</td>");
                c.push("<td>" + item.price + "</td>");
                c.push("<td>" + item.store.name + "</td>");
                c.push(`<td><button type='button' class='btn edit-btn '  onclick='getItembyID("${item.id}");'>Edit</button> </td>`);
                c.push(`<td><button type='button' class='btn delete-btn'  onclick='DeleteItem("${item.id}");'>Delete</button></td></tr>`);
            });
            $('.tbody').html(c.join(''));
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function AddItem() {

    $.ajax({
        url: "/Items/CreateItem",
        data: { name: $('#name').val(), price: $('#price').val(), storeId: $('#storeId').val() },
        type: "POST", dataType: "json",
        success: function (result) {
            loadData();
            $('#id').val("");
            $('#name').val("");
            $('#price').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function getItembyID(Id) {
    $('#name').css('border-color', 'lightgrey');
    $('#price').css('border-color', 'lightgrey');
    $('#storeId').css('border-color', 'lightgrey');


    $.ajax({
        url: "/Items/getbyID/" + Id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#id').val(result.id);
            $('#name').val(result.name);
            $('#price').val(result.price);
            $('#storeId').prop("selectedIndex", result.storeId-1);
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function UpdateItem() {
    $.ajax({
        url: "/Items/EditItem",
        data: { id: $('#id').val(), name: $('#name').val(), price: $('#price').val(), storeId: $('#storeId').val() },
        type: "POST",
        dataType: "json",
        success: function (result) {
            loadItemsData();
            $('#id').val("");
            $('#name').val("");
            $('#price').val("");
            $('#storeId').prop("selectedIndex", 0);
            $('#btnUpdate').hide();
            $('#btnAdd').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function DeleteItem(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Items/DeleteItem/" + ID,
            type: "POST",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}