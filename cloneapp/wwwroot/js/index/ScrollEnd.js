window.onscroll = function () {
	var scrollPoint = window.scrollY + window.innerHeight;
	var totalScrollHeight = document.body.scrollHeight;

	if (scrollPoint >= totalScrollHeight) {
		getCategoryContentScrollEnd();
	}
}