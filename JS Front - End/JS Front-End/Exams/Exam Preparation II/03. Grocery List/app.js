const BaseURL = "http://localhost:3030/jsonstore/grocery";

const products = {};

const inputSelectors = {
	product: document.querySelector("#product"),
	count: document.querySelector("#count"),
	price: document.querySelector("#price"),
};

const container = document.querySelector("#tbody");

const addBtn = document.querySelector("#add-product");
const updateBtn = document.querySelector("#update-product");
const loadBtn = document.querySelector("#load-product");

addBtn.addEventListener("click", addProduct);
updateBtn.addEventListener("click", updateProduct);
loadBtn.addEventListener("click", loadAllProducts);

async function loadAllProducts(e) {
	e.preventDefault();
	let productsData;
	try {
		const response = await fetch(BaseURL);
		productsData = await response.json();
	} catch (err) {
		console.log(err.message);
	}

	container.innerHTML = "";

	Object.values(productsData).forEach(({ product, count, price, _id }) => {
		const row = createElement("tr", null, null, null, container);
		createElement("td", product, null, ["name"], row);
		createElement("td", count, null, ["count-product"], row);
		createElement("td", price, null, ["count-product"], row);
		const btnsCell = createElement("td", null, null, ["btn"], row);
		const updateProductBtn = createElement(
			"button",
			"Update",
			_id,
			["update"],
			btnsCell
		);
		const deleteProductBtn = createElement(
			"button",
			"Delete",
			_id,
			["delete"],
			btnsCell
		);

		updateProductBtn.addEventListener("click", sendProductForUpdate);
		deleteProductBtn.addEventListener("click", deleteProduct);

		products[_id] = { product, count, price, _id };

		Object.values(inputSelectors).forEach((s) => (s.value = ""));
	});
}

async function addProduct(e) {
	e.preventDefault();
	if (Object.values(inputSelectors).some((s) => s.value === "")) {
		return;
	}

	const newProduct = Object.entries(inputSelectors).reduce(
		(acc, [key, selector]) => {
			acc[key] = selector.value;
			return acc;
		},
		{}
	);

	try {
		await fetch(BaseURL, {
			method: "POST",
			body: JSON.stringify(newProduct),
		});
	} catch (err) {
		console.log(err.message);
	}

	Object.values(inputSelectors).forEach((s) => (s.value = ""));

	await loadAllProducts(e);
}

async function deleteProduct(e) {
	const productId = e.currentTarget.dataset["productid"];

	try {
		await fetch(`${BaseURL}/${productId}`, {
			method: "DELETE",
		});
	} catch (err) {
		console.log(err.message);
	}

	await loadAllProducts(e);

	delete products[productId];
}

function sendProductForUpdate(e) {
	const productId = e.currentTarget.dataset["productid"];

	Object.entries(inputSelectors).forEach(([key, selector]) => {
		selector.value = products[productId][key];
	});

	const currProductContainer = e.currentTarget.parentElement.parentElement;
	container.removeChild(currProductContainer);

	addBtn.disabled = true;
	updateBtn.disabled = false;

	updateBtn.setAttribute("data-productid", productId);
	delete products[productId];
}

async function updateProduct(e) {
	const productId = e.currentTarget.dataset["productid"];

	if (Object.values(inputSelectors).some((s) => s.value === "")) {
		return;
	}

	const updatedProduct = Object.entries(inputSelectors).reduce(
		(acc, [key, selector]) => {
			acc[key] = selector.value;
			return acc;
		},
		{}
	);

	try {
		await fetch(`${BaseURL}/${productId}`, {
			method: "PATCH",
			body: JSON.stringify(updatedProduct),
		});
	} catch (err) {
		console.log(err.message);
	}

	Object.values(inputSelectors).forEach((s) => (s.value = ""));
	updateBtn.disabled = true;
	addBtn.disabled = false;

	await loadAllProducts(e);
}

function createElement(type, content, id, classes, parent) {
	element = document.createElement(type);

	if (content) {
		element.textContent = content;
	}

	if (id) {
		element.setAttribute("data-productid", id);
	}

	if (classes && classes.length > 0) {
		element.classList.add(...classes);
	}

	if (parent) {
		parent.appendChild(element);
	}

	return element;
}
