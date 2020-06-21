
showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-model .form-body").html(res);
            $("#form-model .form-title").html(title);
            $("#form-model").modal("show");
        }
    })
}