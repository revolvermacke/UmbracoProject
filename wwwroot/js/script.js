//Footer Copyright Highlighting

document.querySelectorAll(".footerText").forEach(p => {
    const words = p.innerHTML.trim().split(" ");
    if (words.length > 1) {
        const lastWord = words.pop();
        p.innerHTML = `${words.join(" ") } <span class="highlight">${lastWord}</span>`;
    }
});

document.addEventListener("submit", function (e) {
    if (e.target.matches("form")) {
        sessionStorage.setItem("scrollY", window.scrollY)
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const scrollY = sessionStorage.getItem("scrollY");
    if (scrollY) {
        window.scrollTo({ top: parseInt(scrollY, 10), behavior: "instant" });
        sessionStorage.removeItem("scrollY");
    }
}) 