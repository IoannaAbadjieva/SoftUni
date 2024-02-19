function store(currStock, orders) {
  const products = [...currStock, ...orders];
  const stock = products.reduce((acc, curr, index) => {
    if (index % 2 !== 0) {
      return acc;
    }

    if (!acc.hasOwnProperty(curr)) {
      acc[curr] = 0;
    }

    acc[curr] += Number(products[index + 1]);
    return acc;
  }, {});

  Object.entries(stock).forEach(([product, qty]) =>
    console.log(`${product} -> ${qty}`)
  );
}

// store(
//   ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
//   ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
// );

store(
  ["Salt", "2", "Fanta", "4", "Apple", "14", "Water", "4", "Juice", "5"],
  ["Sugar", "44", "Oil", "12", "Apple", "7", "Tomatoes", "7", "Bananas", "30"]
);
