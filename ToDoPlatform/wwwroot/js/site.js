// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const userMenu = document.getElementById('userMenu');
const dropdown = document.getElementById('dropdown');

userMenu.addEventListener('click', (e) => {
    e.stopPropagation();
    dropdown.classList.toggle('activate');
});

document.addEventListener('click', () => {
    dropdown.classList.remove('activate');
});