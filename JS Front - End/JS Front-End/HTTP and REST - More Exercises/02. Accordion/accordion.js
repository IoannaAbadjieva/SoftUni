window.onload = solution();

function solution() {
	const mainContainer = document.querySelector("#main");

	fetch("http://localhost:3030/jsonstore/advanced/articles/list")
		.then((response) => response.json())
		.then((articles) =>
			articles.forEach(({ _id, title }) => {
				const accordion = createElement(
					"div",
					null,
					null,
					["accordion"],
					mainContainer
				);

				const headContainer = createElement(
					"div",
					null,
					null,
					["head"],
					accordion
				);

				createElement("span", title, null, null, headContainer);
				const moreBtn = createElement(
					"button",
					"More",
					_id,
					["button"],
					headContainer
				);

				fetch(
					`http://localhost:3030/jsonstore/advanced/articles/details/${_id}`
				)
					.then((res) => res.json())
					.then(({ _id, title, content }) => {
						const extraContainer = createElement(
							"div",
							null,
							null,
							["extra"],
							accordion
						);

						createElement("p", content, null, null, extraContainer);
					});

				moreBtn.addEventListener("click", (e) => {
					const currentArticleContainer =
						e.currentTarget.parentElement.parentElement;

					const extraContainer =
						currentArticleContainer.querySelector("div.extra");

					e.currentTarget.textContent =
						e.currentTarget.textContent === "More" ? "Less" : "More";

					extraContainer.style.display =
						extraContainer.style.display !== "block" ? "block" : "none";
				});
			})
		);

	function createElement(type, content, id, classes, parent) {
		const element = document.createElement(type);

		if (content) {
			element.textContent = content;
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
}
