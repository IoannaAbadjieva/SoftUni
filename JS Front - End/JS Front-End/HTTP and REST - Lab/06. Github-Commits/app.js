function loadCommits() {
	// Try it with Fetch API
	const username = document.querySelector("#username").value;
	const repo = document.querySelector("#repo").value;
	const list = document.querySelector("#commits");
	list.innerHTML = "";

	fetch(`https://api.github.com/repos/${username}/${repo}/commits`)
		// .then((res) => {
		// 	if (res.status !== 200) {
		// 		const li = document.createElement("li");
		// 		li.textContent = `Error: ${res.status} (${res.statusText})`;
		// 		list.appendChild(li);
		// 	}
		// })
		.then((res) => res.json())
		.then((commits) =>
			commits.forEach(({ commit }) => {
				const li = document.createElement("li");
				li.textContent = `${commit.author.name}: ${commit.message}`;
				list.appendChild(li);
			})
		);
}
