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

//only sends one data
function ajaxRequest(xhr, type, handler, data) {
    
    if (type == 'POST') {
        xhr.open(type, handler, true);
        xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xhr.setRequestHeader('XSRF-TOKEN', $('input:hidden[name="__RequestVerificationToken"]').val());
        xhr.send(data.varName + '=' + data.value);
    }
    else {
        xhr.open(type, handler + '&' + data.varName + '=' + data.value, true);
        xhr.send();
    }
}