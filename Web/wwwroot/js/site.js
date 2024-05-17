// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var dt;
var dataUrl;

function InitializeDataTable(tableName, dataUrl, method, columns,actionUrl) {

    dt = $(tableName);
    dataUrl = dataUrl;

    let columnData = [];
    for (let col = 0; col < columns.length; col++) {

        if (columns[col].includes("image")) {
            columnData.push({
                data: "imageSrc",
                render: function (data) {
                    return "<img src='" + data + "' width='50' height='50'/>"
                }
            });
        }
        else if (columns[col].includes("action")) {
            columnData.push({
                data: "id",
                render: function (data) {
                    return "<a href='"+actionUrl+data+"' >Edit</a>"
                }
            });
        }
        else {
            columnData.push({
                data: columns[col],
            });
        }
    }

    $(dt).DataTable({
        "ajax": {
            url: dataUrl,
            type: "POST",
            dataType: "json",
            headers: {
                "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            //contentType: "application/json; charset=utf-8",
            dataSrc: function (json) {
                return json;
            },
            failure: function (response) {
                console.log(response);
            }
        },
        columns: columnData,
        processing: true,
        serverSide: true,
        filter: true,
        select: true
    });

    $(dt).on('click', 'td', function () {
        $(this).find("input").each(function (i,obj) {
            $(obj).addClass("updated");
        });
    });
}

function ReloadDataTable(url,data) {
    $.ajax({
        url: url,
        method: "POST",
        dataType: "json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: {"model": data},
        success: function (data) {
            if (data.IsSuccess) {
                $(dt).DataTable().ajax.reload();
            }
            else {
                //console.log(data);
            }
        }
    })
}