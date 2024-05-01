// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showDescription(appId, arrow) {
    var descriptionElement = document.getElementById(`description_${appId}`);
    console.log(appId);
    var buttonElement = descriptionElement.nextElementSibling;

    if (arrow.classList.contains('odd')) {
        descriptionElement.style.display = 'none';
        buttonElement.style.display = 'none';
        arrow.classList.remove('odd');
    } else {
        descriptionElement.style.display = 'block';
        buttonElement.style.display = 'inline-block';
        arrow.classList.add('odd');
    }
}

let progressBars = document.querySelectorAll(".circular-progress");

progressBars.forEach((progressBar) => {
    let progressValue = 0;
    let progressEndValue = parseInt(progressBar.getAttribute("value-to-end"));
    let speed = 10;

    let progress = setInterval(() => {
        progressValue++;

        progressBar.style.background = `conic-gradient(
                                                                            #e9e9e9 ${progressValue * 3.6}deg,
                                                                            #000000 ${progressValue * 3.6}deg
                                                                    )`;

        if (progressValue == progressEndValue) {
            clearInterval(progress);
        }
    }, speed);
});