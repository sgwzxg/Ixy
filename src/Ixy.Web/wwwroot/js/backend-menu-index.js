var selectedMenuId = "00000000-0000-0000-0000-000000000000";
$(function () {
    $("#btnAddRoot").click(function () { add(0); });
    $("#btnAdd").click(function () { add(1); });
    $("#btnSave").click(function () { save(); });
    $("#btnDelete").click(function () { deleteMulti(); });
    $("#btnLoadRoot").click(function () {
        selectedMenuId = "00000000-0000-0000-0000-000000000000";
        loadTables(1, 10);
    });
    $("#checkAll").click(function () { checkAll(this) });
    initTree();
});

function initTree() {
    $.jstree.destroy();
    $.ajax({
        type: "Get",
        url: "Backend/Menu/GetMenuTreeData",
        success: function (data) {
            $('#treeDiv').jstree({
                'core': {
                    'data': data,
                    "multiple": false
                },
                "plugins": ["state", "types", "wholerow"]
            })
            $("#treeDiv").on("ready.jstree", function (e, data) {
                data.instance.open_all();
            });
            $("#treeDiv").on('changed.jstree', function (e, data) {
                var node = data.instance.get_node(data.selected[0]);
                if (node) {
                    selectedMenuId = node.id;
                    loadTables(1, 10);
                };
            });
        }
    });

}

function loadTables(startPage, pageSize) {
    $("#tableBody").html("");
    $("#checkAll").prop("checked", false);
    $.ajax({
        type: "GET",
        url: "Backend/Menu/GetByParent?startPage=" + startPage + "&pageSize=" + pageSize + "&parentId=" + selectedMenuId,
        success: function (data) {
            $.each(data.rows, function (i, item) {
                var tr = "<tr>";
                tr += "<td align='center'><input type='checkbox' class='checkboxs' value='" + item.id + "'/></td>";
                tr += "<td>" + item.name + "</td>";
                tr += "<td>" + (item.code == null ? "" : item.code) + "</td>";
                tr += "<td>" + (item.url == null ? "" : item.url) + "</td>";
                tr += "<td>" + (item.type == 0 ? "Menu" : "Button") + "</td>";
                tr += "<td>" + (item.remarks == null ? "" : item.remarks) + "</td>";
                tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i> Edit </button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> Delete </button> </td>"
                tr += "</tr>";
                $("#tableBody").append(tr);
            })
            var elment = $("#grid_paging_part");
            if (data.rowCount > 0) {
                var options = { 
                    bootstrapMajorVersion: 3,
                    currentPage: startPage,
                    numberOfPages: data.rowsCount,
                    totalPages: data.pageCount,
                    onPageChanged: function (event, oldPage, newPage) {
                        loadTables(newPage, pageSize);
                    }
                }
                elment.bootstrapPaginator(options);
            }
        }
    })
}

function checkAll(obj) {
    $(".checkboxs").each(function () {
        if (obj.checked == true) {
            $(this).prop("checked", true)

        }
        if (obj.checked == false) {
            $(this).prop("checked", false)
        }
    });
};

function add(type) {
    if (type === 1) {
        if (selectedMenuId === "00000000-0000-0000-0000-000000000000") {
            layer.alert("one menu or button at least.");
            return;
        }
        $("#ParentId").val(selectedMenuId);
    }
    else {
        $("#ParentId").val("00000000-0000-0000-0000-000000000000");
    }
    $("#Id").val("00000000-0000-0000-0000-000000000000");
    $("#Code").val("");
    $("#Name").val("");
    $("#Type").val(0);
    $("#Url").val("");
    $("#Icon").val("");
    $("#Serial").val(0);
    $("#Remarks").val("");
    $("#Title").text("New Root");
    //popup new window
    $("#addRootModal").modal("show");
};

function edit(id) {
    $.ajax({
        type: "Get",
        url: "Backend/Menu/Get?id=" + id + "&_t=" + new Date(),
        success: function (data) {
            $("#Id").val(data.id);
            $("#ParentId").val(data.parentId);
            $("#Name").val(data.name);
            $("#Code").val(data.code);
            $("#Type").val(data.type);
            $("#Url").val(data.url);
            $("#Icon").val(data.icon);
            $("#Serial").val(data.serial);
            $("#Description").val("");

            $("#Title").text("Edit")
            $("#addRootModal").modal("show");
        }
    })
};

function save() {
    console.log("save");
    var postData = {
        "menuItem": {
            "Id": $("#Id").val(),
            "ParentId": $("#ParentId").val(),
            "Name": $("#Name").val(),
            "Code": $("#Code").val(),
            "Type": $("#Type").val(),
            "Url": $("#Url").val(),
            "Icon": $("#Icon").val(),
            "Serial": $("#Serial").val(),
            "Description": $("#Description").val()
        }
    };
    
    $.ajax({
        type: "Post",
        url: "/Backend/Menu/Edit",
        data: postData,
        success: function (data) {
            debugger
            if (data.result == "Success") {
                initTree();
                $("#addRootModal").modal("hide");
            } else {
                layer.tips(data.message, "#btnSave");
            };
        },
        error: function (e, x, status, error) {
            debugger
            var message;
            var statusErrorMap = {
                '400': "Server understood the request, but request content was invalid.",
                '401': "Unauthorized access.",
                '403': "Forbidden resource can't be accessed.",
                '404': "Not found.",
                '500': "Internal server error.",
                '503': "Service unavailable."
            };

            console.log(x.status);
            console.log(error);
            if (x.status) {
                message = statusErrorMap[x.status];
                if (!message) {
                    message = "Unknown Error \n.";
                }
            } else if (error == 'parsererror') {
                message = "Error.\nParsing JSON Request failed.";
            } else if (error == 'timeout') {
                message = "Request Time out.";
            } else if (error == 'abort') {
                message = "Request was aborted by the server";
            } else {
                message = "Unknown Error \n.";
            }

            layer.tips(message,"");
        }
    });
};
//delete bunch of lines
function deleteMulti() {
    var ids = "";
    $(".checkboxs").each(function () {
        if ($(this).prop("checked") == true) {
            ids += $(this).val() + ","
        }
    });
    ids = ids.substring(0, ids.length - 1);
    if (ids.length == 0) {
        layer.alert("please select the records to delete.");
        return;
    };
    //confirm
    layer.confirm("Confirm to delete the selected ones?", {
        btn: ["Yes", "No"]
    }, function () {
        var sendData = { "ids": ids };
        $.ajax({
            type: "Post",
            url: "/Menu/DeleteMuti",
            data: sendData,
            success: function (data) {
                if (data.result == "Success") {
                    initTree();
                    layer.closeAll();
                }
                else {
                    layer.alert("Delete failed！");
                }
            }
        });
    });
};
//delete single line
function deleteSingle(id) {
    layer.confirm("Confirm to delete the selected one?", {
        btn: ["Yes", "No"]
    }, function () {
        $.ajax({
            type: "POST",
            url: "/Menu/Delete",
            data: { "id": id },
            success: function (data) {
                if (data.result == "Success") {
                    initTree();
                    layer.closeAll();
                }
                else {
                    layer.alert("Delete failed！");
                }
            }
        })
    });
};


