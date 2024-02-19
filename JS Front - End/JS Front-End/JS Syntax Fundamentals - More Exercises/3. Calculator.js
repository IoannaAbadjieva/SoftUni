function calculate(numOne, operator, numTwo) {
  const calculator = {
    "+": (x, y) => x + y,
    "-": (x, y) => x - y,
    "*": (x, y) => x * y,
    "/": (x, y) => x / y,
  };

  console.log(calculator[operator](numOne, numTwo).toFixed(2));
}

calculate(5, "+", 10);
