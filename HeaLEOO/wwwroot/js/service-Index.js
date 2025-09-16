function confirmServiceDelete(e, form) {
    e.preventDefault();

    if (typeof Swal === "undefined") {
        if (confirm("Are you sure you want to delete this service?")) {
            form.submit();
        }
        return false;
    }

    Swal.fire({
        title: 'Are you sure?',
        text: "This service will be deleted permanently.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#e63946',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, delete it',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            form.submit(); 
        }
    });

    return false;
}
