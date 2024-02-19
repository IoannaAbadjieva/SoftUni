window.addEventListener("load", solve);
function solve() {
	const inputSelectors = {
		title: document.querySelector("#task-title"),
		category: document.querySelector("#task-category"),
		content: document.querySelector("#task-content"),
	};

	const containersSelectors = {
		reviewList: document.querySelector("#review-list"),
		publisheLdist: document.querySelector("#published-list"),
	};

	const publishBtn = document.querySelector("#publish-btn");
	publishBtn.addEventListener("click", publishTask);

	function publishTask() {
		if (
			Object.values(inputSelectors).some((selector) => selector.value === "")
		) {
			return;
		}

		const title = inputSelectors.title.value;
		const category = inputSelectors.category.value;
		const content = inputSelectors.content.value;

		const listItem = createElement(
			"li",
			null,
			["rpost"],
			containersSelectors.reviewList
		);

		const article = createElement("article", null, [], listItem);
		createElement("h4", title, [], article);
		createElement("p", `Category: ${category}`, [], article);
		createElement("p", `Content: ${content}`, [], article);

		const editBtn = createElement(
			"button",
			"Edit",
			["action-btn", "edit"],
			listItem
		);

		editBtn.addEventListener("click", (e) => {
			containersSelectors.reviewList.removeChild(listItem);

			inputSelectors.title.value = title;
			inputSelectors.category.value = category;
			inputSelectors.content.value = content;
		});

		const postBtn = createElement(
			"button",
			"Post",
			["action-btn", "post"],
			listItem
		);
		postBtn.addEventListener("click", (e) => {
			listItem.removeChild(editBtn);
			listItem.removeChild(postBtn);
			containersSelectors.reviewList.removeChild(listItem);
			containersSelectors.publisheLdist.appendChild(listItem);
		});

		Object.values(inputSelectors).forEach((selector) => (selector.value = ""));
	}

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
