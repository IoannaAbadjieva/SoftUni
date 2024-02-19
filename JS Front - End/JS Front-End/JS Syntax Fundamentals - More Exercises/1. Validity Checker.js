function printDistances(x1, y1, x2, y2) {
  function calculateDistance(x1, y1, x2, y2) {
    return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
  }

  function validateDistance(x1, y1, x2, y2) {
    return `{${x1}, ${y1}} to {${x2}, ${y2}} is ${
      Number.isInteger(calculateDistance(x1, y1, x2, y2)) ? "valid" : "invalid"
    }`;
  }

  console.log(validateDistance(x1, y1, 0, 0));
  console.log(validateDistance(x2, y2, 0, 0));
  console.log(validateDistance(x1, y1, x2, y2));
}

printDistances(2, 1, 1, 1);
