function togglePassword(id) {
    const input = document.getElementById(id);
    const icon = event.currentTarget.querySelector("i");
    if (input.type === "password") {
        input.type = "text";
        icon.classList.remove("fa-eye");
        icon.classList.add("fa-eye-slash");
    } else {
        input.type = "password";
        icon.classList.remove("fa-eye-slash");
        icon.classList.add("fa-eye");
    }
}

document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll(".auth-form .form-control").forEach(input => {
        input.addEventListener("focus", () => {
            input.style.borderColor = "#01aaff";
            input.style.boxShadow = "0 0 10px rgba(1,170,255,0.3)";
        });
        input.addEventListener("blur", () => {
            input.style.borderColor = "#ddd";
            input.style.boxShadow = "none";
        });
    });

    const form = document.querySelector(".auth-form");
    if (form) {
        form.addEventListener("submit", function (e) {
            const email = document.querySelector("#Email").value.trim();
            const pass = document.querySelector("#loginPassword").value.trim();

            if (email === "" || pass === "") {
                e.preventDefault();
                showToast("error", "Please fill all fields!");

                // Shake animation
                const card = document.querySelector(".auth-card");
                card.classList.add("shake");
                setTimeout(() => {
                    card.classList.remove("shake");
                }, 500);
            }
        });
    }
});
document.addEventListener("DOMContentLoaded", () => {
    const serverError = document.getElementById("serverError");
    if (serverError && serverError.value) {
        showToast("error", serverError.value);

        const card = document.querySelector(".auth-card");
        if (card) {
            card.classList.add("shake");
            setTimeout(() => {
                card.classList.remove("shake");
            }, 500);
        }
    }
});

function showToast(type, message) {
    Swal.fire({
        toast: true,
        icon: type,
        title: message,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000,
        timerProgressBar: true
    });
}
