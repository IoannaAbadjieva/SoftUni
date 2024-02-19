function oddEvenSum(num) {
  const numToString = Array.from(num.toString(), Number);

  const oddSum = numToString
    .filter((d) => d % 2 !== 0)
    .reduce((accumulator, d) => accumulator + d, 0);

  const evenSum = numToString
    .filter((d) => d % 2 == 0)
    .reduce((accumulator, d) => accumulator + d, 0);

  const result = `Odd sum = ${oddSum}, Even sum = ${evenSum}`;
  console.log(result);
}

oddEvenSum(3495892137259234);
