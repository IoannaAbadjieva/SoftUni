function attachEvents() {
	let posts = [];

	const buttons = {
		loadBtn: document.querySelector("#btnLoadPosts"),
		viewBtn: document.querySelector("#btnViewPost"),
	};

	const selectors = {
		posts: document.querySelector("#posts"),
		postTitle: document.querySelector("#post-title"),
		postBody: document.querySelector("#post-body"),
		comments: document.querySelector("#post-comments"),
	};

	buttons.loadBtn.addEventListener("click", loadPosts);
	buttons.viewBtn.addEventListener("click", viewComments);

	async function loadPosts() {
		const response = await fetch("http://localhost:3030/jsonstore/blog/posts");
		const postsResponse = await response.json();

		posts = Object.values(postsResponse);
		Object.values(postsResponse).forEach((post) => {
			createOptionElement("option", post.id, post.title, selectors.posts);
		});
	}

	async function viewComments() {
		const response = await fetch(
			"http://localhost:3030/jsonstore/blog/comments"
		);
		const comments = await response.json();

		selectors.comments.innerHTML = "";

		selectors.postTitle.textContent =
			selectors.posts.options[selectors.posts.selectedIndex].text;
		posts.filter((p) => {
			p.id === selectors.posts.value;
		});
		selectors.postBody.textContent = posts[0].body;

		const searchedComments = Object.values(comments).filter(
			(comment) => comment.postId === selectors.posts.value
		);

		searchedComments.forEach((comment) => {
			createOptionElement("li", null, comment.text, selectors.comments);
		});
	}

	function createOptionElement(type, value, content, parent) {
		const element = document.createElement(type);
		if (value) {
			element.value = value;
		}
		element.textContent = content;

		parent.appendChild(element);

		return element;
	}
}

attachEvents();
