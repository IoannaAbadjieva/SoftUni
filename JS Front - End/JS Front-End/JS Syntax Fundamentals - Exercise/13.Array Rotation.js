function rotateArray(array, count) {
  const rotationsCount = count % array.length;

  for (let i = 0; i < rotationsCount; i++) {
    array.push(array.shift());
  }

  console.log(array.join(" "));
}

rotateArray([51, 47, 32, 61, 21], 2);
rotateArray([32, 21, 61, 1], 4);
rotateArray([2, 4, 15, 31], 5);
