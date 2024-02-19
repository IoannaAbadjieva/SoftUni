function loadRepos() {
	const username = document.querySelector("#username").value;
	const list = document.querySelector("#repos");
	list.innerHTML = "";

	fetch(`https://api.github.com/users/${username}/repos`)
		// .then((res) => {
		// 	if (res.status !== 200) {
		// 		const li = document.createElement("li");
		// 		li.textContent = `${res.status} ${res.statusText}`;
		// 		list.appendChild(li);
		// 		return;
		// 	}
		// })
		.then((res) => res.json())
		.then((body) =>
			body.forEach((repo) => {
				const li = document.createElement("li");
				const a = document.createElement("a");
				a.href = repo.html_url;
				a.textContent = repo.full_name;
				li.appendChild(a);
				list.appendChild(li);
			})
		)
		.catch((err) => {
			//console.log(err);
			const li = document.createElement("li");
			li.textContent = err.message;
			list.appendChild(li);
		});
}
