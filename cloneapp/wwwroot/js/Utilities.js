function ReplaceCharacters(text) {
	text = text.replace(/&ccedil;/g, "�").replace(/&Ccedil;/g, "�").
					replace(/&ouml;/g, "�").replace(/&Ouml;/g, "�").
					replace(/&uuml;/g, "�").replace(/&Uuml;/g, "�");

	return text;
}