function SetDotNetObject(dotNetHelper) {
	window.dotNetHelper = dotNetHelper;
}

function SaveButtonOnClick(id, dotNetMethodName) {
	input = document.getElementById("popTextInput").value;
	var bundle = [input, id]

	if (input != null)
		window.dotNetHelper.invokeMethodAsync(dotNetMethodName, bundle);
}

function PopoverOnClick(id, dotNetMethodName) {
	$('#' + id).popover(
		{
			html: true,
			content: function () {
				var button = document.createElement("button");
				button.classList.add("btn", "btn-primary");
				button.innerHTML = "Save";
				button.onclick = () => SaveButtonOnClick(id, dotNetMethodName);

				var textInput = document.createElement("input", "text");
				textInput.classList.add("form-control");
				textInput.id = "popTextInput";

				var div = document.createElement("div");
				div.classList.add("input-group");

				div.appendChild(textInput)
				div.appendChild(button)

				return div;
			}
		}
	).popover('toggle');
}

function SetRenameButtonsId() {
	var elements = document.getElementsByClassName("btn-success");
	for (let i = 0; i < elements.length; i++) {
		elements[i].id = i;
	}
}
