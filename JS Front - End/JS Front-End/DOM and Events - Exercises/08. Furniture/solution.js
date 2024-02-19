function solve() {
	const generateButton = document.querySelector("#exercise button");
	generateButton.addEventListener("click", addFurniture);

	const buyButton = document.querySelector("#exercise button:nth-of-type(2)");
	buyButton.addEventListener("click", buyFurniture);

	function addFurniture() {
		const input = JSON.parse(
			document.querySelector("#exercise textarea").value
		);

		input.forEach((furniture) => {
			const imageCell = document.createElement("td");
			const image = document.createElement("img");
			image.src = furniture.img;
			imageCell.appendChild(image);

			const nameCell = document.createElement("td");
			nameCell.textContent = furniture.name;

			const priceCell = document.createElement("td");
			priceCell.textContent = furniture.price;

			const decorationFactorCell = document.createElement("td");
			decorationFactorCell.textContent = furniture.decFactor;

			const checkboxCell = document.createElement("td");
			const checkbox = document.createElement("input");
			checkbox.type = "checkbox";
			checkboxCell.appendChild(checkbox);

			const row = document.createElement("tr");

			row.appendChild(imageCell);
			row.appendChild(nameCell);
			row.appendChild(nameCell);
			row.appendChild(priceCell);
			row.appendChild(decorationFactorCell);
			row.appendChild(checkboxCell);

			const table = document.querySelector("tbody");
			table.appendChild(row);
		});
	}

	function buyFurniture() {
		const checkboxes = Array.from(
			document.querySelectorAll('input[type="checkbox"]:checked')
		);
		const cart = checkboxes
			.map((checkbox) => {
				const row = checkbox.parentElement.parentElement;
				const name = row.querySelector("td:nth-of-type(2)").innerText;
				const price = Number(row.querySelector("td:nth-of-type(3)").innerText);
				const decFactor = Number(
					row.querySelector("td:nth-of-type(4)").innerText
				);

				return { name, price, decFactor };
			})
			.reduce(
				(acc, curr) => {
					acc.names.push(curr.name);
					acc.price += curr.price;
					acc.avgDecFactor += curr.decFactor / checkboxes.length;

					return acc;
				},
				{ names: [], price: 0, avgDecFactor: 0 }
			);

		const output = document.querySelector("#exercise textarea:nth-of-type(2)");
		output.value = `Bought furniture: ${cart.names.join(
			", "
		)}\nTotal price: ${cart.price.toFixed(2)}\nAverage decoration factor: ${
			cart.avgDecFactor
		}`;
	}
}
