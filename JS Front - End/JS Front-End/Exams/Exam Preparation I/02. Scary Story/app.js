window.addEventListener("load", solve);

function solve() {
	const inputSelectors = {
		firstName: document.querySelector("#first-name"),
		lastName: document.querySelector("#last-name"),
		age: document.querySelector("#age"),
		title: document.querySelector("#story-title"),
		genre: document.querySelector("#genre"),
		story: document.querySelector("#story"),
	};

	const container = document.querySelector("#preview-list");
	const mainContainer = document.querySelector("#main");

	const publishBtn = document.querySelector("#form-btn");
	publishBtn.addEventListener("click", () => {
		if (
			Object.values(inputSelectors).some((selector) => selector.value === "")
		) {
			return;
		}

		let storyInfo = Object.entries(inputSelectors).reduce(
			(acc, [key, selector]) => {
				acc[key] = selector.value;
				return acc;
			},
			{}
		);

		const li = createElement("li", null, ["story-info"], container);
		const article = createElement("article", null, null, li);
		createElement(
			"h4",
			`Name: ${storyInfo.firstName} ${storyInfo.lastName}`,
			null,
			article
		);
		createElement("p", `Age: ${storyInfo.age}`, null, article);
		createElement("p", `Title: ${storyInfo.title}`, null, article);
		createElement("p", `Genre: ${storyInfo.genre}`, null, article);
		createElement("p", storyInfo.story, null, article);
		const saveBtn = createElement("button", "Save Story", ["save-btn"], li);
		const editBtn = createElement("button", "Edit Story", ["edit-btn"], li);
		const deleteBtn = createElement(
			"button",
			"Delete Story",
			["delete-btn"],
			li
		);

		saveBtn.addEventListener("click", () => {
			mainContainer.innerHTML = "";
			createElement("h1", "Your scary story is saved!", null, mainContainer);
		});

		editBtn.addEventListener("click", () => {
			Object.entries(inputSelectors).forEach(([key, selector]) => {
				selector.value = storyInfo[key];
			});

			container.removeChild(li);
			publishBtn.disabled = false;
		});

		deleteBtn.addEventListener("click", () => {
			container.removeChild(li);
			publishBtn.disabled = false;
		});

		Object.values(inputSelectors).forEach((selector) => (selector.value = ""));
		publishBtn.disabled = true;
	});

	function createElement(type, content, classes, parent) {
		element = document.createElement(type);

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
