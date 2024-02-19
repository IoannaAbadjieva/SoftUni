function attachEvents() {
	selectors = {
		container: document.querySelector("#phonebook"),
		person: document.querySelector("#person"),
		phone: document.querySelector("#phone"),
	};

	const btnLoad = document.querySelector("#btnLoad");
	btnLoad.addEventListener("click", getPhonebook);

	const btnCreate = document.querySelector("#btnCreate");
	btnCreate.addEventListener("click", addToPhonebook);

	async function getPhonebook() {
		const phonebook = await (
			await fetch("http://localhost:3030/jsonstore/phonebook")
		).json();

		selectors.container.textContent = "";

		Object.values(phonebook).forEach(({ person, phone, _id }) => {
			const li = createElement(
				"li",
				`${person}: ${phone}`,
				"",
				[],
				selectors.container
			);

			const deleteBtn = createElement("button", "Delete", _id, [], li);
			deleteBtn.addEventListener("click", deletePersonInfo);
		});
	}
	async function addToPhonebook() {
		const personInfo = {
			person: selectors.person.value,
			phone: selectors.phone.value,
		};

		await fetch("http://localhost:3030/jsonstore/phonebook", {
			method: "POST",
			body: JSON.stringify(personInfo),
		});

		selectors.person.value = "";
		selectors.phone.value = "";
		getPhonebook();
	}

	async function deletePersonInfo(e) {
		const id = e.currentTarget.id;

		await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`, {
			method: "DELETE",
		});

		getPhonebook();
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
