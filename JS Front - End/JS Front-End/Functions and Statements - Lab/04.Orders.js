function calculatePriceOfOrder(product, qty) {
  const prices = {
    coffee: 1.5,
    water: 1.0,
    coke: 1.4,
    snacks: 2.0,
  };

  const totalPrice = prices[product] * qty;
  console.log(totalPrice.toFixed(2));
}

calculatePriceOfOrder("water", 5);
calculatePriceOfOrder("coffee", 2);
