function solve(array) {
  const phoneBook = array.reduce((acc, curr) => {
    const [name, phoneNumber] = curr.split(" ");
    acc[name] = phoneNumber;
    return acc;
  }, {});

  Object.entries(phoneBook).forEach(([name, phoneNumber]) =>
    console.log(`${name} -> ${phoneNumber}`)
  );
}

solve([
  "Tim 0834212554",
  "Peter 0877547887",
  "Bill 0896543112",
  "Tim 0876566344",
]);

solve(["George 0552554", "Peter 087587", "George 0453112", "Bill 0845344"]);
