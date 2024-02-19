window.addEventListener("load", solve);

function solve() {
	const inputSelectors = {
		title: document.querySelector("#title"),
		description: document.querySelector("#description"),
		label: document.querySelector("#label"),
		points: document.querySelector("#points"),
		assignee: document.querySelector("#assignee"),
	};

	const tasks = {};
	const allTtasksContainer = document.querySelector("#tasks-section");
	const pointsContainer = document.querySelector("#total-sprint-points");
	const hidden = document.querySelector("#task-id");

	const icons = {
		Feature: "&#8865",
		"Low Priority Bug": "&#9737",
		"High Priority Bug": "&#9888",
	};

	const labelClasses = {
		Feature: "feature",
		"Low Priority Bug": "low-priority",
		"High Priority Bug": "high-priority",
	};

	const createBtn = document.querySelector("#create-task-btn");
	const deleteBtn = document.querySelector("#delete-task-btn");

	createBtn.addEventListener("click", createTask);
	deleteBtn.addEventListener("click", deleteTask);

	function createTask() {
		if (Object.values(inputSelectors).some((s) => s.value === "")) {
			return;
		}

		const task = Object.entries(inputSelectors).reduce(
			(acc, [key, selector]) => {
				acc[key] = selector.value;
				return acc;
			},
			{}
		);
		task["id"] = `task-${Object.values(tasks).length + 1}`;
		tasks[task.id] = task;

		const taskContainer = createElement(
			"article",
			null,
			task.id,
			["task-card"],
			allTtasksContainer,
			false
		);

		createElement(
			"div",
			`${task.label} ${icons[task.label]}`,
			null,
			["task-card-label", labelClasses[task.label]],
			taskContainer,
			true
		);

		createElement(
			"h3",
			task.title,
			null,
			["task-card-title"],
			taskContainer,
			false
		);

		createElement(
			"p",
			task.description,
			null,
			["task-card-description"],
			taskContainer,
			false
		);

		createElement(
			"div",
			`Estimated at ${task.points} pts`,
			null,
			["task-card-points"],
			taskContainer,
			false
		);

		createElement(
			"div",
			`Assigned to: ${task.assignee}`,
			null,
			["task-card-assignee"],
			taskContainer,
			false
		);

		const btnsContainer = createElement(
			"div",
			null,
			null,
			["task-card-actions"],
			taskContainer,
			false
		);

		const deleteTaskBtn = createElement(
			"button",
			"Delete",
			null,
			null,
			btnsContainer,
			false
		);

		deleteTaskBtn.addEventListener("click", loadConfirmDelete);

		pointsContainer.textContent = `Total Points ${calculateTotalPoints()}pts`;

		Object.values(inputSelectors).forEach((s) => (s.value = ""));
	}

	function loadConfirmDelete(e) {
		const currTaskContainer = e.currentTarget.parentElement.parentElement;
		const taskId = currTaskContainer.getAttribute("id");

		Object.entries(inputSelectors).forEach(([key, selector]) => {
			selector.value = tasks[taskId][key];
			selector.disabled = true;
		});

		hidden.textContent = taskId;

		createBtn.disabled = true;
		deleteBtn.disabled = false;
	}

	function deleteTask() {
		const taskId = hidden.textContent;
		const currTaskContainer = document.querySelector(`#${taskId}`);

		allTtasksContainer.removeChild(currTaskContainer);
		delete tasks[taskId];
		pointsContainer.textContent = `Total Points ${calculateTotalPoints()}pts`;
		Object.values(inputSelectors).forEach((s) => {
			s.value = "";
			s.disabled = false;
		});

		createBtn.disabled = false;
		deleteBtn.disabled = true;
	}

	function createElement(type, content, id, classes, parent, useInnerHTML) {
		const element = document.createElement(type);

		if (content) {
			if (useInnerHTML) {
				element.innerHTML = content;
			} else {
				element.textContent = content;
			}
		}

		if (id) {
			element.setAttribute("id", id);
		}

		if (classes && classes.length > 0) {
			element.classList.add(...classes);
		}

		if (parent) {
			parent.appendChild(element);
		}

		return element;
	}

	function calculateTotalPoints() {
		return Object.values(tasks).reduce((acc, curr) => {
			return acc + Number(curr.points);
		}, 0);
	}
}
