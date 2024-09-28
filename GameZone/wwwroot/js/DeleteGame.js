const deleteBtns = document.querySelectorAll(".deleteBtn")

deleteBtns.forEach((element) => {
    element.addEventListener('click', async () => {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-success",
                cancelButton: "btn btn-danger"
            },
            buttonsStyling: false
        });
        swalWithBootstrapButtons.fire({
            title: "Are you sure?",
            text: "You Are About to delete The Game !",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then(async (result) => {
            if (result.isConfirmed) {
                gameId = element.getAttribute("data-id")
                const url = `/Games/Delete/${gameId}`;
                try {
                    const response = await fetch(url, { method: "Delete" });
                    if (!response.ok) {
                        throw new Error(`Response status: ${response.status}`);
                    }
                    swalWithBootstrapButtons.fire({
                        title: "Deleted!",
                        text: "Your file has been deleted.",
                        icon: "success"
                    });
                    FeadOut(gameId)
                } catch (error) {
                    Swal.fire({
                        icon: "error",
                        title: "Oops...",
                        text: "Something went wrong!",
                    });
                }
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire({
                    title: "Cancelled",
                    icon: "error"
                });
            }
        });
    })
});

function FeadOut(id) {
    let row = document.getElementById(`row-${id}`)
    row.classList.add("d-none")
}