function solve(input) {
  const parking = new Set();
  input.forEach((element) => {
    const [command, carNumber] = element.split(", ");
    if (command === "IN") {
      parking.add(carNumber);
    } else if (command === "OUT") {
      parking.delete(carNumber);
    }
  });
  const carNumbers = Array.from(parking).sort();
  console.log(
    carNumbers.length > 0 ? carNumbers.join("\n") : "Parking Lot is Empty"
  );
}

solve(["IN, CA2844AA", "IN, CA1234TA", "OUT, CA2844AA", "OUT, CA1234TA"]);
// solve([
//   "IN, CA2844AA",
//   "IN, CA1234TA",
//   "OUT, CA2844AA",
//   "IN, CA9999TT",
//   "IN, CA2866HI",
//   "OUT, CA1234TA",
//   "IN, CA2844AA",
//   "OUT, CA2866HI",
//   "IN, CA9876HH",
//   "IN, CA2822UU",
// ]);
