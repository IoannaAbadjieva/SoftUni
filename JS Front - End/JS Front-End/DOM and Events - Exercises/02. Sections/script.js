function create(words) {
	words.forEach((word) => {
		const div = document.createElement("div");
		const p = document.createElement("p");
		p.textContent = word;
		p.style.display = "none";

		div.appendChild(p);
		div.addEventListener("click", (e) => {
			const hiddenParagraph = e.currentTarget.querySelector("p");
			hiddenParagraph.style.display = "block";
		});

		const container = document.querySelector("#content");
		container.appendChild(div);
	});
}
