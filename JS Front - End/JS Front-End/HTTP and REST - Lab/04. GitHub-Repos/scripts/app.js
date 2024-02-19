function loadRepos() {
	fetch("https://api.github.com/users/testnakov/repos")
		.then((res) => res.text())
		.then((res) => {
			const div = document.querySelector("#res");
			div.textContent = res;
		})
		.catch((error) => console.error(error));
}
