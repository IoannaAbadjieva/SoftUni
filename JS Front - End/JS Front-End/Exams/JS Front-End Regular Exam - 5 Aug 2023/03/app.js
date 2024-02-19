const BaseURL = "http://localhost:3030/jsonstore/tasks";

const vacations = {};
const inputSelectors = {
	name: document.querySelector("#name"),
	days: document.querySelector("#num-days"),
	date: document.querySelector("#from-date"),
};

const addVacationBtn = document.querySelector("#add-vacation");
const editVacationBtn = document.querySelector("#edit-vacation");
const loadVacationsBtn = document.querySelector("#load-vacations");

const vacationsContainer = document.querySelector("#list");

loadVacationsBtn.addEventListener("click", loadVacations);
addVacationBtn.addEventListener("click", addVacation);
editVacationBtn.addEventListener("click", editVacation);

async function loadVacations() {
	const response = await fetch(BaseURL);
	const vacationsData = await response.json();
	vacationsContainer.innerHTML = "";

	Object.values(vacationsData).forEach(({ name, days, date, _id }) => {
		const container = createElement(
			"div",
			null,
			null,
			["container"],
			vacationsContainer
		);
		createElement("h2", name, null, null, container);
		createElement("h3", date, null, null, container);
		createElement("h3", days, null, null, container);
		const changeBtn = createElement(
			"button",
			"Change",
			_id,
			["change-btn"],
			container
		);
		const doneBtn = createElement(
			"button",
			"Done",
			_id,
			["done-btn"],
			container
		);

		vacations[_id] = { name, days, date, _id };

		changeBtn.addEventListener("click", loadChange);
		doneBtn.addEventListener("click", doneVacation);
	});
}

async function addVacation(e) {
	e.preventDefault();
	if (Object.values(inputSelectors).some((selector) => selector.value === "")) {
		return;
	}

	const newVacation = Object.entries(inputSelectors).reduce(
		(acc, [key, selector]) => {
			acc[key] = selector.value;
			return acc;
		},
		{}
	);

	await fetch(BaseURL, {
		method: "POST",
		body: JSON.stringify(newVacation),
	});

	Object.values(inputSelectors).forEach((selector) => (selector.value = ""));

	await loadVacations();
}

function loadChange(e) {
	const vacationId = e.currentTarget.dataset["vacationid"];

	const currContainer = e.currentTarget.parentElement;
	vacationsContainer.removeChild(currContainer);

	Object.keys(inputSelectors).forEach((key) => {
		inputSelectors[key].value = vacations[vacationId][key];
	});

	addVacationBtn.disabled = true;
	editVacationBtn.disabled = false;
	editVacationBtn.setAttribute("data-vacationid", vacationId);
}

async function editVacation(e) {
	e.preventDefault();
	const vacationId = e.currentTarget.dataset["vacationid"];
	if (Object.values(inputSelectors).some((selector) => selector.value === "")) {
		return;
	}

	const vacation = Object.entries(inputSelectors).reduce(
		(acc, [key, selector]) => {
			acc[key] = selector.value;
			return acc;
		},
		{}
	);

	await fetch(`${BaseURL}/${vacationId}`, {
		method: "PUT",
		body: JSON.stringify(vacation),
	});

	Object.values(inputSelectors).forEach((selector) => (selector.value = ""));
	delete vacations[vacationId];

	addVacationBtn.disabled = false;
	editVacationBtn.disabled = true;

	await loadVacations();
}

async function doneVacation(e) {
	const vacationId = e.currentTarget.dataset["vacationid"];

	await fetch(`${BaseURL}/${vacationId}`, {
		method: "DELETE",
	});

	delete vacations[vacationId];

	await loadVacations();
}

function createElement(type, content, id, classes, parent) {
	const element = document.createElement(type);

	if (content) {
		element.textContent = content;
	}

	if (id) {
		element.setAttribute("data-vacationid", id);
	}

	if (classes && classes.length > 0) {
		element.classList.add(...classes);
	}

	if (parent) {
		parent.appendChild(element);
	}

	return element;
}
