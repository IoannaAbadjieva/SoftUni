function attachEvents() {
	const selectors = {
		container: document.querySelector("tbody"),
		formheader: document.querySelector("#form h3"),
		title: document.querySelector('input[name="title"]'),
		author: document.querySelector('input[name="author"]'),
	};

	const loadBtn = document.querySelector("#loadBooks");
	const submitBtn = document.querySelector("#form button");

	loadBtn.addEventListener("click", loadAllBooks);
	submitBtn.addEventListener("click", handleFormSubmission);

	async function loadAllBooks() {
		const books = await (
			await fetch("http://localhost:3030/jsonstore/collections/books")
		).json();

		selectors.container.innerHTML = "";

		Object.entries(books).forEach(([_id, bookInfo]) => {
			const row = createElement("tr", "", "", [], selectors.container);
			createElement("td", bookInfo.title, "", [], row);
			createElement("td", bookInfo.author, "", [], row);
			const buttons = createElement("td", "", "", [], row);
			const editBtn = createElement("button", "Edit", _id, [], buttons);
			const deleteBtn = createElement("button", "Delete", _id, [], buttons);

			editBtn.addEventListener("click", editBook);
			deleteBtn.addEventListener("click", deleteBook);
		});
	}

	function editBook(e) {
		const title =
			e.currentTarget.parentElement.parentElement.querySelector(
				"td:first-child"
			).textContent;
		const author =
			e.currentTarget.parentElement.parentElement.querySelector(
				"td:nth-child(2)"
			).textContent;

		selectors.formheader.textContent = "Edit FORM";
		selectors.title.value = title;
		selectors.author.value = author;
		submitBtn.setAttribute("data-bookid", e.currentTarget.dataset.bookid);
		submitBtn.textContent = "Save";
	}

	async function handleFormSubmission(e) {
		if (submitBtn.textContent === "Submit") {
			submitBook();
		} else {
			saveBook(e);
		}
	}

	async function submitBook() {
		let book = {
			title: selectors.title.value,
			author: selectors.author.value,
		};

		if (Object.values(book).some((b) => b === "")) {
			return;
		}

		await fetch("http://localhost:3030/jsonstore/collections/books", {
			method: "POST",
			body: JSON.stringify(book),
		});

		loadAllBooks();
	}

	async function saveBook(e) {
		let book = {
			title: selectors.title.value,
			author: selectors.author.value,
		};

		if (Object.values(book).some((b) => b === "")) {
			return;
		}

		const bookId = e.currentTarget.dataset.bookid;

		await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`, {
			method: "PUT",
			body: JSON.stringify(book),
		});

		selectors.title.value = "";
		selectors.author.value = "";
		selectors.formheader.textContent = "FORM";
		submitBtn.textContent = "Submit";

		loadAllBooks();
	}

	async function deleteBook(e) {
		const bookId = e.currentTarget.dataset.bookid;
		await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`, {
			method: "DELETE",
		});

		loadAllBooks();
	}

	function createElement(type, textContent, id, classes, parent) {
		const element = document.createElement(type);

		if (textContent) {
			element.textContent = textContent;
		}

		if (id) {
			element.setAttribute("data-bookid", id);
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
