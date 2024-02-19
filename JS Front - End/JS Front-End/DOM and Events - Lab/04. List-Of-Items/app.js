function addItem() {
  const text = document.querySelector("#newItemText").value;
  const li = document.createElement("li");
  li.textContent = text;
  document.querySelector("#items").appendChild(li);

  document.querySelector("#newItemText").value = "";
}
