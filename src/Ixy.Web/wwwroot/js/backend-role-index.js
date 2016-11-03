$(function () {
    $("#btnAdd").click(function () { add(1); });
    $("#btnSave").click(function () { save(); });
    $("#btnDelete").click(function () { deleteMulti(); });
    loaddata();
});

function loadTables(startPage, pageSize) {
    $("#tableBody").html("");
    $("#checkAll").prop("checked", false);
    $.ajax({
        type: "GET",
        url: "Backend/Role/Get?startPage=" + startPage + "&pageSize=" + pageSize,
        success: function (data) {
            $.each(data.rows, function (i, item) {
                var tr = "<tr>";
                tr += "<td align='center'><input type='checkbox' class='checkboxs' value='" + item.id + "'/></td>";
                tr += "<td>" + item.name + "</td>";
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