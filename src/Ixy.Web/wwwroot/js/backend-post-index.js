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

    $.ajax({
        url: '/Backend/Post/Create',
        data: postData,
        type: "Post"
    })
    .done(function (data) {

        if (data.result == "Success") {
            layer.alert("Save sucess0", {
                title: 'Tip'
                , btn:['yes']
                , icon: 6
                , yes: function (index) {
                    layer.close(index);
                    location.href = '/Backend/Post/Index';
                }
            });

        } else {
            layer.tips(data.result, "#btnSave");
        };
    })
    .fail(function (xhr, status, errorThrown) {
        var message;
        var statusErrorMap = {
            '400': "Server understood the request, but request content was invalid.",
            '401': "Unauthorized access.",
            '403': "Forbidden resource can't be accessed.",
            '404': "Not found.",
            '500': "Internal server error.",
            '503': "Service unavailable."
        };
        layer.tips("Sorry, there was a problem!", "error");
        console.log("Error: " + errorThrown);
        console.log("Status: " + status);
        message = statusErrorMap[status];
        if (message) {
            layer.tips(message, "");
        }
        console.dir(xhr);
    })
    .always(function (xhr, status) {
        layer.tips("The request is complete!", "");
    });
}