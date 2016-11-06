var editor;

$(function () {
    $('#btnSave').click(function () { savePost(); });
    editor = CKEDITOR.replace('editor1');
});

function savePost() {
    var postData = {
        "postEntity": {
            "Title": $("#title").val(),
            "Content": editor.getData()
        }
    };
    debugger;
    $.ajax({
        type: "Post",
        url: '/Backend/Post/Create',
        data: postData,
        success: function (data) {
            alert("success");
            debugger;
            if (data.result == "Success") {
                layer.tips("success", "");
            } else {
                layer.tips(data.message, "#btnSave");
            };
        },
        error: function (event, jqxhr, settings, thrownError) {
            
            debugger;
            var message;
            var statusErrorMap = {
                '400': "Server understood the request, but request content was invalid.",
                '401': "Unauthorized access.",
                '403': "Forbidden resource can't be accessed.",
                '404': "Not found.",
                '500': "Internal server error.",
                '503': "Service unavailable."
            };
            layer.tips(event.status, "error");
            //console.log(event.status);
            //console.log(error);
            if (event.status) {
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

            layer.tips(message, "");
        }
    });
}