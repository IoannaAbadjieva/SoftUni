function printAndSum(start, end) {
  const array = [];
  let sum = 0;

  for (let i = start; i <= end; i++) {
    array.push(i);
    sum += i;
  }

  console.log(array.join(" "));
  console.log(`Sum: ${sum}`);
}

printAndSum(5, 10);
printAndSum(0, 26);
