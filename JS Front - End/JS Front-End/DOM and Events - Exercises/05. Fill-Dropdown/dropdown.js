function addItem() {
	const newItemText = document.querySelector("#newItemText");
	const newItemValue = document.querySelector("#newItemValue");
	const menuList = document.querySelector("#menu");

	const option = document.createElement("option");
	option.textContent = newItemText.value;
	option.value = newItemValue.value;

	menuList.appendChild(option);
	newItemText.value = "";
	newItemValue.value = "";
}
