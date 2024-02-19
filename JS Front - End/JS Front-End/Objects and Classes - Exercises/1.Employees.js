function printEmployeesInfo(input) {
  const employees = input.reduce((acc, curr) => {
    acc[curr] = curr.length;
    return acc;
  }, {});

  Object.entries(employees).forEach(([key, value]) =>
    console.log(`Name: ${key} -- Personal Number: ${value}`)
  );
}

// printEmployeesInfo([
//   "Silas Butler",
//   "Adnaan Buckley",
//   "Juan Peterson",
//   "Brendan Villarreal",
// ]);

printEmployeesInfo([
  "Samuel Jackson",
  "Will Smith",
  "Bruce Willis",
  "Tom Holland",
]);
