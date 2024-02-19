// const range = (start, stop, step) =>
//   Array.from({ length: (stop - start) / step + 1 }, (_, i) => start + i * step);

function printCharactersInRange(chOne, chTwo) {
  const start = Math.min(chOne.charCodeAt(0), chTwo.charCodeAt(0)) + 1;
  const end = Math.max(chOne.charCodeAt(0), chTwo.charCodeAt(0));
  const result = Array.from({ length: end - start }, (_, i) => start + i).map(
    (x) => String.fromCharCode(x)
  );
  console.log(result.join(" "));
}

printCharactersInRange("d", "a");
