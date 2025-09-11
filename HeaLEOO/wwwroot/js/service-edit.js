// ================== Edit Service Page ==================

document.querySelector(".service-create-form")?.addEventListener("submit", function (e) {
    e.preventDefault(); 

    Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: 'Service has been updated successfully ✅',
        showConfirmButton: false,
        timer: 2000,
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
        text: "If you go back, your changes will not be saved.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#e63946',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, go back',
        cancelButtonText: 'Stay here'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = this.href;
        }
    });
});


document.querySelectorAll(".services-radio-group .form-radio-input").forEach(rb => {
    rb.addEventListener("change", function () {
        document.querySelectorAll(".services-radio-group .form-radio-label")
            .forEach(label => {
                label.style.color = "#34495e";
                label.style.fontWeight = "400";
            });

        let label = this.nextElementSibling;
        label.style.color = "#0bc850";
        label.style.fontWeight = "600";
    });
});


document.addEventListener("DOMContentLoaded", function () {
    let checkedRadio = document.querySelector(".services-radio-group .form-radio-input:checked");
    if (checkedRadio) {
        let label = checkedRadio.nextElementSibling;
        label.style.color = "#0bc850";
        label.style.fontWeight = "600";
    }
});
