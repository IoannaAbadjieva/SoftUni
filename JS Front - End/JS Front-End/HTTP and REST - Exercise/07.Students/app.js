function attachEvents() {
	const container = document.querySelector("#results tbody");
	const submitBtn = document.querySelector("#submit");
	const formSelectors = {
		firstName: document.querySelector('input[name="firstName"]'),
		lastName: document.querySelector('input[name="lastName"]'),
		facultyNumber: document.querySelector('input[name="facultyNumber"]'),
		grade: document.querySelector('input[name="grade"]'),
	};

	submitBtn.addEventListener("click", addStudent);
	loadStudents();

	function loadStudents() {
		fetch("http://localhost:3030/jsonstore/collections/students")
			.then((res) => res.json())
			.then((students) => {
				Object.values(students).forEach(
					({ firstName, lastName, facultyNumber, grade }) => {
						const row = createElement("tr", "", "", [], container);
						createElement("td", firstName, "", [], row);
						createElement("td", lastName, "", [], row);
						createElement("td", facultyNumber, "", [], row);
						createElement("td", grade, "", [], row);
					}
				);
			})
			.catch((err) => {
				console.log(err);
			});
	}

	function addStudent() {
		let student = {
			firstName: formSelectors.firstName.value,
			lastName: formSelectors.lastName.value,
			facultyNumber: formSelectors.facultyNumber.value,
			grade: formSelectors.grade.value,
		};

		if (Object.values(student).some((value) => value === "")) {
			return;
		}

		fetch("http://localhost:3030/jsonstore/collections/students", {
			method: "POST",
			body: JSON.stringify(student),
		}).catch((err) => {
			console.log(err.message);
		});

		Object.values(formSelectors).forEach((selector) => {
			selector.value = "";
		});

		loadStudents();
	}

	function createElement(type, textContent, id, classes, parent) {
		const element = document.createElement(type);

		if (textContent) {
			element.textContent = textContent;
		}

		if (id) {
			element.id = id;
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
