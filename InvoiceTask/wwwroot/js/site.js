// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    loadData();
    //loadItemsData();
});
/***************************************Store Ajax Function******************************/ 
function loadData() {
    $.ajax({
        url: "/Store/ListStores",
        method: "GET",
        contentType: "application/json;charset=utf-8",
        
        success: function (result) {
            var c = [];
            $.each(result, function (key, item) {

                c.push("<tr><td>" + item.id + "</td>");
                c.push("<td>" + item.name + "</td>");
                c.push(`<td><button type='button' class='btn edit-btn '  onclick='getbyID("${item.id}");'>Edit</button> </td>`);
                c.push(`<td><button type='button' class='btn delete-btn'  onclick='Delete("${item.id}");'>Delete</button></td></tr>`);
            });
            $('.tbody').html(c.join(''));
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Add() {

    $.ajax({
        url: "/Store/CreateStore",
        data: { Name: $('#Name').val() },
        type: "POST", dataType: "json",
        success: function (result) {
            loadData();
            $('#Id').val("");
            $('#Name').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function getbyID(Id) {
    $('#Name').css('border-color', 'lightgrey');
   

    $.ajax({
        url: "/Store/getbyID/" + Id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#Id').val(result.id);
            $('#Name').val(result.name);           
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Update() {
    $.ajax({
        url: "/Store/EditStore",
        data: { Id: $('#Id').val(),  Name: $('#Name').val() },
        type: "POST",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#Id').val("");
            $('#Name').val("");
            $('#btnUpdate').hide();
            $('#btnAdd').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Store/DeleteStore/" + ID,
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


