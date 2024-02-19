function calculateFruitPrice(fruit, weightInGrams, pricePerKilogram) {
  const weightInKg = weightInGrams / 1000;
  const money = weightInKg * pricePerKilogram;
  console.log(
    `I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(
      2
    )} kilograms ${fruit}.`
  );
}

calculateFruitPrice("apple", 1563, 2.35);
