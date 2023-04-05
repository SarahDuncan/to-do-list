// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    const checkbox = document.getElementsByClassName('home-completed');
    const name = document.getElementsByClassName('home-name');
    if (checkbox.checked) {
        name.classList.add('strikethrough');
    }
}

function toggleStrikeThrough(checkbox) {
    const name = document.getElementsByClassName('home-name');
    if (checkbox.checked) {
        name.classList.add('strikethrough');
    } else {
        name.classList.remove('strikethrough');
    }
}