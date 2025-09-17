document.addEventListener("DOMContentLoaded", function () {
    const drawerToggle = document.querySelector(".drawer-toggle");
    const drawer = document.querySelector(".drawer");
    const drawerClose = document.querySelector(".drawer-close");

    if (drawerToggle && drawer) {
        drawerToggle.addEventListener("click", () => {
            drawer.classList.toggle("open");
        });

        if (drawerClose) {
            drawerClose.addEventListener("click", () => {
                drawer.classList.remove("open");
            });
        }

        drawer.querySelectorAll("a").forEach(link => {
            link.addEventListener("click", () => drawer.classList.remove("open"));
        });
    }
});
