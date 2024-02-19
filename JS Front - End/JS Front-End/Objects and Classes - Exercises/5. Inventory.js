function solve(input) {
  const heroes = input.map((h) => {
    const [name, level, items] = h.split(" / ");
    return { name, level, items };
  });

  const sortedHeroes = heroes.sort((a, b) => a.level - b.level);

  sortedHeroes.forEach((hero) =>
    Object.entries(hero).forEach(([key, value]) =>
      console.log(`${key === "name" ? "Hero:" : key + " =>"} ${value}`)
    )
  );
}
// solve([
//   "Isacc / 25 / Apple, GravityGun",
//   "Derek / 12 / BarrelVest, DestructionSword",
//   "Hes / 1 / Desolator, Sentinel, Antara",
// ]);

solve([
  "Batman / 22 / Banana, Gun",
  "Superman / 18 / Sword",
  "Poppy / 8 / Sentinel, Antara",
]);
