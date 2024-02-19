function divideFactorlials(numOne, numTwo) {
  function calculateFactorial(number) {
    let factorial = 1;
    for (let i = 1; i <= number; i++) {
      factorial *= i;
    }

    return factorial;
  }

  const result = calculateFactorial(numOne) / calculateFactorial(numTwo);
  console.log(result.toFixed(2));
}

divideFactorlials(6, 2);
