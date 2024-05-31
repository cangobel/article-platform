function ReplaceCharacters(text) {
	text = text.replace(/&ccedil;/g, "ç").replace(/&Ccedil;/g, "Ç").
					replace(/&ouml;/g, "ö").replace(/&Ouml;/g, "Ö").
					replace(/&uuml;/g, "ü").replace(/&Uuml;/g, "Ü");

	return text;
}