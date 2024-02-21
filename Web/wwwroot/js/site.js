// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var dt;

function InitializeDataTable(tableName, dataUrl, method, columns,actionUrl) {

    dt = $(tableName);

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

    $(tableName).DataTable({
        "ajax": {
            url: dataUrl,
            type: "POST",
            dataType: "json",
            headers: {
                "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            contentType: "application/json; charset=utf-8",
            dataSrc: function (json) {
                console.log(json);
                return json;
            },
            failure: function (response) {
                console.log(response);
            }
        },
        columns: columnData,
        processing: true,
        serverSide: true
    });
}