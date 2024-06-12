var slide_container = document.getElementById("slide-container");

function prevButtonOnClick() {
	slide_container.scrollLeft -= 70;
}

function nextButtonOnClick() {
	slide_container.scrollLeft += 70;
}