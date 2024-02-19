function solve(array) {
  const addressBook = array.reduce((acc, curr) => {
    const [name, address] = curr.split(":");
    acc[name] = address;
    return acc;
  }, {});

  const sortedKeys = Object.keys(addressBook).sort((a, b) =>
    a.localeCompare(b)
  );

  sortedKeys.forEach((key) => console.log(`${key} -> ${addressBook[key]}`));
}
solve([
  "Bob:Huxley Rd",
  "John:Milwaukee Crossing",
  "Peter:Fordem Ave",
  "Bob:Redwing Ave",
  "George:Mesta Crossing",
  "Ted:Gateway Way",
  "Bill:Gateway Way",
  "John:Grover Rd",
  "Peter:Huxley Rd",
  "Jeff:Gateway Way",
  "Jeff:Huxley Rd",
]);
