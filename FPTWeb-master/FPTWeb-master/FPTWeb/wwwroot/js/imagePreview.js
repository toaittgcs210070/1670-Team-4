function readURL(input, previewContainer, previewImage) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr("src", e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

$(document).ready(function () {
    //Books edit preview img
    $("#imagePreviewContainer").hide();
    $("#BookImage").change(function () {
        $("#imagePreviewContainer").show();
        readURL(this, "#imagePreviewContainer", "#imagePreview");
    });
    //Publisher edit preview img
    $("#publisherImagePreviewContainer").hide();
    $("#PublisherLogo").change(function () {
        $("#publisherImagePreviewContainer").show();
        readURL(this, "#publisherImagePreviewContainer", "#publisherImagePreview");
    });
    //Books create preview img
    $("#publisherLogoPreviewContainer").hide();
    $("#PublisherLogo").change(function () {
        $("#publisherLogoPreviewContainer").show();
        readURL(this, "#publisherLogoPreviewContainer", "#publisherLogoPreview");
    });
    //Publisher create preview img
    $("#bookImagePreviewContainer").hide();
    $("#BookImage").change(function () {
        $("#bookImagePreviewContainer").show();
        readURL(this, "#bookImagePreviewContainer", "#bookImagePreview");
    });
});
