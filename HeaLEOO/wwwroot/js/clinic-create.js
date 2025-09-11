
document.querySelector(".clinic-create-form")?.addEventListener("submit", function (e) {
    e.preventDefault(); 

    Swal.fire({
        toast: true,
        position: 'top-end', 
        icon: 'success',
        title: 'Clinic has been added successfully ✅',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true
    });

    
    setTimeout(() => {
        this.submit();
    }, 1500);
});


document.querySelector(".btn-cancel")?.addEventListener("click", function (e) {
    e.preventDefault();
    Swal.fire({
        title: 'Are you sure?',
        text: "If you cancel, your clinic will not be created.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#e63946',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, cancel',
        cancelButtonText: 'Stay here'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = this.href;
        }
    });
});

document.querySelectorAll(".clinic-create-form input").forEach(input => {
    input.addEventListener("focus", function () {
        this.style.borderColor = "#2c7da0";
        this.style.boxShadow = "0 0 6px rgba(44, 125, 160, 0.5)";
    });
    input.addEventListener("blur", function () {
        this.style.borderColor = "#ccc";
        this.style.boxShadow = "none";
    });
});
