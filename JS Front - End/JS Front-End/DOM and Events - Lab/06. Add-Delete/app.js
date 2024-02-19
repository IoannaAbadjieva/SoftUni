function addItem() {
  const text = document.querySelector("#newItemText").value;
  const li = document.createElement("li");
  li.textContent = text;

  const deleteButton = document.createElement("a");
  deleteButton.textContent = "[Delete]";
  deleteButton.href = "#";
  deleteButton.addEventListener("click", (e) =>
    e.target.parentElement.remove()
  );

  li.appendChild(deleteButton);
  document.querySelector("#items").appendChild(li);
  document.querySelector("#newItemText").value = "";
}
