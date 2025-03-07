$(document).ready(function () {
    loadTodos();

    // Tambah Todo
    $("#addTodo").click(function () {
        let judul = $("#judul").val();
        let deskripsi = $("#deskripsi").val();

        if (judul && deskripsi) {
            $.ajax({
                url: "/api/todo",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({ judul, deskripsi }),
                success: function () {
                    loadTodos();
                    $("#judul").val("");
                    $("#deskripsi").val("");
                },
                error: function () {
                    alert("Gagal menambahkan todo!");
                }
            });
        } else {
            alert("Judul dan Deskripsi harus diisi!");
        }
    });

    // Load Todo List
    function loadTodos() {
        $.ajax({
            url: "/api/todo",
            type: "GET",
            success: function (todos) {
                $("#todoTable").empty();
                todos.forEach(todo => {
                    $("#todoTable").append(`
                        <tr>
                            <td>${todo.judul}</td>
                            <td>${todo.deskripsi}</td>
                            <td><button class="edit-btn" data-id="${todo.id}" data-judul="${todo.judul}" data-deskripsi="${todo.deskripsi}">Edit</button></td>
                            <td><button class="delete-btn" data-id="${todo.id}">Hapus</button></td>
                        </tr>
                    `);
                });
            }
        });
    }

    // Hapus Todo
    $(document).on("click", ".delete-btn", function () {
        let id = $(this).data("id");

        $.ajax({
            url: `/api/todo/${id}`,
            type: "DELETE",
            success: function () {
                loadTodos();
            },
            error: function () {
                alert("Gagal menghapus todo!");
            }
        });
    });

    // Edit Todo
    $(document).on("click", ".edit-btn", function () {
        let id = $(this).data("id");
        let judul = prompt("Edit Judul", $(this).data("judul"));
        let deskripsi = prompt("Edit Deskripsi", $(this).data("deskripsi"));

        if (judul && deskripsi) {
            $.ajax({
                url: `/api/todo/${id}`,
                type: "PUT",
                contentType: "application/json",
                data: JSON.stringify({ judul, deskripsi }),
                success: function () {
                    loadTodos();
                },
                error: function () {
                    alert("Gagal mengedit todo!");
                }
            });
        }
    });
});
