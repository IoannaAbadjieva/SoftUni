window.addEventListener("load", solve);

function solve() {
	const inputSelectors = {
		student: document.querySelector("#student"),
		university: document.querySelector("#university"),
		score: document.querySelector("#score"),
	};
	const previewList = document.querySelector("#preview-list");
	const candidatesList = document.querySelector("#candidates-list");
	const nextBtn = document.querySelector("#next-btn");
	nextBtn.addEventListener("click", (e) => {
		if (
			Object.values(inputSelectors).some((selector) => selector.value === "")
		) {
			return;
		}

		const student = inputSelectors.student.value;
		const university = inputSelectors.university.value;
		const score = inputSelectors.score.value;

		const studentContainer = createElement(
			"li",
			null,
			["application"],
			previewList
		);
		const article = createElement("article", null, null, studentContainer);
		createElement("h4", student, null, article);
		createElement("p", `University: ${university}`, null, article);
		createElement("p", `Score: ${score}`, null, article);
		const editBtn = createElement(
			"button",
			"edit",
			["action-btn", "edit"],
			studentContainer
		);
		const applyBtn = createElement(
			"button",
			"apply",
			["action-btn", "apply"],
			studentContainer
		);

		editBtn.addEventListener("click", (e) => {
			inputSelectors.student.value = student;
			inputSelectors.university.value = university;
			inputSelectors.score.value = score;

			previewList.removeChild(studentContainer);

			nextBtn.disabled = false;
		});

		applyBtn.addEventListener("click", (e) => {
			studentContainer.removeChild(editBtn);
			studentContainer.removeChild(applyBtn);

			previewList.removeChild(studentContainer);
			candidatesList.appendChild(studentContainer);
		});
		Object.values(inputSelectors).forEach((selector) => (selector.value = ""));
		nextBtn.disabled = true;
	});

	function createElement(type, content, classes, parent) {
		const element = document.createElement(type);

		if (content) {
			element.textContent = content;
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
