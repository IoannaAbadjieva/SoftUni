const BaseURL = "http://localhost:3030/jsonstore/tasks";

const courses = {};

const validTypes = ["Long", "Medium", "Short"];

const inputSelectors = {
	title: document.querySelector("#course-name"),
	type: document.querySelector("#course-type"),
	description: document.querySelector("#description"),
	teacher: document.querySelector("#teacher-name"),
};

const allCoursesContainer = document.querySelector("#list");

const loadCoursesBtn = document.querySelector("#load-course");
loadCoursesBtn.addEventListener("click", loadCourses);

const addCourseBtn = document.querySelector("#add-course");
addCourseBtn.addEventListener("click", addCourse);

const editCourseBtn = document.querySelector("#edit-course");
editCourseBtn.addEventListener("click", editCourse);

async function loadCourses(e) {
	e.preventDefault();
	let coursesData;
	try {
		const response = await fetch(BaseURL);
		coursesData = await response.json();
	} catch (err) {
		console.log(err.message);
	}

	allCoursesContainer.innerHTML = "";

	Object.values(coursesData).forEach(
		({ title, type, description, teacher, _id }) => {
			const courseContainer = createElement(
				"div",
				null,
				null,
				["container"],
				allCoursesContainer
			);

			createElement("h2", title, null, null, courseContainer);
			createElement("h3", teacher, null, null, courseContainer);
			createElement("h3", type, null, null, courseContainer);
			createElement("h4", description, null, null, courseContainer);

			const editBtn = createElement(
				"button",
				"Edit Course",
				_id,
				["edit-btn"],
				courseContainer
			);

			const finishBtn = createElement(
				"button",
				"Finish Course",
				_id,
				["finish-btn"],
				courseContainer
			);

			courses[_id] = { title, type, description, teacher, _id };

			editBtn.addEventListener("click", loadEditCourse);
			finishBtn.addEventListener("click", finishCourse);
		}
	);
}

async function addCourse(e) {
	e.preventDefault();
	if (Object.values(inputSelectors).some((selector) => selector.value === "")) {
		return;
	}

	if (!validTypes.includes(inputSelectors.type.value)) {
		return;
	}

	const newCourse = Object.entries(inputSelectors).reduce(
		(acc, [key, selector]) => {
			acc[key] = selector.value;
			return acc;
		},
		{}
	);

	try {
		await fetch(BaseURL, {
			method: "POST",
			body: JSON.stringify(newCourse),
		});
	} catch (err) {
		console.log(err.message);
	}

	Object.values(inputSelectors).forEach((selector) => (selector.value = ""));
	await loadCourses(e);
}

async function editCourse(e) {
	e.preventDefault();
	const courseId = e.currentTarget.dataset["courseid"];

	if (Object.values(inputSelectors).some((selector) => selector.value === "")) {
		return;
	}

	if (!validTypes.includes(inputSelectors.type.value)) {
		return;
	}

	const course = Object.entries(inputSelectors).reduce(
		(acc, [key, selector]) => {
			acc[key] = selector.value;
			return acc;
		},
		{}
	);

	try {
		await fetch(`${BaseURL}/${courseId}`, {
			method: "PUT",
			body: JSON.stringify(course),
		});
	} catch (err) {
		console.log(err.message);
	}

	Object.values(inputSelectors).forEach((selector) => (selector.value = ""));
	editCourseBtn.disabled = true;
	addCourseBtn.disabled = false;
	await loadCourses(e);
}

function loadEditCourse(e) {
	const courseId = e.currentTarget.dataset["courseid"];
	const courseContainer = e.currentTarget.parentElement;

	Object.entries(inputSelectors).forEach(([key, selector]) => {
		selector.value = courses[courseId][key];
	});

	allCoursesContainer.removeChild(courseContainer);
	editCourseBtn.disabled = false;
	addCourseBtn.disabled = true;

	editCourseBtn.setAttribute("data-courseid", courseId);
	delete courses[courseId];
}

async function finishCourse(e) {
	const courseId = e.currentTarget.dataset["courseid"];

	try {
		await fetch(`${BaseURL}/${courseId}`, {
			method: "DELETE",
		});
	} catch (err) {
		console.log(err.message);
	}

	delete courses[courseId];
	await loadCourses(e);
}

function createElement(type, content, id, classes, parent) {
	const element = document.createElement(type);

	if (content) {
		element.textContent = content;
	}

	if (id) {
		element.setAttribute("data-courseid", id);
	}

	if (classes && classes.length > 0) {
		element.classList.add(...classes);
	}

	if (parent) {
		parent.appendChild(element);
	}

	return element;
}
