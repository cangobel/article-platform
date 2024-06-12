var content_container = document.getElementById("content-container");

var content_map = new Map();
content_map.set('Explore', content_container.innerHTML);

var xhr = new XMLHttpRequest();
var category = "";

xhr.onloadend = (e) => {
	var json = JSON.parse(e.target.response);
	var components = "";

	json.contents.forEach((value) => {
		components += articleCard(value);
	});

	content_container.innerHTML = components;
	content_map.set(category, components);
}

function getCategoryContent(button) {
	category = button.id;
	if (!content_map.has(button.id)) {
		ajaxRequest(xhr, 'GET', '/Index?handler=CategoryArticles', { varName: 'category', value: button.id });
	}
	else {
		content_container.innerHTML = content_map.get(button.id);
	}
}