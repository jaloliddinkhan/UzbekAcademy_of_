document.addEventListener("DOMContentLoaded", function () {
    let body = document.querySelector("body");
    let colors = ["#ff9999", "#99ff99", "#9999ff", "#ffff99", "#ff9999"];
    let currentIndex = 0;

    setInterval(function () {
        currentIndex = (currentIndex + 1) % colors.length;
        body.style.backgroundColor = colors[currentIndex];
    }, 10000);
});