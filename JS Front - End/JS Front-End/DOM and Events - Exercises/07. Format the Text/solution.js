function solve() {
	const text = document.querySelector("#input").value;
	const container = document.querySelector("#output");

	const sentences = text.match(/[^.!?]*[.!?]/g);

	while (sentences.length > 0) {
		const p = document.createElement("p");
		p.textContent = sentences
			.splice(0, 3)
			.map((s) => s.trim())
			.join("");

		container.appendChild(p);
	}
}
