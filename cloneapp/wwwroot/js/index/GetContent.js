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
var lastClickedCategory = 'Explore';

function getCategoryContent(button) {
    focus(button);
    lastClickedCategory = button.id;

    if (!content_map.has(button.id)) {
        xhr.onloadend = getCategoryContentCallback;
        ajaxRequest(xhr, 'GET', '/Index?handler=CategoryArticlesProps', { varNames: ['category', 'lastArticleId'], values: [button.id, 0] });
    }
    else {
        content_container.innerHTML = content_map.get(button.id).components;
    }
}

function getCategoryContentScrollEnd() {
    var lastArticleId = content_map.get(lastClickedCategory).lastArticleId;
    xhr.onloadend = getContentScrollEndCallback;

    if (lastClickedCategory != 'Explore')
        ajaxRequest(xhr, 'GET', '/Index?handler=CategoryArticlesProps', { varNames: ['category', 'lastArticleId'], values: [lastClickedCategory, lastArticleId] });
    else
        ajaxRequest(xhr, 'GET', '/Index?handler=ExploreArticlesProps', { varNames: ['category', 'lastArticleId'], values: [lastClickedCategory, lastArticleId] });
}

function getExploreContent(button) {
    focus(button);
    lastClickedCategory = button.id;
    content_container.innerHTML = content_map.get('Explore').components;
}

function getCategoryContentCallback(e) {
    var newCategoryContent = parseResponse(e.target.response);

    if (newCategoryContent != null) {
        content_container.innerHTML = newCategoryContent.components;
        content_map.set(lastClickedCategory, newCategoryContent);
    }
}

function getContentScrollEndCallback(e) {
    var newCategoryContent = parseResponse(e.target.response);

    if (newCategoryContent != null) {
        content_container.innerHTML += newCategoryContent.components;

        var categoryContent = content_map.get(lastClickedCategory);
        categoryContent.components += newCategoryContent.components;
        categoryContent.lastArticleId = newCategoryContent.lastArticleId;
    }
}

function parseResponse(response) {
    if (response == 'null') {
        return null;
    }

    var json = JSON.parse(response);
    var newComponents = "";

    json.contents.forEach((value) => {
        newComponents += articleCard(value);
    });

    return new CategoryContent(newComponents, json.lastArticleId);
}