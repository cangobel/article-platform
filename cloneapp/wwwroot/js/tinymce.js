var ArticleId;

function setArticleId(id) {
	ArticleId = id;
}

function initTinyMce() {
	var keyFirstComponent = "tinymce-autosave-/WriteArticle?articleId=";
	var keyContentLastComponent = "-textArea-draft";

	var contentKey = keyFirstComponent + ArticleId + keyContentLastComponent;

	var entireHeight = document.getElementsByTagName("html")[0].clientHeight;

	tinymce.init({
		selector: 'textArea',
		plugins: 'save autosave anchor autolink charmap codesample emoticons image link lists media searchreplace table visualblocks wordcount codesample',
		toolbar: 'undo redo save  | blocks fontfamily fontsize | bold italic underline strikethrough codesample | link image media table mergetags | align lineheight | tinycomments | checklist numlist bullist indent outdent | emoticons charmap | removeformat',
		menubar: 'basicitem file edit insert view format table tools help',
		tinycomments_mode: 'embedded',
		tinycomments_author: 'Author name',
		mergetags_list: [
			{ value: 'First.Name', title: 'First Name' },
			{ value: 'Email', title: 'Email' },
		],
		height: entireHeight,
		autosave_interval: '10s',
		save_onsavecallback: function () {
			let content = tinymce.activeEditor.getContent();
			content = ReplaceCharacters(content);

			let domContent = document.createRange().createContextualFragment(content);
			let title = domContent.firstChild.textContent;

			content = content.replace("<h1>" + title + "</h1>", "");

			if (domContent.firstChild.nodeName == "H1" && domContent.firstChild.textContent.length != 0) {
				//ajax post
				$.ajax({
					type: "POST",
					url: "/WriteArticle?handler=SaveArticle",
					data: { "title": title, "content": content, "articleId": ArticleId },
					contentType: "application/x-www-form-urlencoded;charset=utf-8",
					beforeSend: function (xhr) {
						xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
					},
					success: function (response) {
					},
					failure: function (response) {
					},
					error: function (response) {
					}
				});
			}
			else {
				alert("Kayýt için Heading 1 türü baþlýk, makalenin baþýna konulmalý.");
			}
		},
		automatic_uploads: true,
		images_upload_url: '/WriteArticle/?handler=UploadImage',
		images_upload_path: '/uploads',
		setup: function (editor) {
			editor.on('init', function (e) {
				var content = localStorage.getItem(contentKey)
				if (content != null) {
					editor.setContent(content);
				}
				else {
					$.ajax({
						type: "POST",
						url: "/WriteArticle?handler=GetArticle",
						data: { "articleId": ArticleId },
						contentType: "application/x-www-form-urlencoded;charset=utf-8",
						beforeSend: function (xhr) {
							xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
						},
						success: function (response) {
							editor.setContent(response.content);
						},
						failure: function (response) {
						},
						error: function (response) {
						}
					});
				}
			});
		}
	});
}


function ReplaceCharacters(text) {
	text = text.replace(/&ccedil;/g, "ç").replace(/&Ccedil;/g, "Ç").
				replace(/&ouml;/g, "ö").replace(/&Ouml;/g, "Ö").
				replace(/&uuml;/g, "ü").replace(/&Uuml;/g, "Ü");

	return text;
}

window.onload = function () {
	//tiny editor border radius'u sýfýra eþitleme
	var tiny = document.getElementsByClassName("tox-tinymce")[0];
	tiny.style.borderRadius = "0"
}