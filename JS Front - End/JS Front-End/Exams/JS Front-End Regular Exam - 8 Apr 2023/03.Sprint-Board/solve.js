// TODO:
function attachEvents() {
	const BaseURL = `http://localhost:3030/jsonstore/tasks`;
	const inputSelectors = {
		title: document.querySelector("#title"),
		description: document.querySelector("#description"),
	};

	const nextStatus = {
		ToDo: "In Progress",
		"In Progress": "Code Review",
		"Code Review": "Done",
		Done: "Close",
	};

	const tasks = {};

	const sectionIds = {
		ToDo: "#todo-section",
		"In Progress": "#in-progress-section",
		"Code Review": "#code-review-section",
		Done: "#done-section",
	};

	const loadBoardBtn = document.querySelector("#load-board-btn");
	const addTaskBtn = document.querySelector("#create-task-btn");

	const containers = Array.from(document.querySelectorAll(".task-list"));
	// console.log(containers);

	loadBoardBtn.addEventListener("click", loadBoard);
	addTaskBtn.addEventListener("click", addTask);

	async function loadBoard() {
		let tasksData;
		try {
			const response = await fetch(BaseURL);
			tasksData = await response.json();
		} catch (err) {
			console.log(err.message);
			return;
		}

		containers.forEach((c) => (c.innerHTML = ""));

		Object.values(tasksData).forEach(({ title, description, status, _id }) => {
			const taskContainer = document.querySelector(`${sectionIds[status]} ul`);
			const li = createElement("li", null, null, ["task"], taskContainer);
			createElement("h3", title, null, null, li);
			createElement("p", description, null, null, li);
			const moveBtn = createElement(
				"button",
				status !== "Done"
					? `Move to ${nextStatus[status]}`
					: nextStatus[status],
				_id,
				null,
				li
			);
			tasks[_id] = { title, description, status, _id };
			moveBtn.addEventListener("click", moveToNextStatus);
		});
	}
	async function addTask() {
		if (
			Object.values(inputSelectors).some((selector) => selector.value === "")
		) {
			return;
		}

		const newTask = {
			title: inputSelectors.title.value,
			description: inputSelectors.description.value,
			status: "ToDo",
		};

		try {
			await fetch(BaseURL, {
				method: "POST",
				body: JSON.stringify(newTask),
			});
		} catch (err) {
			console.log(err.message);
			return;
		}

		Object.values(inputSelectors).forEach((selector) => (selector.value = ""));
		await loadBoard();
	}
	async function moveToNextStatus(e) {
		const taskId = e.currentTarget.dataset["taskid"];
		console.log(taskId);

		const taskToChange = tasks[taskId];
		taskToChange.status = nextStatus[taskToChange.status];

		const queryMethod = taskToChange.status !== "Close" ? "PATCH" : "DELETE";

		try {
			await fetch(`${BaseURL}/${taskId}`, {
				method: queryMethod,
				body: JSON.stringify(taskToChange),
			});
		} catch (err) {
			console.log(err.message);
		}

		delete tasks[taskId];
		await loadBoard();
	}

	function createElement(type, content, id, classes, parent) {
		const element = document.createElement(type);

		if (content) {
			element.textContent = content;
		}

		if (id) {
			element.setAttribute("data-taskid", id);
		}

		if (classes && classes.length > 0) {
			element.classList.add(...classes);
		}

		if (parent) {
			parent.appendChild(element);
		}

		return element;
	}
}

attachEvents();
