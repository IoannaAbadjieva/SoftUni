function isDigitsSame(number) {
  const digits = number.toString();
  let sum = Number(digits[0]);
  let isConsistent = true;

  for (let index = 1; index < digits.length; index++) {
    sum += Number(digits[index]);

    if (digits[index] !== digits[index - 1]) {
      isConsistent = false;
    }
  }

  console.log(isConsistent);
  console.log(sum);
}

isDigitsSame(2222222);
isDigitsSame(1234);

function isAllDigitsSame(number) {
  const digits = Array.from(number.toString(), Number);
  const isConsistent = new Set(digits).size === 1;
  const sum = digits.reduce((total, digit) => total + digit);

  console.log(isConsistent);
  console.log(sum);
}

isAllDigitsSame(2222222);
isAllDigitsSame(1234);
