
let coverInput = document.getElementById("Cover")
let coverPreview = document.getElementById("coverPreview")

coverInput.onchange = () => {
    coverPreview.classList.remove("d-none")
    coverPreview.src = window.URL.createObjectURL(coverInput.files[0])
}

function ApplaySelect2(id, placehoderParam) {
    $(document).ready(function () {
        $(id).select2({
            placeholder: placehoderParam
        });
    });
}

ApplaySelect2("#CategoryId", "Select Category")
ApplaySelect2("#SelectedDevices", "Select Device")