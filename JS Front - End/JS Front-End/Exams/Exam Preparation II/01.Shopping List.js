function solve(input) {
	const products = input.shift().split("!");

	let line = input.shift();

	while (line !== "Go Shopping!") {
		const [command, product, ...rest] = line.split(" ");

		if (command === "Urgent") {
			if (!products.includes(product)) {
				products.unshift(product);
			}
		} else if (command === "Unnecessary") {
			if (products.includes(product)) {
				const index = products.indexOf(product);
				products.splice(index, 1);
			}
		} else if (command === "Correct") {
			const [newProduct] = rest;
			if (products.includes(product)) {
				const index = products.indexOf(product);
				products[index] = newProduct;
			}
		} else if (command === "Rearrange") {
			if (products.includes(product)) {
				const index = products.indexOf(product);
				products.splice(index, 1);
				products.push(product);
			}
		}

		line = input.shift();
	}

	console.log(products.join(", "));
}

solve([
	"Milk!Pepper!Salt!Water!Banana",
	"Urgent Salt",
	"Unnecessary Grapes",
	"Correct Pepper Onion",
	"Rearrange Grapes",
	"Correct Tomatoes Potatoes",
	"Go Shopping!",
]);
