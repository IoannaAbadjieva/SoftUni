function solve(commands) {
  const carWash = {
    soap: (cleanPercentage) => cleanPercentage + 10,
    water: (cleanPercentage) => cleanPercentage + 0.2 * cleanPercentage,
    "vacuum cleaner": (cleanPercentage) =>
      cleanPercentage + 0.25 * cleanPercentage,
    mud: (cleanPercentage) => cleanPercentage - 0.1 * cleanPercentage,
  };

  let cleanPercentage = commands.reduce((acc, curr) => carWash[curr](acc), 0);
  console.log(`The car is ${cleanPercentage.toFixed(2)}% clean.`);
}

solve(["soap", "soap", "vacuum cleaner", "mud", "soap", "water"]);
solve(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);
