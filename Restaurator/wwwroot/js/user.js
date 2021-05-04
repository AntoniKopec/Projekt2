var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/user",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "fullName", "width": "25%" },
            { "data": "email", "width": "30%" },
            {
                "data": { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        //currently user is locked
                        return `<div class="text-center">
                        <a class="btn btn-danger text-white" style="cussor:pointer; width:100px;" onclick=LockUnlock('${data.id}')>
                            <i class="far fa-trash-alt  "></i> Unlock
                        </a></div>`;
                    }
                    else {
                        return `<div class="text-center">
                        <a class="btn btn-success text-white" style="cussor:pointer; width:100px;" onclick=LockUnlock('${data.id}')>
                            <i class="far fa-trash-alt  "></i> Lock
                        </a></div>`;
                    }
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}