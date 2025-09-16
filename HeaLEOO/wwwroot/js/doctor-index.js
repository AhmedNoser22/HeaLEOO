function confirmDelete(e, url) {
    e.preventDefault();

    if (typeof Swal === "undefined") {
        if (confirm("Are you sure? This doctor will be deleted permanently.")) {
            window.location.href = url;
        }
        return false;
    }

    Swal.fire({
        title: 'Are you sure?',
        text: "This doctor will be deleted permanently.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#e63946',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, delete it',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = url;
        }
    });

    return false;
}

document.addEventListener("DOMContentLoaded", function () {
    var successEl = document.getElementById("successMessage");
    var errorEl = document.getElementById("errorMessage");

    if (typeof Swal !== "undefined") {
        if (successEl && successEl.value) {
            Swal.fire({
                toast: true,
                position: 'top-end',
                icon: 'success',
                title: successEl.value,
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true
            });
        } else if (errorEl && errorEl.value) {
            Swal.fire({
                toast: true,
                position: 'top-end',
                icon: 'error',
                title: errorEl.value,
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true
            });
        }
    }
});
