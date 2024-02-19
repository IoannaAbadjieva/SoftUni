function sumDigits(number) {
  const numToString = number.toString();
  let sum = 0;

  for (let index = 0; index < numToString.length; index++) {
    sum += Number(numToString[index]);
  }

  console.log(sum);
}

sumDigits(97561);
