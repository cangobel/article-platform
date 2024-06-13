class CategoryContent {
	constructor(components, lastArticleId = 0) {
		this.components = components;
		this.lastArticleId = lastArticleId;
	}
}

var content_container = document.getElementById("content-container");

var content_map = new Map();
content_map.set('Explore', new CategoryContent(content_container.innerHTML, getLastArticleId()));

var xhr = new XMLHttpRequest();
var lastClickedCategory = "";

xhr.onloadend = (e) => {
	var json = JSON.parse(e.target.response);
	var components = "";

	json.contents.forEach((value) => {
		components += articleCard(value);
	});

	content_container.innerHTML = components;
	content_map.set(lastClickedCategory, new CategoryContent(components, json.lastArticleId));
}

function getCategoryContent(button) {
	lastClickedCategory = button.id;

	if (!content_map.has(button.id)) {
		ajaxRequest(xhr, 'GET', '/Index?handler=CategoryArticlesProps', { varNames: ['category', 'lastArticleId'], values: [button.id, 0] });
	}
	else {
		content_container.innerHTML = content_map.get(button.id).components;
	}
}

function getExploreContent() {
	content_container.innerHTML = content_map.get('Explore').components;
}