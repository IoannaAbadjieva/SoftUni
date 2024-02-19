function solve() {
	document.querySelector("#searchBtn").addEventListener("click", onClick);

	function onClick() {
		const searchQuery = document.querySelector("#searchField").value;
		const cells = Array.from(document.querySelectorAll("tbody td"));
		const activeRows = Array.from(document.querySelectorAll("tbody tr.select"));

		activeRows.forEach((row) => {
			row.classList.remove("select");
		});

		cells
			.filter((cell) => cell.textContent.includes(searchQuery))
			.forEach((cell) => {
				cell.parentElement.classList.add("select");
			});

		document.querySelector("#searchField").value = "";
	}
}

// function solve() {
// 	document.querySelector("#searchBtn").addEventListener("click", onClick);

// 	function onClick() {
// 		const search = document.querySelector("#searchField");
// 		const cells = Array.from(document.querySelectorAll("tbody td"));
// 		const activeRows = document.querySelectorAll("tbody tr.select");
// 		activeRows.forEach((row) => row.classList.remove("select"));

// 		cells.forEach((cell) => {
// 			if (cell.textContent.includes(search.value)) {
// 				cell.parentElement.classList.add("select");
// 			}
// 		});

// 		search.value = "";
// 	}
// }
