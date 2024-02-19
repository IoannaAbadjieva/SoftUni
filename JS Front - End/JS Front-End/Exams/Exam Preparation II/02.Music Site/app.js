window.addEventListener("load", solve);

function solve() {
	const inputSelectors = {
		genre: document.querySelector("#genre"),
		name: document.querySelector("#name"),
		author: document.querySelector("#author"),
		date: document.querySelector("#date"),
	};

	const hitsContainer = document.querySelector(".all-hits-container");
	const savedContainer = document.querySelector(".saved-container");

	const addBtn = document.querySelector("#add-btn");
	addBtn.addEventListener("click", (e) => {
		e.preventDefault();
		if (Object.values(inputSelectors).some((s) => s.value === "")) {
			return;
		}
		const genre = inputSelectors.genre.value;
		const name = inputSelectors.name.value;
		const author = inputSelectors.author.value;
		const date = inputSelectors.date.value;

		const songContainer = createElement(
			"div",
			null,
			null,
			["hits-info"],
			hitsContainer
		);

		createElement("img", null, "./static/img/img.png", null, songContainer);

		createElement("h2", `Genre: ${genre}`, null, null, songContainer);

		createElement("h2", `Name: ${name}`, null, null, songContainer);

		createElement("h2", `Author: ${author}`, null, null, songContainer);

		createElement("h3", `Date: ${date}`, null, null, songContainer);

		const saveBtn = createElement(
			"button",
			"Save song",
			null,
			["save-btn"],
			songContainer
		);
		const likeBtn = createElement(
			"button",
			"Like song",
			null,
			["like-btn"],
			songContainer
		);
		const deleteBtn = createElement(
			"button",
			"Delete",
			null,
			["delete-btn"],
			songContainer
		);

		Object.values(inputSelectors).forEach((s) => (s.value = ""));

		saveBtn.addEventListener("click", (e) => {
			hitsContainer.removeChild(songContainer);
			songContainer.removeChild(saveBtn);
			songContainer.removeChild(likeBtn);
			savedContainer.appendChild(songContainer);
		});

		likeBtn.addEventListener("click", (e) => {
			const likesParagraph = document.querySelector(".likes p");
			let totalLikes = Number(
				likesParagraph.textContent.split("Total Likes: ").pop()
			);

			likesParagraph.textContent = `Total Likes: ${++totalLikes}`;
			likeBtn.disabled = true;
		});

		deleteBtn.addEventListener("click", (e) => {
			const songContainer = e.currentTarget.parentElement;
			const container = e.currentTarget.parentElement.parentElement;
			container.removeChild(songContainer);
		});
	});

	function createElement(type, content, source, classes, parent) {
		const element = document.createElement(type);

		if (content) {
			element.textContent = content;
		}

		if (source) {
			element.src = source;
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
