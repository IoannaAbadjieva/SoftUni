function attachEvents() {
	const selectors = {
		author: document.querySelector('input[name="author"]'),
		content: document.querySelector('input[name="content"]'),
		submitBtn: document.querySelector("#submit"),
		refreshBtn: document.querySelector("#refresh"),
		container: document.querySelector("#messages"),
	};

	selectors.submitBtn.addEventListener("click", sendMessage);
	selectors.refreshBtn.addEventListener("click", loadMessages);

	async function loadMessages() {
		const response = await (
			await fetch("http://localhost:3030/jsonstore/messenger")
		).json();

		selectors.container.value = "";

		const messages = Object.values(response);
		for (let index = 0; index < messages.length; index++) {
			if (index < messages.length - 1) {
				selectors.container.value += `${messages[index].author}: ${messages[index].content}\n`;
				continue;
			}

			selectors.container.value += `${messages[index].author}: ${messages[index].content}`;
		}
		// .forEach((m) => {
		// });
	}

	async function sendMessage() {
		await fetch("http://localhost:3030/jsonstore/messenger", {
			method: "POST",
			body: JSON.stringify({
				author: selectors.author.value,
				content: selectors.content.value,
			}),
		});

		selectors.author.value = "";
		selectors.content.value = "";
	}
}

attachEvents();
