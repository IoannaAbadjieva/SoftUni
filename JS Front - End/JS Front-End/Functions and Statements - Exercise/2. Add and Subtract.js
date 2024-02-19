function addAndSubtract(a, b, c) {
  const sum = (x, y) => x + y;
  const subtract = (x, y) => x - y;
  const result = subtract(sum(a, b), c);
  console.log(result);
}

addAndSubtract(42, 58, 100);
