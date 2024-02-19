function sortNumbers(array) {
  const sortedArray = array.sort((a, b) => a - b);
  const result = [];
  const length = array.length;

  for (let index = 0; index < length; index++) {
    if (index % 2 === 0) {
      result.push(sortedArray.shift());
    } else {
      result.push(sortedArray.pop());
    }
  }
  return result;
}

sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);
