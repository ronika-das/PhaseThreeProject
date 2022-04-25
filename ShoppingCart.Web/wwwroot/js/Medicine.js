$(document).ready(function () {
    dtable = $('#myTable').DataTable({
        "ajax": { "url": "/Admin/Medicine/AllMedicines" },
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <a href="/Admin/Medicine/CreateUpdate?id=${data}"><i class="bi bi-pencil-square"></i></a>
                            <a onclick=RemoveProduct("Admin/Medicine/Delete/${data}")><i class="bi bi-trash"></i></a>
                        `
                }
            }
        ]
    })

});

function RemoveMedicine(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this",
        icon='warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete this!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dtable.ajaz.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}