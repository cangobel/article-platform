// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var header = document.getElementsByTagName("header")[0];
var headerHeight = header.getBoundingClientRect().height;

var dropdown = document.getElementById("userDropdown");
var dropdownButton = document.getElementById("userDropdownButton");

window.onclick = (event) => {
    if (!dropdown.classList.contains("d-none")) {
        if (!dropdown.contains(event.target)) {
            if (!dropdownButton.contains(event.target))
                dropdown.classList.add("d-none");
        }
    }
}

function userDropdownButtonClick() {
    if (dropdown.classList.contains("d-none")) {
        dropdown.classList.remove("d-none");
    }
}