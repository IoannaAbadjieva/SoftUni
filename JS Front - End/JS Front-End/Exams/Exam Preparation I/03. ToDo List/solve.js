// TODO
function attachEvents() {
	const URLs = {
		BaseURL: "http://localhost:3030/jsonstore/tasks",
		taskURL: (id) => `http://localhost:3030/jsonstore/tasks/${id}`,
	};

	const titleInput = document.querySelector("#title");
	const addBtn = document.querySelector("#add-button");
	const loadBtn = document.querySelector("#load-button");
	const tasksContainer = document.querySelector("#todo-list");

	loadBtn.addEventListener("click", loadAllTasks);
	addBtn.addEventListener("click", addNewTasks);

	function loadAllTasks(e) {
		e.preventDefault();
		fetch(URLs.BaseURL)
			.then((res) => res.json())
			.then((tasks) => {
				tasksContainer.innerHTML = "";
				Object.values(tasks).forEach(({ name, _id }) => {
					const li = createElement("li", null, null, tasksContainer);
					createElement("span", name, null, li);
					const removeBtn = createElement("button", "Remove", _id, li);
					const editBtn = createElement("button", "Edit", _id, li);

					removeBtn.addEventListener("click", removeTask);
					editBtn.addEventListener("click", editTask);
				});
			})
			.catch((err) => {
				console.log(err.message);
			});
	}

	function addNewTasks(e) {
		e.preventDefault();
		if (titleInput.value === "") {
			return;
		}

		fetch(URLs.BaseURL, {
			method: "POST",
			body: JSON.stringify({ name: titleInput.value }),
		}).catch((err) => {
			console.log(err.message);
		});

		titleInput.value = "";
		loadAllTasks(e);
	}

	function removeTask(e) {
		const taskId = e.currentTarget.dataset["taskid"];

		fetch(URLs.taskURL(taskId), {
			method: "DELETE",
		}).catch((err) => {
			console.log(err.message);
		});

		loadAllTasks(e);
	}

	function editTask(e) {
		if (e.currentTarget.textContent === "Edit") {
			sendTaskForEditing(e);
		} else {
			submitTask(e);
		}
	}

	function sendTaskForEditing(e) {
		const currTaskContainer = e.currentTarget.parentElement;
		const spanElement = currTaskContainer.querySelector("span");
		const inputElement = document.createElement("input");
		inputElement.value = spanElement.textContent;

		currTaskContainer.replaceChild(inputElement, spanElement);

		e.currentTarget.textContent = "Submit";
	}

	function submitTask(e) {
		const taskId = e.currentTarget.dataset["taskid"];
		const inputField = e.currentTarget.parentElement.querySelector("input");

		if (inputField.value === "") {
			return;
		}

		fetch(URLs.taskURL(taskId), {
			method: "PATCH",
			body: JSON.stringify({ name: inputField.value }),
		}).catch((err) => {
			console.log(err.message);
		});

		loadAllTasks(e);
	}

	function createElement(type, content, id, parent) {
		element = document.createElement(type);

		if (content) {
			element.textContent = content;
		}

		if (id) {
			element.setAttribute("data-taskid", id);
		}

		if (parent) {
			parent.appendChild(element);
		}

		return element;
	}
}

attachEvents();
