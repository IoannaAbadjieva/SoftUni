function solve(array) {
  const schedule = array.reduce((acc, curr) => {
    const [day, name] = curr.split(" ");
    if (acc.hasOwnProperty(day)) {
      console.log(`Conflict on ${day}!`);
      return acc;
    }

    acc[day] = name;
    console.log(`Scheduled for ${day}`);
    return acc;
  }, {});

  Object.entries(schedule).forEach(([key, value]) =>
    console.log(`${key} -> ${value}`)
  );
}

solve([
  "Friday Bob",
  "Saturday Ted",
  "Monday Bill",
  "Monday John",
  "Wednesday George",
]);

solve(["Monday Peter", "Wednesday Bill", "Monday Tim", "Friday Tim"]);
