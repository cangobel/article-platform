function articleCard(props) {
	return `<div class="mt-4 rounded pb-2" style="box-shadow: 0px 0px 10px 1px rgba(0, 0, 0, 0.2);">
					<div class="d-flex">
						<img class="mt-4 ms-2" style="width:200px; height:150px;" />
						<div class="wdt-max-400 ms-3">
							<a class="dark-link ms-3" href=/GetArticle?articleId=${props.articleId}>
								<h3 class="m-0">${props.title}</h3>
							</a>
							<p class="overflow-hdn dots mt-2">
								ABCDEFASDFASDFASDFASERFIOAJSDÝLKFAEÝROFIASDLKCNAÝEORADLFVNADSÞLKNMVZEOÐÝDRIANDÞLFKVNAÞDSJFGA
								SDFÝALKSFNDÝALERFAODFNÝVAEÝORUADFLJKVN
							</p>
						</div>
					</div>
					<div class="d-flex flex-row-reverse me-3">
						<span class="">written by: ${props.userName}</span>
						<span class="me-3">${props.category}</span>
					</div>
				</div>`;
}