function calculate(numOne, numTwo, operator) {
  const operations = {
    multiply: (x, y) => x * y,
    divide: (x, y) => x / y,
    add: (x, y) => x + y,
    subtract: (x, y) => x - y,
  };

  const result = operations[operator](numOne, numTwo);
  console.log(result);
}

calculate(50, 13, "subtract");
