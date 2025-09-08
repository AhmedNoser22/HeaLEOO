// ✅ On Save button click
document.querySelector(".doctor-create-form")?.addEventListener("submit", function (e) {
    e.preventDefault(); // stop form temporarily

    Swal.fire({
        icon: 'success',
        title: 'Saved',
        text: 'Doctor has been added successfully ✅',
        confirmButtonText: 'OK',
        confirmButtonColor: '#0bc850'
    }).then(() => {
        this.submit(); // continue form submit after confirmation
    });
});

// ⚠️ On Cancel button click
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

// 🎨 Highlight selected clinics
document.querySelectorAll(".doctor-checkbox-group .form-check-input").forEach(cb => {
    cb.addEventListener("change", function () {
        let label = this.nextElementSibling;
        if (this.checked) {
            label.style.color = "#0bc850";
            label.style.fontWeight = "600";
        } else {
            label.style.color = "#34495e";
            label.style.fontWeight = "400";
        }
    });
});
