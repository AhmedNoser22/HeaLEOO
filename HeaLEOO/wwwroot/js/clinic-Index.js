function confirmClinicDelete(e, url, cardElement) {
    e.preventDefault();

    Swal.fire({
        title: 'Are you sure?',
        text: "This clinic will be deleted permanently.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#e63946',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, delete it',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            
            fetch(url, { method: 'GET' }) 
                .then(response => {
                    if (response.ok) {
                        
                        cardElement.remove();
                        Swal.fire({
                            toast: true,
                            position: 'top-end',
                            icon: 'success',
                            title: 'Clinic has been deleted successfully ✅',
                            showConfirmButton: false,
                            timer: 2000,
                            timerProgressBar: true
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'Something went wrong while deleting ❌'
                        });
                    }
                })
                .catch(() => {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Unable to connect to server ❌'
                    });
                });
        }
    });

    return false;
}
